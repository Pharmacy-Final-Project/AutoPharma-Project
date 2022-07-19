namespace AutoPharma.Models
{
    public class BranchMedicine
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int BranchId { get; set; }
        public int LocationId { get; set; }
        public int Count { get; set; }
        public double OurPrice { get; set; }
        public string Name => Medicine.Name;



        //References

        public Location Location { get; set; }
        public Medicine Medicine { get; set; }
        public Branch Branch { get; set; }

    }
}
