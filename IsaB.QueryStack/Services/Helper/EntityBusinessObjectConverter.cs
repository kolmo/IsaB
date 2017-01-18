using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.BusinessObjects;
using IsaB.Entities;
using IsaB.Interfaces;

namespace IsaB.Services
{
    /// <summary>
    /// Extension-Methoden zum Wandeln von DTO-Listen in Businessobject-Listen
    /// </summary>
    public static class EntityBusinessObjectConverter
    {
        public static Immobilie Convert(this ImmobilieEntity source)
        {
            return new Immobilie
            {
                AusbauzustandId = source.AusbauzustandId,
                Baujahr = source.Baujahr,
                BauweiseId = source.BauweiseId,
                Bodenrichtwert = source.Bodenrichtwert,
                Bruttogrundflaeche = source.Bruttogrundflaeche,
                ErzeugtAm = source.ErzeugtAm,
                GebaeudeartId = source.GebaeudeartId,
                GewichtetStandard = source.GewichtetStandard,
                Grundstuecksflaeche = source.Grundstuecksflaeche,
                ID = source.ID,
                Ort = source.Ort,
                PLZ = source.PLZ,
                Restnutzungsdauer = source.Restnutzungsdauer,
                Strasse = source.Strasse,
                VerfuegbarAb = source.VerfuegbarAb,
                Verkaufspreis = source.Verkaufspreis,
                VorlSachwert = source.VorlSachwert
            };
        }
        public static ImmobilieEntity Convert(this Immobilie source)
        {
            return new ImmobilieEntity
            {
                AusbauzustandId = source.AusbauzustandId,
                Baujahr = source.Baujahr,
                BauweiseId = source.BauweiseId,
                Bodenrichtwert = source.Bodenrichtwert,
                Bruttogrundflaeche = source.Bruttogrundflaeche,
                ErzeugtAm = source.ErzeugtAm,
                GebaeudeartId = source.GebaeudeartId,
                GewichtetStandard = source.GewichtetStandard,
                Grundstuecksflaeche = source.Grundstuecksflaeche,
                ID = source.ID,
                Ort = source.Ort,
                PLZ = source.PLZ,
                Restnutzungsdauer = source.Restnutzungsdauer,
                Strasse = source.Strasse,
                Verkaufspreis = source.Verkaufspreis,
                VorlSachwert = source.VorlSachwert
            };
        }
        public static IList<Immobilie> Convert(this IEnumerable<ImmobilieEntity> source)
        {
            var list = new List<Immobilie>();
            foreach (var item in source)
            {
                list.Add(item.Convert());
            }
            return list;
        }
        public static IList<Gesamtnutzungsdauer> Convert(this IEnumerable<GesamtnutzungsdauerEntity> list)
        {
            IList<Gesamtnutzungsdauer> outlist = new List<Gesamtnutzungsdauer>();
            foreach (var item in list)
            {
                outlist.Add(new Gesamtnutzungsdauer
                {
                    Dauer = item.Dauer,
                    GebArtId = item.GebArtId,
                    StdStufe = item.StdStufe
                });
            }
            return outlist;
        }
        public static Gebaeudeart Convert(this GebaeudeartEntity source)
        {
            return new Gebaeudeart
                {
                    ID = source.ID,
                    Bezeichnung = source.Bezeichnung
                };
        }
        public static IList<Gebaeudeart> Convert(this IEnumerable<GebaeudeartEntity> list)
        {
            var gebArten = new List<Gebaeudeart>();
            foreach (var item in list)
                gebArten.Add(item.Convert());
            return gebArten;
        }
        public static Bauweise Convert(this GebBauweiseEntity source)
        {
            return new Bauweise
                  {
                      Bezeichnung = source.Bezeichnung,
                      ID = source.ID
                  };
        }
        public static IList<Bauweise> Convert(this IEnumerable<GebBauweiseEntity> list)
        {
            var bauweisen = new List<Bauweise>();
            foreach (var item in list)
                bauweisen.Add(item.Convert());
            return bauweisen;
        }
        public static IList<Ausbauzustand> Convert(this IEnumerable<GebAusbauzustandEntity> list)
        {
            var ausb = new List<Ausbauzustand>();
            foreach (var item in list)
            {
                Ausbauzustand ia = new Ausbauzustand
                {
                    ID = item.ID,
                    Bezeichnung = item.Bezeichnung
                };
                ausb.Add(ia);
            }
            return ausb;
        }
        public static IList<Waegungsanteil> Convert(this IEnumerable<WaegungsanteilEntity> source)
        {
            var waegListe = new List<Waegungsanteil>();
            foreach (var item in source)
            {
                Waegungsanteil waegung = new Waegungsanteil
                {
                    GebTeilId = item.GebTeilId,
                    TabellenId = item.TabellenId,
                    Waegung = item.Waegung
                };
                waegListe.Add(waegung);
            }
            return waegListe;
        }
        public static IList<Normalherstellungskosten> Convert(this IEnumerable<NHKostenEntity> source)
        {
            var ndkl = new List<Normalherstellungskosten>();
            foreach (var item in source)
            {
                Normalherstellungskosten kosten = new Normalherstellungskosten
                {
                    AusbZustandId = item.AusbZustandId,
                    BauweiseId = item.BauweiseId,
                    GebArtId = item.GebArtId,
                    KostenProM2 = item.KostenProM2,
                    Standardstufe = item.Standardstufe
                };
                ndkl.Add(kosten);
            }
            return ndkl;
        }
        public static IList<Gebaeudestandardstufe> Convert(this IEnumerable<StandardstufeEntity> source)
        {
            var ss = new List<Gebaeudestandardstufe>();
            foreach (var item in source)
            {
                Gebaeudestandardstufe stdStufe = new Gebaeudestandardstufe
                {
                    Beschreibung = item.Beschreibung,
                    GebTeilId = item.GebTeilId,
                    Stufe = item.Stufe,
                    TabellenId = item.TabellenId
                };
                ss.Add(stdStufe);
            }
            return ss;
        }
        public static IList<Gebaeudeteil> Convert(this IEnumerable<GebaeudeteilEntity> source)
        {
            var gt = new List<Gebaeudeteil>();
            foreach (var item in source)
            {
                Gebaeudeteil teil = new Gebaeudeteil
                {
                    ID = item.ID,
                    Bezeichnung = item.Bezeichnung
                };
                gt.Add(teil);
            }
            return gt;
        }
        public static IList<Modernisierung> Convert(this IEnumerable<ModernisierungEntity> source)
        {
            var modl = new List<Modernisierung>();
            foreach (var item in source)
            {
                Modernisierung teil = new Modernisierung
                {
                    ID = item.ID,
                    ModernElement = item.ModernElement,
                    MaxPunkte = item.MaxPunkte
                };
                modl.Add(teil);
            }
            return modl;
        }
        public static IList<Modernisierungsgrad> Convert(this IEnumerable<ModernisierungsgradEntity> source)
        {
            List<Modernisierungsgrad> mgListe = new List<Modernisierungsgrad>();
            foreach (var item in source)
            {
                mgListe.Add(new Modernisierungsgrad
                {
                    Punkte = item.Punkte,
                    Grad = item.Grad,
                    Koeffa = item.Koeffa,
                    Koeffb = item.Koeffb,
                    Koeffc = item.Koeffc,
                    AbRelAlter = item.AbRelAlter
                });
            }
            return mgListe;
        }
        public static ImmobilieModernisierung Convert(this ImmobilieModernisierungEntity source)
        {
            return new ImmobilieModernisierung
            {
                Bemerkung = source.Bemerkung,
                ID = source.ID,
                ImmoID = source.ImmoID,
                ModernId = source.ModernId,
                Punkte = source.Punkte
            };
        }
        public static IList<ImmobilieModernisierung> Convert(this IList<ImmobilieModernisierungEntity> source)
        {
            var sink = new List<ImmobilieModernisierung>();
            foreach (var item in source)
                sink.Add(item.Convert());
            return sink;
        }
        public static ImmobilieModernisierungEntity Convert(this ImmobilieModernisierung source)
        {
            return new ImmobilieModernisierungEntity
            {
                Bemerkung = source.Bemerkung,
                ID = source.ID,
                ImmoID = source.ImmoID,
                ModernId = source.ModernId,
                Punkte = source.Punkte
            };
        }
        public static ImmobilieKorrekturfaktor Convert(this ImmobilieKorrFaktorEntity source)
        {
            return new ImmobilieKorrekturfaktor
            {
                Anwenden = source.Anwenden,
                Faktor = source.Faktor,
                Faktorkriterium = source.Faktorkriterium,
                FaktorTyp = source.FaktorTyp,
                ID = source.ID,
                ImmoId = source.ImmoId
            };
        }
        public static ImmobilieKorrFaktorEntity Convert(this ImmobilieKorrekturfaktor source)
        {
            return new ImmobilieKorrFaktorEntity
            {
                Anwenden = source.Anwenden,
                Faktor = source.Faktor,
                Faktorkriterium = source.Faktorkriterium,
                FaktorTyp = source.FaktorTyp,
                ID = source.ID,
                ImmoId = source.ImmoId
            };
        }
        public static IList<ImmobilieKorrekturfaktor> Convert(this IEnumerable<ImmobilieKorrFaktorEntity> source)
        {
            var list = new List<ImmobilieKorrekturfaktor>();
            foreach (var item in source)
                list.Add(item.Convert());
            return list;
        }
        public static GebaeudeartStandard Convert(this GebArtStandardEntity source)
        {
            return new GebaeudeartStandard
            {
                GebArtId = source.GebArtId,
                StdTabellenId = source.StdTabellenId
            };
        }
        public static IList<GebaeudeartStandard> Convert(this IEnumerable<GebArtStandardEntity> source)
        {
            var list = new List<GebaeudeartStandard>();
            foreach (var item in source)
            {
                list.Add(item.Convert());
            }
            return list;
        }
        public static ImmobilieTeilStandard Convert(this TeilStandardEntity source)
        {
            return new ImmobilieTeilStandard
            {
                ID = source.ID,
                ImmoId = source.ImmoId,
                TeileId = source.TeileId,
                Wert = source.Wert
            };
        }
        public static TeilStandardEntity Convert(this ImmobilieTeilStandard source)
        {
            return new TeilStandardEntity
            {
                ID = source.ID,
                ImmoId = source.ImmoId,
                TeileId = source.TeileId,
                Wert = source.Wert
            };
        }
        public static IList<ImmobilieTeilStandard> Convert(this IEnumerable<TeilStandardEntity> source)
        {
            var resultlist = new List<ImmobilieTeilStandard>();
            foreach (var item in source)
                resultlist.Add(item.Convert());
            return resultlist;
        }
        public static IList<Baupreisindex> Convert(this IEnumerable<BaupreisindexEntity> source)
        {
            var bpil = new List<Baupreisindex>();
            foreach (var item in source)
            {
                bpil.Add(new Baupreisindex
                {
                    Index = item.Index,
                    Jahr = item.Jahr,
                    Quartal = item.Quartal,
                    TabellenId = item.TabellenId,
                    Aenderbar = item.Aenderbar
                });
            }
            return bpil;
        }
        public static IList<Korrekturfaktor> Convert(this IEnumerable<KorrekturfaktorEntity> source)
        {
            var sink = new List<Korrekturfaktor>();
            foreach (var item in source)
            {
                var ikf = new Korrekturfaktor
                {
                    Beschreibung = item.Beschreibung,
                    Faktor = item.Faktor,
                    GebArtId = item.GebArtId,
                    TypId = item.TypId,
                    XVal = item.XVal
                };
                sink.Add(ikf);
            }
            return sink;
        }
        public static Korrekturfaktortyp Convert(this KorrekturfaktortypEntity source)
        {
            return new Korrekturfaktortyp { Bezeichnung = source.Bezeichnung, Id = source.Id, Interpolierbar = source.Interpolierbar };
        }
        public static IList<Korrekturfaktortyp> Convert(this IEnumerable<KorrekturfaktortypEntity> source)
        {
            var sink = new List<Korrekturfaktortyp>();
            foreach (var item in source)
                sink.Add(item.Convert());
            return sink;
        }
        public static ImmobilieBild Convert(this ImmobilieBildEntity source)
        {
            return new ImmobilieBild
            {
                Beschriftung = source.Beschriftung,
                Bilddaten = source.Bilddaten,
                Id = source.Id,
                ImmobilieId = source.ImmobilieId,
                SetAsTitlePictureDate = source.SetAsTitlePictureDate,
                Created = source.Created
            };
        }
        public static IList<ImmobilieBild> Convert(this IEnumerable<ImmobilieBildEntity> source)
        {
            var sink = new List<ImmobilieBild>();
            foreach (var item in source)
                sink.Add(item.Convert());
            return sink;
        }
        public static ImmobilieBildEntity Convert(this ImmobilieBild source)
        {
            return new ImmobilieBildEntity
            {
                Beschriftung = source.Beschriftung,
                Bilddaten = source.Bilddaten,
                Id = source.Id,
                ImmobilieId = source.ImmobilieId,
                SetAsTitlePictureDate = source.SetAsTitlePictureDate,
                Created = source.Created
            };
        }
    }
}
