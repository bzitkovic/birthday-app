using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayLibrary
{
    public class LoginLogic : ILogin
    {
        public User LoginUser(User user)
        {          
            using (var context = new BirthdaysEntities())
            {
                foreach (User u in context.Users)
                {
                    if (u.Username == user.Username && u.Password == user.Password)
                    {
                        return u;
                    }
                }
            }

            return null;
        }

        public void RegisterUser(User user)
        {
            using (var context = new BirthdaysEntities())
            {
                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}
