namespace RentACar.Models
{
    public class SearchCarViewModel
    {
        public int PickUpLocationID { get; set; }
        public int DropDownLocationID { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropDownDate { get; set; }
    }
}
