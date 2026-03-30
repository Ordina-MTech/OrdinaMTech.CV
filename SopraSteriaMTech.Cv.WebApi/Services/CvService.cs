using Microsoft.EntityFrameworkCore;

namespace SopraSteriaMTech.Cv.WebApi.Services;

public class CvService(CvContext cvContext) : ICvService
{
    private readonly CvContext _cvContext = cvContext;

    public Data.Models.Cv? GetCv()
    {
        return _cvContext.Cvs.FirstOrDefault();
    }

    public void RemoveAllCvs()
    {
        var cvs = _cvContext.Cvs
            .Include(c => c.Kennis)
            .Include(c => c.Cursussen)
            .Include(c => c.Personalia)
            .Include(c => c.Talen)
            .Include(c => c.Werkervaring)
            .Include(c => c.Opleidingen);
        _cvContext.RemoveRange(cvs);
    }

    public void Update(Data.Models.Cv cv)
    {
        _cvContext.Update(cv);
        _cvContext.SaveChanges();
    }

    public void Reset()
    {
        var cv = GetCv();
        if (cv != null)
        {
            RemoveAllCvs();
        }
        cv = new Data.Models.Cv
        {
            Personalia = new()
            {
                Naam = "Denise Oostdam",
                Geboortedatum = new DateTime(1995, 1, 13),
                Hobbies = "Gamen, tafeltennis",
                Woonplaats = "Utrecht",
                Foto = File.ReadAllBytes("pasfoto.png")
            },
            Opleidingen =
            [
                new() { School = "St. Gregorius College Utrecht", Niveau = "VWO", Diploma = true, DatumVan = new DateTime(2007, 9, 1), DatumTm = new DateTime(2013, 6, 1) },
                new() { School = "Hogeschool Utrecht Informatica", Niveau = "HBO", Diploma = true, DatumVan = new DateTime(2013, 9, 1), DatumTm = new DateTime(2018, 3, 1) }
            ],
            Cursussen =
            [
                new() { Naam = "AZ-203 Developing Solutions for Microsot Azure", Instituut = "Microsoft", Certificaat = true, Datum = new DateTime(2020, 1, 24) },
                new() { Naam = "Scrum Foundation", Instituut = "Scrum.org", Certificaat = true, Datum = new DateTime(2019, 5, 15) }
            ],
            Werkervaring =
            [
                new() { Functie = "Stagiaire", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV application in .NET Core en ReactJS.", Organisatie = "FutureTech", DatumVan = new DateTime(2017, 9, 1), DatumTm = new DateTime(2018, 1, 31) },
                new() { Functie = "Junior .NET developer", Project = "Interne CV applicatie", Beschrijving = "Ontwerp en bouw van een interne CV applicatie in Azure", Organisatie = "MTech", DatumVan = new DateTime(2018, 4, 1), DatumTm = null }
            ],
            Talen =
            [
                new() { Naam = "Nederlands", Mondeling = Taalniveau.Excellent, Schriftelijk = Taalniveau.Excellent },
                new() { Naam = "Engels", Mondeling = Taalniveau.Goed, Schriftelijk = Taalniveau.Goed }
            ],
            Kennis =
            [
                new() { Kennisgebied = "Scrum", Jaren = 2, Kennisniveau = Kennisniveau.Gemiddeld },
                new() { Kennisgebied = "C#", Jaren = 3, Kennisniveau = Kennisniveau.Ervaren },
                new() { Kennisgebied = "ReactJS", Jaren = 1, Kennisniveau = Kennisniveau.Basiskennis },
                new() { Kennisgebied = "Azure", Jaren = 2, Kennisniveau = Kennisniveau.Gemiddeld }
            ]
        };
        Update(cv);
    }
}
