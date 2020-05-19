using System;

namespace OrdinaMTech.Cv.Api.Models
{
    public class Cursus
    {
        public int id { get; set; }
        public string Naam { get; set; }
        public string Instituut { get; set; }
        public DateTime Datum { get; set; }
        public bool? Certificaat { get; set; }
    }
}
