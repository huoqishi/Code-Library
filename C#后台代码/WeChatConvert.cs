using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWeChat
{
    public static class WeChatConvert
    {
        public static int DateTimeToInt(this DateTime dt)
        {
            //int  year = dt.Year;
            //int month = dt.Month;
            //int day = dt.Day;
            //int sec = dt.Second;
            //long createTime = year;
            DateTime dtOld = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan ts = dt - dtOld;
            return (int)(ts.TotalSeconds);
        }
    }
}
