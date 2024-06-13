using AutoFixture;
using FluentAssertions;
using Nesl_assessment.EmailService;
using Nesl_assessment.Interfaces;
using Nesl_assessment.Logging;
using Nesl_assessment.MailMessageService;
using NSubstitute;

namespace Nesl_XUnitTesting.Services
{
    public class WelcomeEmailTests
    {
        private readonly MapperFixture mapperFixture;
        private readonly WelcomeEmailService welcomeEmail;
        private readonly IMail mail;
        private readonly IMailService mailService;
        private readonly IFixture fixture = new Fixture();
        private readonly ILogService logService;
        public WelcomeEmailTests(MapperFixture mapperFixture)
        {
            this.mapperFixture = mapperFixture;
            this.mail = Substitute.For<IMail>();
            this.welcomeEmail = new WelcomeEmailService(this.mailService, this.logService);
        }

        [Theory]
        [InlineData(true, "testebad12@gmail.com")]
        [InlineData(false, "")]
        public async Task SendEmail_ShouldReturnCorrectResponse(bool assume, string customerEmail)
        {
            var finalResults = await this.welcomeEmail.SendEmail(customerEmail);
            finalResults.Should().Be(assume);
        }
    }
}
