using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        private const int DefaultLenght = 9;
        private const string Pattern = @"^(?:-*\d-*){8}$";
        private PhoneNumber(string value) => Value = value;
        public string Value { get; set; }

        public static PhoneNumber? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLenght)
            {
                return null;
            }

            return new PhoneNumber(value);
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();

    }
}
