using System;

namespace OrdinaMTech.Cv.Shared.Models
{
    public class Opleiding
    {
        public int id { get; set; }
        public string School { get; set; }
        public string Niveau { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime DatumTm { get; set; }
        public bool Diploma { get; set; }
    }
}