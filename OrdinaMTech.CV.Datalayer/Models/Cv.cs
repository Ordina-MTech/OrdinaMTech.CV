using System.Collections.Generic;

namespace OrdinaMTech.Cv.Data.Models
{
    public class Cv
    {
        public int Id { get; set; }

        public Personalia Personalia { get; set; }

        public List<Opleiding> Opleidingen { get; set; }
        
        public List<Cursus> Cursussen { get; set; }

        public List<Ervaring> Werkervaring { get; set; }
        
        public List<Taal> Talen { get; set; }

        public List<Kennis> Kennis { get; set; }
    }
}