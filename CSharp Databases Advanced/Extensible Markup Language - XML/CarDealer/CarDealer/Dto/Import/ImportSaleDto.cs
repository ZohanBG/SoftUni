﻿using System.Xml.Serialization;

namespace CarDealer.Dto.Import
{
    [XmlType("Sale")]
    public class ImportSaleDto
    {
        [XmlElement("carId")]
        public string CarId { get; set; }

        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; }
    }
}
