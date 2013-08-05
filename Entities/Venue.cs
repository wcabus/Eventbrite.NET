namespace EventbriteNET.Entities
{
    public class Venue : EntityBase
    {
        public long Id;
        public string Name;
        public string Address;
        public string Address2;
        public string City;
        public string Region;
        public string PostalCode;
        public string Country;
        public string CountryCode;

        public Venue(EventbriteContext context) : base(context) { }
         
    }
}