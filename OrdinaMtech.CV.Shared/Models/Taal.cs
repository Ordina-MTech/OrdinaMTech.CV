using OrdinaMTech.Cv.Shared.Enums;

namespace OrdinaMTech.Cv.Shared.Models
{
    public class Taal
    {
        public int id { get; set; }
        public string Naam { get; set; }
        public Taalniveau Schriftelijk {get; set; }
        public Taalniveau Mondeling { get; set; }
    }
}
