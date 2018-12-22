using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardServer
{
    public enum ServerPackets
    {
        SWelcome = 1,
        SAlertMsg,

    }
    public enum ClientPackets
    {
        CRegisterAccount = 1,
        CLoginAccount,
    }
}
