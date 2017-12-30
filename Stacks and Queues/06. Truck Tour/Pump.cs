namespace _06.Truck_Tour
{
    public class Pump
    {
        public Pump(long amountPetrol, long distance)
        {
            this.AmountPetrol = amountPetrol;
            this.Distance = distance;
        }

        public long AmountPetrol { get; set; }

        public long Distance { get; set; }
    }
}
