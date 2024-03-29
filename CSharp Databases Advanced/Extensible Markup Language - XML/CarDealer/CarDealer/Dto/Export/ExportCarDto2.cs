﻿using System.Xml.Serialization;

namespace CarDealer.Dto.Export
{
    [XmlType("car")]
    public class ExportCarDto2
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
