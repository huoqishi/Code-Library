using ForWeChat;
using Huoqishi.ISC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wdage.ldd.WeChat.RequestClass
{
    /// <summary>
    /// 获取微信服务器IP列表
    /// </summary>
    public class RequestWXIP
    {
        /// <summary>
        /// 获取微信服务器IP
        /// </summary>
        public static List<string> GetWxIP()
        {
            var accessToken = UpdateAccessToken.AccessToken;
            var ipList=MyHttpUtility.SendGetHttpRequest("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token="+accessToken);
            //{
            //    "ip_list":["127.0.0.1","127.0.0.1"]
            //}
            JObject jsonObj = JObject.Parse(ipList);

            List<string> list = new List<string>();

            //var ips=jsonObj["ip_list"];
            //for (int i = 0; i < ips.Count(); i++)
            //{
            //    list.Add(ips[i].ToString());
            //}
            if (list.Count<=0)
            {
                list.Add(ipList + "-----------" + accessToken);
            }
            return list;
        }

        public static string GetWxIPStr()
        {
            var accessToken = UpdateAccessToken.AccessToken;
            var ipList = MyHttpUtility.SendGetHttpRequest("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token=" + accessToken);
            return ipList;
        }
    }
}
