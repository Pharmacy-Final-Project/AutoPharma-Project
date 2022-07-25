namespace AutoPharma.Models
{
    public class Location
    {
        //Maybe we make the Id = BranchId?
        public int Id { get; set; }
        public int BranchId { get; set; }
        public char Cabinet { get; set; }
        public int Shelf { get; set; }


        //References
    }
}
