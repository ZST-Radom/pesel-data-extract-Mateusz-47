using System;

namespace SD.pesel
{
    public class PersonId
    {
        private readonly string _id;

        public PersonId(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 11)
            {
                throw new ArgumentException("PESEL musi mieć 11 znaków.");
            }
            _id = id;
        }

        public int GetYear()
        {
            int year = int.Parse(_id.Substring(0, 2)); 
            int month = int.Parse(_id.Substring(2, 2)); 


            if (month > 20)
            {
                year += 2000;
            }
            else
            {
                year += 1900;
            }

            return year;
        }

 
        public int GetMonth()
        {
            int month = int.Parse(_id.Substring(2, 2)); 

         
            if (month > 20)
            {
                month -= 20;
            }

            return month;
        }


        public int GetDay()
        {
            return int.Parse(_id.Substring(4, 2)); 
        }

        public int GetYearOfBirth()
        {
            return GetYear();
        }


        public string GetGender()
        {
            int genderDigit = int.Parse(_id.Substring(9, 1));
            return genderDigit % 2 == 0 ? "f" : "m";
        }
        public bool IsValid()
        {
            
            if (_id.Length != 11 || !long.TryParse(_id, out _))
            {
                return false;
            }

            int[] weight = new int[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += (int.Parse(_id[i].ToString()) * weight[i]);
            }

            int controlDigit = (10 - (sum % 10)) % 10;
            int lastDigit = int.Parse(_id[10].ToString());

            return controlDigit == lastDigit;
        }
    }
}
