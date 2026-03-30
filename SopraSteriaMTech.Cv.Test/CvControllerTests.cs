using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SopraSteriaMTech.Cv.Test;

[TestClass]
public class CvControllerTests
{
    [TestMethod]
    public void GettingBasePageReturnsHttpStatusOk()
    {
        // Arrange
        var cvService = Substitute.For<ICvService>();
        cvService.GetCv().Returns(new Data.Models.Cv());

        var controller = new CvController(cvService);

        // Act
        var response = controller.Get() as OkObjectResult;

        // Assert
        Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
    }
}
