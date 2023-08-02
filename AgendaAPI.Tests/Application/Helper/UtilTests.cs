using Shouldly;
using AutoFixture;
using AgendaAPI.Helpers;

namespace AgendaAPI.Tests.Application.Helper
{
    public class UtilTests
    {      
        public UtilTests()
        {            
        }

        [Theory]
        [InlineData("john.doe@example.com", true)]
        [InlineData("user@example.", false)] 
        [InlineData("user@.example.com", false)] 
        [InlineData("invalidemail.com", false)] 
        [InlineData("", false)]
        public void IsValidEmailAddress_ValidatesEmailAddresses(string emailAddress, bool expectedResult)
        {
            // Act
            var result = Utils.IsValidEmailAddress(emailAddress);

            // Assert
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData("(81)99999-9999", true)]
        [InlineData("(11)12345-6789", true)]
        [InlineData("(99)87654-3210", true)]
        [InlineData("(81)9999-9999", false)] 
        [InlineData("(81)99999-99999", false)] 
        [InlineData("", false)] 
        public void IsValidPhoneNumber_ValidatesBrazilianPhoneNumbers(string phoneNumber, bool expectedResult)
        {
            // Act
            var result = Utils.IsValidPhoneNumber(phoneNumber);

            // Assert
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData("1234567890", true)]
        [InlineData("987654321", true)] 
        [InlineData("abcdefg", false)]
        [InlineData("", false)] 
        public void IsDigitsOnly_ValidatesDigitsOnly(string input, bool expectedResult)
        {
            // Act
            var result = Utils.IsDigitsOnly(input);

            // Assert
            result.ShouldBe(expectedResult);
        }
    }
}
