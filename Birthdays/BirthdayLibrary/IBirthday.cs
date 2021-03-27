using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayLibrary
{
    public interface IBirthday
    {
        void CreateNewBirthday(Birthday birthday);
        void UpdateBirthday(Birthday birthday);
        void DeleteBirthday(Birthday birthday);
        List<Birthday> GetAllBirthdays(User user);
        List<Birthday> FilterBirthdaysByMonth(string month);
    }
}
