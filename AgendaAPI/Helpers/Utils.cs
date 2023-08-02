using System.Text.RegularExpressions;
using System.Net.Mail;

namespace AgendaAPI.Helpers
{
    public class Utils
    {
        public static bool IsValidEmailAddress(string emailAddress)
        {
            var trimmedEmail = emailAddress.Trim();

            if (emailAddress is null)
                return false;

            if (string.IsNullOrEmpty(trimmedEmail))
                return false;

            if (trimmedEmail.EndsWith("."))
                return false;

            try
            {
                var addr = new MailAddress(emailAddress);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var trimmedPhoneNumber = phoneNumber.Trim();

            if (string.IsNullOrEmpty(trimmedPhoneNumber))
                return false;                   

            // (81) 99999-9999
            string brazilianPatternOnly = @"^\(?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{4})$";

            if (trimmedPhoneNumber is not null)
                return Regex.IsMatch(trimmedPhoneNumber, brazilianPatternOnly);
            else
                return false;
        }

        public static bool IsDigitsOnly(string phoneNumber)
        {
            var trimmedPhoneNumber = phoneNumber.Trim();

            if (string.IsNullOrEmpty(trimmedPhoneNumber))
                return false;

            if (trimmedPhoneNumber is not null)
            {
                foreach (char character in trimmedPhoneNumber)
                {
                    if (character < '0' || character > '9')
                        return false;
                }
                return true;
            }
            return false;            
        }
    }
}
