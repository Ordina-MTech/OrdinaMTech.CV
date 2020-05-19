using OrdinaMTech.Cv.Api.Enums;

namespace OrdinaMTech.Cv.Api.Models
{
    public class Taal
    {
        public int id { get; set; }
        public string Naam { get; set; }
        public Taalniveau Schriftelijk {get; set; }
        public Taalniveau Mondeling { get; set; }
    }
}
