using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrdinaMTech.Cv.Data;
using OrdinaMTech.Cv.Data.Enums;
using OrdinaMTech.Cv.Data.Models;
using OrdinaMTech.Cv.WebApi.Filters;

namespace OrdinaMTech.Cv.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CvController : ControllerBase
    {
        private readonly ILogger<CvController> _logger;

        public CvController(ILogger<CvController> logger)
        {
            _logger = logger;            
        }

        /// <summary>
        /// Upload een nieuwe foto van max. 2000kB
        /// </summary>
        /// <param name="file">De nieuwe foto</param>
        [HttpPost]
        [Route("personalia/foto/upload")]
        public IActionResult Upload([FromForm]IFormFile file)
        {
            var maxSize = 1024 * 2000;
            if (file.Length > maxSize)
            {
                return new UnprocessableEntityObjectResult("Bestand mag niet groter zijn dan " + maxSize / 1024 + "kB");
            }
            
            try
            {
                using var fileStream = file.OpenReadStream();
                using var image = Image.Load(fileStream);
                var output = new MemoryStream();
                image.Mutate(c => c.Resize(300, 300));
                image.SaveAsBmp(output);

                var cv = new Data.Models.Cv();
                Load(cv);                
                cv.Personalia!.Foto = output.ToArray();
                Save(cv);                

                return Ok(cv.Personalia.Foto);
            }
            catch
            {
                return new UnprocessableEntityObjectResult("Bestand is geen geldig plaatje");
            }
        }

        /// <summary>
        /// Vraag het CV op
        /// </summary>
        [AuditFilter]
        [HttpGet]
        public IActionResult Get()
        {
            var result = new Data.Models.Cv();
            Load(result);
            return Ok(result);
        }

        /// <summary>
        /// Reset het CV naar de defaults
        /// </summary>
        [HttpPut]
        public IActionResult Put()
        {
            var cv = new Data.Models.Cv();
            cv.Personalia = new Personalia()
            {
                Naam = "Denise Oostdam",
                Geboortedatum = new DateTime(1995, 1, 13),
                Hobbies = "Gamen, tafeltennis",
                Woonplaats = "Utrecht",
                Foto = System.IO.File.ReadAllBytes("pasfoto.png")
            };

            cv.Opleidingen = new List<Opleiding>
            {
                new Opleiding { School = "St. Gregorius College Utrecht", Niveau = "VWO", Diploma = true, DatumVan = new DateTime(2007, 9, 1), DatumTm = new DateTime(2013, 6, 1) },
                new Opleiding { School = "Hogeschool Utrecht Informatica", Niveau = "HBO", Diploma = true, DatumVan = new DateTime(2013, 9, 1), DatumTm = new DateTime(2018, 3, 1) }
            };

            cv.Cursussen = new List<Cursus>
            {
                new Cursus { Naam = "AZ-203 Developing Solutions for Microsot Azure", Instituut = "Microsoft", Certificaat = true, Datum = new DateTime(2020, 1, 24) },
                new Cursus { Naam = "Scrum Foundation", Instituut = "Scrum.org", Certificaat = true, Datum = new DateTime(2019, 5, 15) }
            };

            cv.Werkervaring = new List<Ervaring>
            {
                new Ervaring { Functie = "Stagiaire", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV application in .NET Core en ReactJS.", Organisatie = "FutureTech", DatumVan = new DateTime(2017, 9, 1), DatumTm = new DateTime(2018, 1, 31) },
                new Ervaring { Functie = "Junior .NET developer", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV applicatie in Azure", Organisatie = "MTech", DatumVan = new DateTime(2018, 4, 1), DatumTm = null }
            };

            cv.Talen = new List<Taal>
            {
                new Taal() { Naam = "Nederlands", Mondeling = Taalniveau.Excellent, Schriftelijk = Taalniveau.Excellent },
                new Taal() { Naam = "Engels", Mondeling = Taalniveau.Goed, Schriftelijk = Taalniveau.Goed }
            };

            cv.Kennis = new List<Kennis>
            {
                new Kennis() { Kennisgebied = "Scrum", Jaren = 2, Kennisniveau = Kennisniveau.Gemiddeld },
                new Kennis() { Kennisgebied = "C#", Jaren = 3, Kennisniveau = Kennisniveau.Ervaren },
                new Kennis() { Kennisgebied = "ReactJS", Jaren = 1, Kennisniveau = Kennisniveau.Basiskennis },
                new Kennis() { Kennisgebied = "Azure", Jaren = 2, Kennisniveau = Kennisniveau.Gemiddeld }
            };

            Save(cv);

            return Ok(cv);
        }

        private static void Save(Data.Models.Cv cv)
        {
            System.IO.File.WriteAllText("cv.json", JsonConvert.SerializeObject(cv));
        }

        private static void Load(Data.Models.Cv cv)
        {
            var data = JsonConvert.DeserializeObject<Data.Models.Cv>(System.IO.File.ReadAllText("cv.json"));
            cv.Personalia = data?.Personalia;
            cv.Opleidingen = data?.Opleidingen;
            cv.Cursussen = data?.Cursussen;
            cv.Werkervaring = data?.Werkervaring;
            cv.Talen = data?.Talen;
            cv.Kennis = data?.Kennis;
        }
    }
}