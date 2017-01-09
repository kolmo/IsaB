using Microsoft.Practices.ServiceLocation;
using IsaB.Interfaces;
using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public static class ModelBuilder
    {
        static IRepository _repository;
        static ModelBuilder()
        {
            _repository = ServiceLocator.Current.GetInstance<IRepository>();
        }
        public static IList<GebaeudeteilModel> SetupGebaeudeteile(Immobilie immobilie)
        {
            IList<GebaeudeteilModel> list = new List<GebaeudeteilModel>();
            IList<ImmobilieTeilStandard> teileStandards = _repository.LoadTeilStandardsByImmoId(immobilie.ID);
            IList<Gebaeudeteil> gTeileListe = _repository.ListGebaeudeteileByGebArtId(immobilie.GebaeudeartId);
            var waegungsanteile = _repository.ListWaegungsanteileByGebArtId(immobilie.GebaeudeartId);
            foreach (var gTeil in gTeileListe)
            {
                var ts = teileStandards.FirstOrDefault(x => x.TeileId == gTeil.ID);
                if (ts == null)
                {
                    ts = _repository.CreateNew<ImmobilieTeilStandard>();
                    ts.TeileId = gTeil.ID;
                    ts.ImmoId = immobilie.ID;
                }
                var model = new GebaeudeteilModel(gTeil, ts);
                var waegung = waegungsanteile.FirstOrDefault(x => x.GebTeilId == gTeil.ID);
                model.Waegungsanteil = waegung != null ? waegung.Waegung : default(int?);
                list.Add(model);
            }
            return list;
        }

        public static List<KorrFakCollectionBase> GetKorrekturfaktorenByImmo(Immobilie immobilie,
            ref IList<ImmobilieKorrekturfaktor> immobilieKorrekturfaktoren)
        {
            var liste = new List<KorrFakCollectionBase>();
            immobilieKorrekturfaktoren = _repository.LoadKorrFaktorenByImmoId(immobilie.ID);
            var korrekturfaktoren = _repository.LoadKorrekturfaktorenByGebArtId(immobilie.GebaeudeartId);
            var korrekturfaktortypen = _repository.ListAllKorrekturfaktortypen();
            if (korrekturfaktoren != null && korrekturfaktoren.Any())
            {
                var korrFakTypen = korrekturfaktoren.GroupBy(x => x.TypId);
                foreach (var group in korrFakTypen)
                {
                    Korrekturfaktortyp faktorTyp = korrekturfaktortypen.Single(x => x.Id == group.Key);
                    KorrFakCollectionBase list = null;
                    if (faktorTyp.Interpolierbar)
                        list = new InterpolKorrFakCollection(faktorTyp, group);
                    else
                        list = new DiscreteKorrFakCollection(faktorTyp, group);
                    liste.Add(list);
                }
                foreach (var item in immobilieKorrekturfaktoren)
                {
                    KorrFakCollectionBase kfb = liste.FirstOrDefault(x => x.KorrFakTyp.Id == item.FaktorTyp);
                    if (kfb != null)
                    {
                        kfb.Anwenden = item.Anwenden;
                        kfb.SetFaktorWert(item);
                    }
                }
            }
            return liste;
        }
    }
}
