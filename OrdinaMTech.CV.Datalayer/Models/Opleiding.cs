namespace OrdinaMTech.Cv.Data.Models
{
    public class Opleiding
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Niveau { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime DatumTm { get; set; }
        public bool Diploma { get; set; }
    }
}