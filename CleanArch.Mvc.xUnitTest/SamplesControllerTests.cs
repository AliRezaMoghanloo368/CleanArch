using CleanArch.Application.ViewModels;
using CleanArch.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.xUnitTest
{
    public class SamplesControllerTests
    {
        [Fact]
        public void ProgramSamples_ReturnsViewResult_WithListOfCartViewModel()
        {
            // Arrange
            var controller = new SamplesController();

            // Act
            var result = controller.ProgramSamples();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<CartViewModel>>(viewResult.Model);
            Assert.Equal(4, model.Count);

            //// Optional: Check specific values if needed
            //Assert.Contains(model, c => c.Title == "اپلیکیشن تحت ویندوز ERP");
            //Assert.Contains(model, c => c.ToolsName.Contains("Blazor"));
        }
    }
}
