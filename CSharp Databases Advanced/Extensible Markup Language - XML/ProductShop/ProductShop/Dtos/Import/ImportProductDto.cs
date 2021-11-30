using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")]
    public class ImportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("sellerId")]
        public string SellerId { get; set; }

        [XmlElement("buyerId")]
        public string BuyerId { get; set; }
    }
}
