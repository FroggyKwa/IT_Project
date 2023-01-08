

using domain.Logic.Interfaces;
using Domain.Logic.Interfaces;
using Domain.UseCases;

namespace Tests
{
    public class UserTest
    {
        private readonly Mock<IUserRepository> _mock;
        private readonly UserInteractor _service;

        public UserTest()
        {
            _mock = new Mock<IUserRepository>();
            _service = new UserInteractor(_mock.Object);
        }

        [Fact]
        public void UserNotFound()
        {
            var result = _service.GetUserByLogin(String.Empty);

            Assert.Equal("Login error", result.Error);
            Assert.True(result.isFailure);

            _mock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                .Returns(() => null);
            result = _service.GetUserByLogin("qwertyuiop");
            Assert.Equal("User not found", result.Error);
            Assert.True(result.isFailure);
        }

        [Fact]
        public void SignUpWithEmpty()
        {
            var result = _service.Register(new User(1, "123", "123", string.Empty, "123"));

            Assert.True(result.isFailure);
            Assert.Equal("Empty username", result.Error);
        }

        [Fact]
        public void SignUpAlreadyExists()
        {
            _mock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                .Returns(() => new User(0, "a", "a", "a", "a"));

            var result = _service.Register(new User(1, "a", "a", "a", "a"));

            Assert.True(result.isFailure);
            Assert.Equal("User with this username already exists", result.Error);
        }

        [Fact]
        public void EmptyPassword()
        {
            var user = new User(1, "123", "123", "123", "");
            var check = user.IsValid();
            Assert.Equal("Empty password", check.Error);
            Assert.True(check.isFailure);
        }
        [Fact]
        public void EmptyUsername()
        {
            var user = new User(2, "123", "123", "", "123");
            var check = user.IsValid();
            Assert.Equal("Empty username", check.Error);
            Assert.True(check.isFailure);
        }
        [Fact]
        public void EmptyPhone()
        {
            var user = new User(3, "", "123",  "123", "123");
            var check = user.IsValid();
            Assert.Equal("Empty phone number", check.Error);
            Assert.True(check.isFailure);
        }
        [Fact]
        public void EmptyFullname()
        {
            var user = new User(4, "123", "", "123", "123");
            var check = user.IsValid();
            Assert.Equal("Empty fullname", check.Error);
            Assert.True(check.isFailure);
        }

    }
}
