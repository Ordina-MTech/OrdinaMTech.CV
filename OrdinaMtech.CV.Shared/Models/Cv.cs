using System.Collections.Generic;

namespace OrdinaMTech.Cv.Shared.Models
{
    public class Cv
    {
        public Personalia Personalia { get; set; }

        public List<Opleiding> Opleidingen { get; set; }
        
        public List<Cursus> Cursussen { get; set; }

        public List<Ervaring> Werkervaring { get; set; }
        
        public List<Taal> Talen { get; set; }

        public List<Kennis> Kennis { get; set; }
    }
}