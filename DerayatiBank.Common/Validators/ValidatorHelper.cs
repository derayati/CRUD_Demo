using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DerayatiBank.Common
{
    public static class ValidatorHelper
    {
        public static bool EmailIsValid(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool AccuntNumberIsValid(string input)
        {
            string[] splited = input.Split('-');
            if (splited.Length != 4) splited = input.Split(' ');
            for (int i = 0; i < splited.Length; i++)
            {
                if (splited[i].Length != 4) return false;
                for (int j = 0; j < 4; j++)
                    if (splited[i][j] > 57 || splited[i][j] < 48) return false;
            }
            return true;
        }

        
        private static readonly PhoneNumberUtil PhoneUtil = PhoneNumberUtil.GetInstance();
        public static bool PhoneNumberIsValid(string localphone,string region)
        {
            var phoneno = PhoneUtil.Parse(localphone, region);
            return PhoneUtil.IsValidNumber(phoneno);
        }
    }
}
