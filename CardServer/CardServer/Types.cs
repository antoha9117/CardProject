using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardServer
{
    class Types
    {
        public static TempPlayerRec[] TempPlayer = new TempPlayerRec[Constants.MAX_PLAYER];  
        public struct TempPlayerRec
        {
            public ByteBuffer Buffer;
            public long DataBytes;
            public long DataPackets;
        }
    }
}
