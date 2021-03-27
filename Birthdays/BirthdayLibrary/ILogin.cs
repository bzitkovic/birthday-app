using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayLibrary
{
    public interface ILogin
    {
        void RegisterUser(User user);
        User LoginUser(User user);
    }
}
