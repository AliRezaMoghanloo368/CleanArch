using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Encrypter;
using CleanArch.Domain.Models;
using CleanArch.Mvc.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace CleanArch.Mvc.xUnitTest
{
    public class AccountControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IEncrypter> _mockEncrypter;

        public AccountControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockEncrypter = new Mock<IEncrypter>();
        }

        [Fact]
        public async Task Register_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var controller = new AccountController(_mockUserService.Object, _mockEncrypter.Object);
            controller.ModelState.AddModelError("UserName", "Required");
            var registerVm = new RegisterViewModel();

            // Act
            var result = await controller.Register(registerVm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(registerVm, viewResult.Model);
        }

        [Fact]
        public async Task Register_Post_UserNameExists_ReturnsViewWithModelError()
        {
            // Arrange
            var controller = new AccountController(_mockUserService.Object, _mockEncrypter.Object);
            var registerVm = new RegisterViewModel { UserName = "testuser" };
            _mockUserService.Setup(s => s.CheckWithUserName(It.IsAny<string>())).Returns(true);

            // Act
            var result = await controller.Register(registerVm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey("UserName"));
        }

        [Fact]
        public async Task Register_Post_ValidUser_CallsRegisterAsyncAndReturnsSuccessView()
        {
            // Arrange
            var controller = new AccountController(_mockUserService.Object, _mockEncrypter.Object);
            var registerVm = new RegisterViewModel { UserName = "newuser", PhoneNumber = "123456", Password = "pass" };
            _mockUserService.Setup(s => s.CheckWithUserName(It.IsAny<string>())).Returns(false);
            _mockUserService.Setup(s => s.RegisterAsync(It.IsAny<User>(), false)).Returns(Task.CompletedTask);

            // Act
            var result = await controller.Register(registerVm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("SuccessRegister", viewResult.ViewName);
            Assert.Equal(registerVm, viewResult.Model);
            _mockUserService.Verify(s => s.RegisterAsync(It.Is<User>(u => u.Name == "newuser"), false), Times.Once);
        }

        [Fact]
        public void Login_Post_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var controller = new AccountController(_mockUserService.Object, _mockEncrypter.Object);
            controller.ModelState.AddModelError("UserName", "Required");
            var loginVm = new LoginViewModel();

            // Act
            var result = controller.Login(loginVm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(loginVm, viewResult.Model);
        }

        [Fact]
        public void Login_Post_UserNotFoundOrPasswordInvalid_ReturnsViewWithModelError()
        {
            // Arrange
            var controller = new AccountController(_mockUserService.Object, _mockEncrypter.Object);
            var loginVm = new LoginViewModel { UserName = "test", Password = "pass" };
            _mockUserService.Setup(s => s.GetWithUserName(It.IsAny<string>())).Returns((User)null);

            // Act
            var result = controller.Login(loginVm);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.True(controller.ModelState.ContainsKey("UserName"));
        }
    }
}
