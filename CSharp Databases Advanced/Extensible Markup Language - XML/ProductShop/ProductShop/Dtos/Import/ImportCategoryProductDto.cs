using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductDto
    {
        [XmlElement("CategoryId")]
        public string CategoryId { get; set; }

        [XmlElement("ProductId")]
        public string ProductId { get; set; }
    }
}
