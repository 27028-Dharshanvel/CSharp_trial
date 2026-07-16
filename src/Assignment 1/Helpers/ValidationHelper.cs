namespace ContactManagerApp.Helpers
{
    /// <summary>
    /// ValidationHelper
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// isvalidname
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>name.</returns>
        public static bool IsValidName(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < name.Length; i++)
            {
                char ch = name[i];

                if (!((ch >= 'A' && ch <= 'Z') ||
                      (ch >= 'a' && ch <= 'z') ||
                       ch == ' '))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Isvalidphonenumber
        /// </summary>
        /// <param name="phoneNumber">phonenumber</param>
        /// <returns>phoneNumber</returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false;
            }

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (phoneNumber[i] < '0' ||
                    phoneNumber[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// IsvalidEmail
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>email.</returns>
        public static bool IsValidEmail(string email)
        {
            bool atFound = false;
            bool dotFound = false;

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@')
                {
                    atFound = true;
                }

                if (email[i] == '.')
                {
                    dotFound = true;
                }
            }

            return atFound && dotFound;
        }
    }
}