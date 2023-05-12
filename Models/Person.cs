namespace CPSC1517_Ex03_MihiriKamiss.Models
{
    public class Person
    {

        //private member fields
        private DateTime _dateOfBirth;
        private string _name;

        //properties
        public int CurrentAge
        {
            get { return AgeOn(DateTime.Now); }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("invalid date: birthdate cannot be in the future.");
                }
                else
                {
                    _dateOfBirth = value;
                }
            } //placeholder
        }

        public string Name
        {
            get { return _name; }
            set {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("value is empty");
                }
                else
                {
                    _name = value;
                }
            } 
        }

        //methods
        public int AgeOn(DateTime onDate)
        {
            int ageOnDate;
            TimeSpan dateDifference = onDate.Subtract(DateOfBirth);
            ageOnDate = dateDifference.Days / 365;
            return ageOnDate;
        }

        public string AstrologicalSign()
        {
            string sign;
            int month = DateOfBirth.Month,
                day = DateOfBirth.Day;

            if (month == 3 && day >= 21 || month == 4 && day <= 19)
            {
                sign = "Aries";
            }
            else if (month == 4 && day >= 20 || month == 5 && day <= 20)
            {
                sign = "Taurus";
            }
            else if (month == 5 && day >= 21 || month == 6 && day <= 21)
            {
                sign = "Gemini";
            }
            else if (month == 6 && day >= 22 || month == 7 && day <= 22)
            {
                sign = "Cancer";
            }
            else if (month == 7 && day >= 23 || month == 8 && day <= 22)
            {
                sign = "Leo";
            }
            else if (month == 8 && day >= 23 || month == 9 && day <= 22)
            {
                sign = "Virgo";
            }
            else if (month == 9 && day >= 23 || month == 10 && day <= 22)
            {
                sign = "Libra";
            }
            else if (month == 10 && day >= 23 || month == 11 && day <= 22)
            {
                sign = "Scorpio";
            }
            else if (month == 11 && day >= 23 || month == 12 && day <= 21)
            {
                sign = "Sagittarius";
            }
            else if (month == 12 && day >= 22 || month == 1 && day <= 19)
            {
                sign = "Capricorn";
            }
            else if (month == 1 && day >= 20 || month == 2 && day <= 18)
            {
                sign = "Aquarius";
            }
            else
            {
                sign = "Pisces";
            }

            return sign;
        }

        public string ChineseZodiac()
        {
            int year = DateOfBirth.Year;
            string zodiac;

            if (year % 12 == 0)
            {
                zodiac = "Monkey";
            }
            else if (year % 12 == 1)
            {
                zodiac = "Rooster";
            }
            else if (year % 12 == 2)
            {
                zodiac = "Dog";
            }
            else if (year % 12 == 3)
            {
                zodiac = "Pig";
            }
            else if (year % 12 == 4)
            {
                zodiac = "Rat";
            }
            else if (year % 12 == 5)
            {
                zodiac = "Ox";
            }
            else if (year % 12 == 6)
            {
                zodiac = "Tiger";
            }
            else if (year % 12 == 7)
            {
                zodiac = "Rabbit";
            }
            else if (year % 12 == 8)
            {
                zodiac = "Dragon";
            }
            else if (year % 12 == 9)
            {
                zodiac = "Snake";
            }
            else if (year % 12 == 10)
            {
                zodiac = "Horse";
            }
            else
            {
                zodiac = "Sheep";
            }

            return zodiac;
        }

        //contructors
        public Person(string name, DateTime birthDate)
        {
            Name = name;
            DateOfBirth = birthDate;
        }//end of Person

        public Person()
        {
            Name = "Mihiri Kamiss";
            DateOfBirth = new DateTime(2004, 04, 14);
        }
    }
}
