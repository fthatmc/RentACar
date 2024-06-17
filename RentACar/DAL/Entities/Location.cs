namespace RentACar.DAL.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }


        //birden fazla ilişiki kurma
        public List<RentCar> PickUpCarLocation { get; set; }
        public List<RentCar> DropOffCarLocation { get; set; }
    }
}
