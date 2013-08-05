﻿using System;
using System.Linq;
using System.Xml;
using EventbriteNET.Entities;

namespace EventbriteNET.Xml
{
    class EventBuilder : BuilderBase
    {
        public EventBuilder(EventbriteContext context) : base(context) { }

        public Event Build(string xmlString)
        {
            this.Validate(xmlString);

            var toReturn = new Event(this.Context);

            var doc = new XmlDocument();
            doc.LoadXml(xmlString);

            toReturn.Id = long.Parse(doc.GetElementsByTagName("id")[0].InnerText);
            toReturn.Title = doc.GetElementsByTagName("title")[0].InnerText;
            toReturn.Description = doc.GetElementsByTagName("description")[0].InnerText; ;
            toReturn.StartDateTime = DateTime.Parse(doc.GetElementsByTagName("start_date")[0].InnerText);
            toReturn.EndDateTime = DateTime.Parse(doc.GetElementsByTagName("end_date")[0].InnerText);
            toReturn.Created = DateTime.Parse(doc.GetElementsByTagName("created")[0].InnerText);
            toReturn.Modified = DateTime.Parse(doc.GetElementsByTagName("modified")[0].InnerText);
            toReturn.Privacy = doc.GetElementsByTagName("privacy")[0].InnerText;
            toReturn.Url = doc.GetElementsByTagName("url")[0].InnerText;
            toReturn.Status = doc.GetElementsByTagName("status")[0].InnerText;

            var venueXml = doc.GetElementsByTagName("venue");
            if (venueXml.Count > 0)
            {
                var vbuilder = new VenueBuilder(this.Context);
                toReturn.Venue = vbuilder.Build(venueXml[0].OuterXml);
            }

            var tickets = doc.GetElementsByTagName("ticket");
            var builder = new TicketBuilder(this.Context);
            foreach (XmlNode ticketNode in tickets)
            {
                var ticket = builder.Build(ticketNode.OuterXml);
                toReturn.Tickets.Add(ticket.Id, ticket);
            }


            return toReturn;
        }
    }
}
