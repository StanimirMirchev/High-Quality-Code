using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirthday { get; set; }

        public Student(string firstName, string lastName, string placeOfBirth, DateTime dateOfBirthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PlaceOfBirth = placeOfBirth;
            this.DateOfBirthday = dateOfBirthday;
        }
        public bool IsCurrentOlderThan(Student other)
        {
            int result = DateTime.Compare(this.DateOfBirthday, other.DateOfBirthday);
            if (result < 0)
            {
                return true;
            }
            else if (result == 0)
            {
                Console.WriteLine("The same time");
                return true;
            }
            else
            {
                return false;
            }

           // DateTime firstDate =
           //     DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
           // DateTime secondDate =
           //     DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
           // return firstDate > secondDate;
        }
    }
}
