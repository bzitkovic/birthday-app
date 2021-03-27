using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayLibrary
{
    public static class GlobalConfig
    {
        public static ILogin Login { get; private set; } = new LoginLogic();

        public static IBirthday Birthday { get; private set; } = new BirthdayLogic();
    }
}
