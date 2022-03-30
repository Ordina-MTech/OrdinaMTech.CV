using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrdinaMTech.Cv.Shared.Enums;
using OrdinaMTech.Cv.Shared.Models;
using OrdinaMTech.Cv.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;

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
                var bmp = ResizeImage(new Bitmap(fileStream));
                var converter = new ImageConverter();
                var contents = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                var cv = new Shared.Models.Cv();
                Load(cv);
                cv.Personalia.Foto = contents;
                Save(cv);
                return Ok(contents);
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
            var result = new Shared.Models.Cv();
            Load(result);
            return Ok(result);
        }

        /// <summary>
        /// Reset het CV naar de defaults
        /// </summary>
        [HttpPut]
        public IActionResult Put()
        {
            var cv = new Shared.Models.Cv();

            cv.Personalia = new Personalia()
            {
                Naam = "Denise Oostdam",
                Geboortedatum = new DateTime(1995, 1, 13),
                Hobbies = "Gamen, tafeltennis",
                Woonplaats = "Utrecht",
                Foto = System.IO.File.ReadAllBytes("pasfoto.png")
            };

            cv.Opleidingen = new List<Opleiding>();
            cv.Opleidingen.Add(new Opleiding { Id = 1, School = "St. Gregorius College Utrecht", Niveau = "VWO", Diploma = true, DatumVan = new DateTime(2007, 9, 1), DatumTm = new DateTime(2013, 6, 1) });
            cv.Opleidingen.Add(new Opleiding { Id = 2, School = "Hogeschool Utrecht Informatica", Niveau = "HBO", Diploma = true, DatumVan = new DateTime(2013, 9, 1), DatumTm = new DateTime(2018, 3, 1) });

            cv.Cursussen = new List<Cursus>();
            cv.Cursussen.Add(new Cursus { Id = 1, Naam = "AZ-203 Developing Solutions for Microsot Azure", Instituut = "Microsoft", Certificaat = true, Datum = new DateTime(2020, 1, 24) });
            cv.Cursussen.Add(new Cursus { Id = 2, Naam = "Scrum Foundation", Instituut = "Scrum.org", Certificaat = true, Datum = new DateTime(2019, 5, 15) });

            cv.Werkervaring = new List<Ervaring>();
            cv.Werkervaring.Add(new Ervaring { Id = 1, Functie = "Stagiaire", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV application in .NET Core en ReactJS.", Organisatie = "FutureTech", DatumVan = new DateTime(2017, 9, 1), DatumTm = new DateTime(2018, 1, 31) });
            cv.Werkervaring.Add(new Ervaring { Id = 2, Functie = "Junior .NET developer", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV applicatie in Azure", Organisatie = "MTech", DatumVan = new DateTime(2018, 4, 1), DatumTm = null });

            cv.Talen = new List<Taal>();
            cv.Talen.Add(new Taal() { Id = 1, Naam = "Nederlands", Mondeling = Taalniveau.Excellent, Schriftelijk = Taalniveau.Excellent });
            cv.Talen.Add(new Taal() { Id = 2, Naam = "Engels", Mondeling = Taalniveau.Goed, Schriftelijk = Taalniveau.Goed });

            cv.Kennis = new List<Kennis>();
            cv.Kennis.Add(new Kennis() { Id = 1, Kennisgebied = "Scrum", Jaren = 2, Kennisniveau = Kennisniveau.Gemiddeld });
            cv.Kennis.Add(new Kennis() { Id = 2, Kennisgebied = "C#", Jaren = 3, Kennisniveau = Kennisniveau.Ervaren });
            cv.Kennis.Add(new Kennis() { Id = 3, Kennisgebied = "ReactJS", Jaren = 1, Kennisniveau = Kennisniveau.Basiskennis });
            cv.Kennis.Add(new Kennis() { Id = 4, Kennisgebied = "Azure", Jaren = 2, Kennisniveau = Kennisniveau.Gemiddeld });

            Save(cv);

            return Ok(cv);
        }

        private void Save(Shared.Models.Cv cv)
        {
            System.IO.File.WriteAllText("cv.json", JsonConvert.SerializeObject(cv));
        }

        private void Load(Shared.Models.Cv cv)
        {
            var data = JsonConvert.DeserializeObject<Shared.Models.Cv>(System.IO.File.ReadAllText("cv.json"));
            cv.Personalia = data.Personalia;
            cv.Opleidingen = data.Opleidingen;
            cv.Cursussen = data.Cursussen;
            cv.Werkervaring = data.Werkervaring;
            cv.Talen = data.Talen;
            cv.Kennis = data.Kennis;
        }

        private Bitmap ResizeImage(Bitmap src)
        {
            var bmp = new Bitmap(300, 300);
            var g = Graphics.FromImage(bmp);

            var scale = Math.Max((float)src.Width / 300.0f, (float)src.Height / 300.0f);
            var p = new PointF(300.0f - ((float)src.Width / scale), 300.0f - ((float)src.Height / scale));
            var size = new SizeF((float)src.Width / scale, (float)src.Height / scale);

            g.DrawImage(src, new RectangleF(p, size));

            return bmp;
        }
    }
}