using OrdinaMTech.Cv.Data.Enums;

namespace OrdinaMTech.Cv.Data.Models
{
    public class Taal
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Taalniveau Schriftelijk {get; set; }
        public Taalniveau Mondeling { get; set; }
    }
}
