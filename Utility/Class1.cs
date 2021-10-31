using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Utility
{
    public class ValidationModel
    {
        public static bool InputValidation(string input)
        {
            bool status = false;
            IPAddress ip;
            bool ValidateIP = IPAddress.TryParse(input, out ip);
            if (!ValidateIP)
            {
                status = IsValidURL(input);
            }
            return status;
        }
        public static bool IsValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }

    }
}
