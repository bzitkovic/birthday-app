using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayLibrary
{
    public class BirthdayLogic : IBirthday
    {
        public void CreateNewBirthday(Birthday birthday)
        {
            using (var context = new BirthdaysEntities())
            {
                context.Birthdays.Add(birthday);

                context.SaveChanges();
            }
        }

        public void DeleteBirthday(Birthday birthday)
        {
            using (var context = new BirthdaysEntities())
            {
                var birthdayToDelete = context.Birthdays.SingleOrDefault(x => x.Id == birthday.Id);

                if (birthdayToDelete != null)
                {
                    context.Birthdays.Remove(birthdayToDelete);
                }

                context.SaveChanges();
            }
        }

        public List<Birthday> FilterBirthdaysByMonth(string month)
        {
            List<Birthday> birthdays = new List<Birthday>();

            int monthNumber;

            switch (month)
            {
                case "January":
                    monthNumber = 1;
                    break;
                case "February":
                    monthNumber = 2;
                    break;
                case "March":
                    monthNumber = 3;
                    break;
                case "April":
                    monthNumber = 4;
                    break;
                case "May":
                    monthNumber = 5;
                    break;
                case "June":
                    monthNumber = 6;
                    break;
                case "July":
                    monthNumber = 7;
                    break;
                case "August":
                    monthNumber = 8;
                    break;
                case "September":
                    monthNumber = 9;
                    break;
                case "October":
                    monthNumber = 10;
                    break;
                case "November":
                    monthNumber = 11;
                    break;
                case "December":
                    monthNumber = 12;
                    break;
                default:
                    monthNumber = 0;
                    break;
            }

            using (var context = new BirthdaysEntities())
            {
                var query = from b in context.Birthdays
                            where b.Date_Of_Birthday.Month == monthNumber
                            select b;

                if(query.Count() == 0)
                {
                    return context.Birthdays.ToList();
                }
                else
                {
                    return query.ToList();
                }               
            }
        }

        public List<Birthday> GetAllBirthdays(User user)
        {
            using (var context = new BirthdaysEntities())
            {
                List<Birthday> birthdays = new List<Birthday>();

                foreach (Birthday birthday in context.Birthdays)
                {
                    if (birthday.User_Id == user.Id)
                    {
                        birthdays.Add(birthday);
                    }
                }

                return birthdays;
            }
        }

        public void UpdateBirthday(Birthday birthday)
        {
            using (var context = new BirthdaysEntities())
            {             
                var birthdayToUpdate = context.Birthdays.SingleOrDefault(x => x.Id == birthday.Id);

                if (birthdayToUpdate != null)
                {
                    birthdayToUpdate.Name = birthday.Name;
                    birthdayToUpdate.Surname = birthday.Surname;
                    birthdayToUpdate.Date_Of_Birthday = birthday.Date_Of_Birthday;
                    birthdayToUpdate.Remark = birthday.Remark;
                    birthdayToUpdate.User_Id = birthday.User_Id;
                }

                context.SaveChanges();
            }
        }
    }
}
