using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using HumanForce.Services;
using Xunit;

namespace HumanForce.Tests
{
    public class JiraTicketServiceTests
    {
        public JiraTicketServiceTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _sut = _fixture.Create<JiraTicketService>();
        }

        private readonly IFixture _fixture;
        private readonly JiraTicketService _sut;

        [Fact]
        public void ShouldReturenTicketsWhenCallingGetTickets()
        {
            var result = _sut.GetTickets();
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldReturenSprintsWhenCallingGetSprints()
        {
            var result = _sut.GetSprints();
            Assert.NotNull(result);
        }
    }
}
