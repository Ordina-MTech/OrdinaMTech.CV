using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using OrdinaMTech.Cv.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Net;

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
        /// Upload een nieuwe foto van max. 500kB
        /// </summary>
        /// <param name="file">De nieuwe foto</param>
        [HttpPost]
        [Route("personalia/foto/upload")]
        public IActionResult Upload([FromForm]IFormFile file)
        {
            var maxSize = 1024 * 500;
            if (file.Length > maxSize)
            {
                return new UnprocessableEntityObjectResult("Bestand mag niet groter zijn dan " + maxSize / 1024 + "kB");
            }

            var cv = new Models.Cv();
            cv.Load();
            using var fileStream = file.OpenReadStream();
            var contents = new byte[file.Length];
            for (var i = 0; i < file.Length; i++)
            {
                contents[i] = (byte)fileStream.ReadByte();
            }
            cv.Personalia.Foto = contents;
            cv.Save();
            return Ok();
        }

        [AuditFilter]
        /// <summary>
        /// Vraag het CV op
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var result = new Models.Cv();
            result.Load();
            return Ok(result);
        }

        /// <summary>
        /// Reset het CV naar de defaults
        /// </summary>
        [HttpPut]
        public IActionResult Put()
        {
            var cv = new Models.Cv();

            cv.Personalia = new Models.Personalia()
            {
                Naam = "Denise Oostdam",
                Geboortedatum = new DateTime(1995, 1, 13),
                Hobbies = "Gamen, tafeltennis",
                Woonplaats = "Utrecht",
                Foto = System.IO.File.ReadAllBytes("pasfoto.png")
            };

            cv.Opleidingen = new List<Models.Opleiding>();
            cv.Opleidingen.Add(new Models.Opleiding { id = 1, School = "St. Gregorius College Utrecht", Niveau = "VWO", Diploma = true, DatumVan = new DateTime(2007, 9, 1), DatumTm = new DateTime(2013, 6, 1) });
            cv.Opleidingen.Add(new Models.Opleiding { id = 2, School = "Hogeschool Utrecht Informatica", Niveau = "HBO", Diploma = true, DatumVan = new DateTime(2013, 9, 1), DatumTm = new DateTime(2018, 3, 1) });

            cv.Cursussen = new List<Models.Cursus>();
            cv.Cursussen.Add(new Models.Cursus { id = 1, Naam = "AZ-203 Developing Solutions for Microsot Azure", Instituut = "Microsoft", Certificaat = true, Datum = new DateTime(2020, 1, 24) });
            cv.Cursussen.Add(new Models.Cursus { id = 2, Naam = "Scrum Foundation", Instituut = "Scrum.org", Certificaat = true, Datum = new DateTime(2019, 5, 15) });

            cv.Werkervaring = new List<Models.Ervaring>();
            cv.Werkervaring.Add(new Models.Ervaring { id = 1, Functie = "Stagiaire", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV application in .NET Core en ReactJS.", Organisatie = "FutureTech", DatumVan = new DateTime(2017, 9, 1), DatumTm = new DateTime(2018, 1, 31) });
            cv.Werkervaring.Add(new Models.Ervaring { id = 2, Functie = "Junior .NET developer", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV applicatie in Azure", Organisatie = "MTech", DatumVan = new DateTime(2018, 4, 1), DatumTm = null });

            cv.Talen = new List<Models.Taal>();
            cv.Talen.Add(new Models.Taal() { id = 1, Naam = "Nederlands", Mondeling = Enums.Taalniveau.Excellent, Schriftelijk = Enums.Taalniveau.Excellent });
            cv.Talen.Add(new Models.Taal() { id = 2, Naam = "Engels", Mondeling = Enums.Taalniveau.Goed, Schriftelijk = Enums.Taalniveau.Goed });

            cv.Kennis = new List<Models.Kennis>();
            cv.Kennis.Add(new Models.Kennis() { id = 1, Kennisgebied = "Scrum", Jaren = 2, Kennisniveau = Enums.Kennisniveau.Gemiddeld });
            cv.Kennis.Add(new Models.Kennis() { id = 2, Kennisgebied = "C#", Jaren = 3, Kennisniveau = Enums.Kennisniveau.Ervaren });
            cv.Kennis.Add(new Models.Kennis() { id = 3, Kennisgebied = "ReactJS", Jaren = 1, Kennisniveau = Enums.Kennisniveau.Basiskennis });
            cv.Kennis.Add(new Models.Kennis() { id = 4, Kennisgebied = "Azure", Jaren = 2, Kennisniveau = Enums.Kennisniveau.Gemiddeld });

            cv.Save();

            return Ok(cv);
        }
    }
}