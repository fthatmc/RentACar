namespace RentACar.DAL.Entities
{
    public class RentCar
    {
        public int RentCarId { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }

        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public int? PickUpLocationID { get; set; }
        public int? DropOffLocationID { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }


    }
}
