namespace OrdinaMTech.Cv.Data.Models
{
    public class Cv
    {
        public int Id { get; set; }

        public virtual Personalia? Personalia { get; set; }

        public virtual IEnumerable<Opleiding>? Opleidingen { get; set; }
        
        public virtual IEnumerable<Cursus>? Cursussen { get; set; }

        public virtual IEnumerable<Ervaring>? Werkervaring { get; set; }
        
        public virtual IEnumerable<Taal>? Talen { get; set; }

        public virtual IEnumerable<Kennis>? Kennis { get; set; }
    }
}