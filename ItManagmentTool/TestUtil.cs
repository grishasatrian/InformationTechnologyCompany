using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public class TestUtil
    {
        static HashSet<string> emailNameSet = new HashSet<string>();
        static HashSet<string> phoneNumberSet = new HashSet<string>();
        // Minimum valid applicant age
        static byte APPLICANT_MIN_AGE = 18;
        // Maximum valid applicant age
        static byte APPLICANT_MAX_AGE = 70;

        static readonly string[] firstNames = { "Sevak", "Nina", "Grisha", "Karine",
            "Arevshat", "Margarita", "Karen", "Smbat", "Rouben", "Garegin",
            "Narine", "Nane", "Marina", "Suren", "Anna", "Mane", "Arman" };

        public static string GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        /// <summary>Generates random date of birth values within the specified age range.</summary>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>The DateTime value within specified range.</returns>
        public static DateTime GetDateOfBirth(byte minAge, byte maxAge)
        {
            // input's validation: check age limits, make sure their within
            // the allowed range

            minAge = Math.Max(APPLICANT_MIN_AGE, minAge);
            maxAge = Math.Min(APPLICANT_MAX_AGE, maxAge);

            var rand = new Random();
            DateTime currentDateTime = DateTime.Now;
            //DateTime date1 = DateTime.Now;
            //DateTime date2 = DateTime.UtcNow;
            //DateTime date3 = DateTime.Today;

            int applicantAge = rand.Next(minAge, maxAge + 1);
            int year = currentDateTime.Year - applicantAge;
            int month = rand.Next(1, 13);
            int day;
            if (month == 2)
            {
                day = rand.Next(1, 29);
            }
            else
            {
                day = rand.Next(1, 31);
            }
            DateTime applicantDateOfBirth = new DateTime(year, month, day);
            return new DateTime(year, month, day);
        }

        public static string GetRandomString(int size)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 97)));
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        public static string GetRandomUppercase(int size = 1)
        {
            StringBuilder upperCase = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                upperCase.Append(ch);
            }
            return upperCase.ToString();
        }

        public static string GetRandomLastName(string ending, int size)
        {
            string randomLastName = GetRandomUppercase() + GetRandomString(size) + ending;
            return randomLastName;
        }

        public static string GetRandomStringOfSymbols(int size)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(74 * random.NextDouble() + 48)));
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        public static string GetRandomEmail(int size = 10)
        {
            int attemptCount = 0;
            string randomEmail;
            do
            {
                randomEmail = GetRandomStringOfSymbols(size) + NameDomen.EndOfEmail();
                attemptCount++;
                if (attemptCount > 100)
                {
                    randomEmail = "";
                    break;
                }
            } while (emailNameSet.Contains(randomEmail));

            emailNameSet.Add(randomEmail);
            return randomEmail;
        }

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue);
        }

        public static string GetRandomPhoneNumber(string countryCode, int country)
        {
            int attemptCount = 0;
            var random = new Random();
            int[] array = new int[country];
            string phoneNumber = "";

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetRandomNumber(0, 9);
                phoneNumber += array[i];
            }
            do
            {
                phoneNumber = countryCode + OperatorCode.Operator() + phoneNumber;
                attemptCount++;
                if (attemptCount > 100)
                {
                    phoneNumber = "";
                    break;
                }
            } while (phoneNumberSet.Contains(phoneNumber));

            phoneNumberSet.Add(phoneNumber);
            return phoneNumber;
        }

        public static string GetFirstName()
        {
            var rand = new Random();
            int index = rand.Next(0, firstNames.Length);
            string firstName = firstNames[index];

            return firstName;
        }
    }
}
