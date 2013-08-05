using System;
using System.Xml;
using EventbriteNET.Entities;

namespace EventbriteNET.Xml
{
    class VenueBuilder : BuilderBase
    {
        public VenueBuilder(EventbriteContext context) : base(context) { }

        public Venue Build(string xmlString)
        {
            this.Validate(xmlString);

            var toReturn = new Venue(this.Context);

            var doc = new XmlDocument();
            doc.LoadXml(xmlString);

            toReturn.Id = long.Parse(doc.GetElementsByTagName("id")[0].InnerText);
            toReturn.Name = doc.GetElementsByTagName("name")[0].InnerText;
            toReturn.Address = doc.GetElementsByTagName("address")[0].InnerText;
            toReturn.Address2 = doc.GetElementsByTagName("address2")[0].InnerText;
            toReturn.City = doc.GetElementsByTagName("city")[0].InnerText;
            toReturn.PostalCode = doc.GetElementsByTagName("postal_code")[0].InnerText;
            toReturn.Country = doc.GetElementsByTagName("country")[0].InnerText;
            toReturn.CountryCode = doc.GetElementsByTagName("country_code")[0].InnerText;

            return toReturn;
        }
    }
}