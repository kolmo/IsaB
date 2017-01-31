namespace IsaB.Models
{
    public class BuildingPartModel
    {
        public int EstateId { get; set; }
        public int StdTableId { get; set; }
        public int PartId { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

}
