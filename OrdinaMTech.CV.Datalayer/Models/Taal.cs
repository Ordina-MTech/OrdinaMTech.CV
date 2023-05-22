using OrdinaMTech.Cv.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrdinaMTech.Cv.Data.Models
{
    public class Taal
    {
        public int Id { get; set; }
        [Required]
        public string? Naam { get; set; }
        public Taalniveau Schriftelijk {get; set; }
        public Taalniveau Mondeling { get; set; }
    }
}
