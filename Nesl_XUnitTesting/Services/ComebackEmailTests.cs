using AutoFixture;
using FluentAssertions;
using Nesl_assessment.EmailService;
using Nesl_assessment.Interfaces;
using Nesl_assessment.Logging;
using Nesl_assessment.MailMessageService;
using NSubstitute;

namespace Nesl_XUnitTesting.Services
{
    public class ComebackEmailTests : IClassFixture<MapperFixture>
    {
        private readonly MapperFixture mapperFixture;
        private readonly ComeBackEmailService comebackEmail;
        private readonly IMail mail;
        private readonly IMailService mailService;
        private readonly IFixture fixture = new Fixture();
        private readonly ILogService logService;

        public ComebackEmailTests(MapperFixture mapperFixture)
        {
            this.mapperFixture = mapperFixture;
            this.mail = Substitute.For<IMail>();
            this.comebackEmail = new ComeBackEmailService(this.mailService, this.logService);
        }

        [Theory]
        [InlineData(true, "testemail12@gmail.com", "EOComebackToUs")]
        [InlineData(false, "testemail123@gmail.com", "")]
        public async Task SendEmail_ShouldReturnCorrectResponse(bool assume, string customerEmail, string voucherCode)
        {
            var finalResult = await this.mail.SendEmail(customerEmail, voucherCode).ConfigureAwait(false);
            finalResult.Should().Be(assume);
        }
    }
}
