using OrdinaMTech.Cv.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrdinaMTech.Cv.Api.Models
{
    public class Kennis
    {
        public int id { get; set; }
        [Required]
        public string Kennisgebied { get; set; }       
        public Kennisniveau Kennisniveau { get; set; }
        public int Jaren { get; set; }
    }
}
