using MojaSzafa.DB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MojaSzafa.DB.Entities
{
    public class Clothing
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [DisplayName("Nazwa")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kolor jest wymagany")]
        [DisplayName("Kolor")]
        [DataType(DataType.Text)]
        public string Color { get; set; }

        [Required(ErrorMessage = "Materiał jest wymagany")]
        [DisplayName("Materiał")]
        [DataType(DataType.Text)]
        public string Material { get; set; }

        [DisplayName("Kiedy kupiono")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data jest wymagana")]
        [DateLesserThanOrEqueal(ErrorMessage = "Data nie może być późniejsza niż dzisiaj")]
        public DateTime DateAdded { get; set; }

    }
}
