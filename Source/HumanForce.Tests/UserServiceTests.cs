using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using HumanForce.Services;
using Xunit;

namespace HumanForce.Tests
{
    public class UserServiceTests
    {
        public UserServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _sut = _fixture.Create<UserService>();
        }

        private readonly IFixture _fixture;
        private readonly UserService _sut;

        [Fact]
        public void ShouldReturenUsersWhenCallingGetUsers()
        {
            var result = _sut.GetUsers();
            Assert.NotNull(result);
        }
    }
}
