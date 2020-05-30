using OrdinaMTech.Cv.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrdinaMTech.Cv.Shared.Models
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
