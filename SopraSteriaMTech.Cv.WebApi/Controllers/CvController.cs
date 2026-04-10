using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace SopraSteriaMTech.Cv.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CvController(ICvService cvService) : ControllerBase
{
    private readonly ICvService _cvService = cvService;

    /// <summary>
    /// Upload een nieuwe foto van max. 2000kB
    /// </summary>
    /// <param name="file">De nieuwe foto</param>
    [HttpPost]
    [Route("personalia/foto/upload")]
    public IActionResult Upload([FromForm] FileUploadModel fileModel)
    {
        var maxSize = 1024 * 2000;
        if (fileModel.File.Length > maxSize)
        {
            return new UnprocessableEntityObjectResult("Bestand mag niet groter zijn dan " + maxSize / 1024 + "kB");
        }

        try
        {
            using var fileStream = fileModel.File.OpenReadStream();
            using var image = Image.Load(fileStream);
            var output = new MemoryStream();

            image.Mutate(o => o.Resize(new Size(300, 300)));
            image.SaveAsBmp(output);

            var cv = _cvService.GetCv();
            if (cv == null)
                return NotFound();

            cv.Personalia!.Foto = output.ToArray();

            _cvService.Update(cv);

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
        var result = _cvService.GetCv();
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Reset het CV naar de defaults
    /// </summary>
    [HttpPut]
    public IActionResult Reset()
    {
        _cvService.Reset();
        var cv = _cvService.GetCv();
        return Ok(cv);
    }

}