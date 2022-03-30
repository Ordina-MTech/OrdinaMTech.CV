using System;

namespace OrdinaMTech.Cv.Shared.Models
{
    public class Cursus
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Instituut { get; set; }
        public DateTime Datum { get; set; }
        public bool? Certificaat { get; set; }
    }
}
