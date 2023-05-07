using OrdinaMTech.Cv.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrdinaMTech.Cv.Data.Models
{
    public class Kennis
    {
        public int Id { get; set; }
        [Required]
        public string Kennisgebied { get; set; }       
        public Kennisniveau Kennisniveau { get; set; }
        public int Jaren { get; set; }
    }
}
