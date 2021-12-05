using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrissonerMailDto
    {
        [Required]
        [StringLength(20, MinimumLength =3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^The\s[A-Z]{1}[a-z]+$")]
        public string Nickname { get; set; }

        [Range(16, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailDto[] Mails { get; set; }
    }
}


