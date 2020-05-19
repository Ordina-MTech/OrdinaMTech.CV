using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace OrdinaMTech.Cv.Api.Models
{
    public class Cv
    {
        public Personalia Personalia { get; set; }

        public List<Opleiding> Opleidingen { get; set; }
        
        public List<Cursus> Cursussen { get; set; }

        public List<Ervaring> Werkervaring { get; set; }
        
        public List<Taal> Talen { get; set; }

        public List<Kennis> Kennis { get; set; }

        public void Save()
        {
            File.WriteAllText("cv.json", JsonConvert.SerializeObject(this));
        }

        public void Load()
        {
            var cv = JsonConvert.DeserializeObject<Cv>(File.ReadAllText("cv.json"));
            Personalia = cv.Personalia;
            Opleidingen = cv.Opleidingen;
            Cursussen = cv.Cursussen;
            Werkervaring = cv.Werkervaring;
            Talen = cv.Talen;
            Kennis = cv.Kennis;
        }
    }
}