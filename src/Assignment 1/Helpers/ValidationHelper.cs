using System.Text.RegularExpressions;

namespace ContactManagerApp.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return Regex.IsMatch(name, @"^[a-zA-Z\s]{2,50}$");
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }
            return Regex.IsMatch(phoneNumber,@"^[0-9]{10}$");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            return Regex.IsMatch(email,@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidNotes(string notes)
        {
            return notes.Length <= 250;
        }
    }
}