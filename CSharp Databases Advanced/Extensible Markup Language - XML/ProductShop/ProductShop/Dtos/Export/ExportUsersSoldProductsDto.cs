using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUsersSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName  { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public List<ExportProductDto> SoldProducts { get; set; }
    }
}
