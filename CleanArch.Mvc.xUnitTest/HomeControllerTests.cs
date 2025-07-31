using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CleanArch.Mvc.xUnitTest
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithUserViewModel()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var mockUserService = new Mock<IUserService>();

            // ساخت یک نمونه UserViewModel فرضی برای بازگشت توسط IUserService
            var expectedModel = new UserViewModel
            {
                // مقداردهی خصوصیات مدل در صورت نیاز
            };

            // تنظیم Mock برای متد GetUsers (که احتمالا async هست)
            mockUserService.Setup(s => s.GetUsers()).ReturnsAsync(expectedModel);

            // ساخت کنترلر با mock ها
            var controller = new HomeController(mockLogger.Object, mockUserService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType<UserViewModel>(result.Model);
            Assert.Equal(expectedModel, result.Model);
        }
    }
}