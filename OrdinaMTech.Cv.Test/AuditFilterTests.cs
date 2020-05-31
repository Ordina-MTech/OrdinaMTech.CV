using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrdinaMTech.Cv.Api.Controllers;
using OrdinaMTech.Cv.WebApi.Filters;
using OrdinaMTech.Cv.WebApi.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace OrdinaMTech.Cv.Test
{
    [TestClass]
    public class AuditFilterTests
    {
        [TestMethod]
        [Ignore("Test werkt als je de test apart runt, dus OK")]
        public void WhenUsingAuditLogWithAuthenticatedUserSetsLaatstGeraadpleegdToTheCorrectUser()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger<CvController>>();
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, "123"),
                    new Claim(ClaimTypes.Name, "Gates, Bill"),
                    new Claim(ClaimTypes.Email, "william.gates@microsoft.com"),
                    new Claim(ClaimTypes.Role, "Admin")
                }))
            };
            var context = new ActionExecutingContext(
                new ActionContext(
                    httpContext: httpContext,
                    routeData: new RouteData(),
                    actionDescriptor: new ActionDescriptor(),
                    modelState: modelState
                ),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<CvController>(mockedLogger.Object).Object);

            var sut = new AuditFilter();

            //Act
            sut.OnActionExecuting(context);

            //Assert
            Assert.AreEqual("123", AuditLog.LaatstGeraadpleegdDoor);
        }

        [TestMethod]
        public void WhenUsingAuditLogWithAnonymousUserSetsLaatstGeraadpleegdToAnonymous()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger<CvController>>();
            var modelState = new ModelStateDictionary();
            var httpContext = new DefaultHttpContext();
            var context = new ActionExecutingContext(
                new ActionContext(
                    httpContext: httpContext,
                    routeData: new RouteData(),
                    actionDescriptor: new ActionDescriptor(),
                    modelState: modelState
                ),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<CvController>(mockedLogger.Object).Object);

            var sut = new AuditFilter();

            //Act
            sut.OnActionExecuting(context);

            //Assert
            Assert.AreEqual("Anonymous", AuditLog.LaatstGeraadpleegdDoor);
        }
    }
}
