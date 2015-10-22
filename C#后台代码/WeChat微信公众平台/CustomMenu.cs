using GRK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWeChat.WeChat
{
    public class CustomMenu
    {
        public static string accesstoken = UpdateAccessToken.AccessToken;
        public static string requestUrl="https://api.weixin.qq.com/cgi-bin/menu/create";

        /// <summary>
        /// 菜单文件路径
        /// </summary>
        private static readonly string Menu_Data_Path = System.AppDomain.CurrentDomain.BaseDirectory + "/data/menu.txt";
        
        /// <summary>
        /// 创建菜单
        /// </summary>
        public static string CreateMenu(string menu)
        {
            string url = string.Format(requestUrl+"?access_token={0}", accesstoken);
            //string menu = FileUtility.Read(Menu_Data_Path);
            return MyHttpUtility.SendPostHttpRequest(url, menu);
        }
    }
}
