using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketDto
    {
        [Required]
        [Range(1.00, 100.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}

//"Name": "Corona Theatre",
//    "NumberOfHalls": 7,
//    "Director": "Alwin MacCosty",
//    "Tickets": [
//      {
//        "Price": 7.63,
//        "RowNumber": -5,
//        "PlayId": 4
//      },

