using Shouldly;
using AutoFixture;
using AutoFixture.AutoMoq;
using AgendaAPI.Services;
using AgendaAPI.ViewModels;

public class AuthServiceTests
{
    private readonly IFixture _fixture;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());   
        _authService = _fixture.Create<AuthService>();
    }
   
    [Fact]
    public void Login_InvalidEmail_ThrowsArgumentException()
    {
        // Arrange
        var loginUser = _fixture.Create<LoginUserViewModel>();
        loginUser.Email = "invalidEmail@test.com."; 

        // Act and Assert
        Should.Throw<ArgumentException>(() => _authService.Login(loginUser))
            .Message.ShouldBe("Invalid Email Address!");
    }

    [Fact]
    public void Register_InvalidEmail_ThrowsArgumentException()
    {
        // Arrange
        var registerUser = _fixture.Create<RegisterUserViewModel>();
        registerUser.Email = "invalidEmail@test.com."; 

        // Act and Assert
        Should.Throw<ArgumentException>(() => _authService.Register(registerUser))
            .Message.ShouldBe("Invalid Email Address!");
    }
}
