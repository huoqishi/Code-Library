using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ForWeChat;
using System.Configuration;
using Huoqishi.ISC;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ForWeChat
{
    public class UpdateAccessToken
    {
        //private static string appId;
        private static string AppId
        {
            get { return ConfigurationManager.AppSettings["AppId"]; }
        }
        //appsecret
        private static string AppSecret = ConfigurationManager.AppSettings["AppSecret"];

        //获取accesstoken的时间
        private static DateTime GetAccessToken_Time;

        /// <summary>
        /// 过期时间为7200秒
        /// </summary>
        private static int Expires_Period = 7200;

        /// <summary>
        /// 
        /// </summary>
        private static string mAccessToken = string.Empty;

        /// <summary>
        /// AccessToken值，会自动更新，设为静态，不需要存储在数据库
        /// </summary>
        public static string AccessToken
        {
            get
            {
                //如果为空，或者过期，需要重新获取
                if (string.IsNullOrEmpty(mAccessToken) || IsExpired())
                {
                    //获取
                    mAccessToken = GetAccessToken(AppId, AppSecret);
                }

                return mAccessToken;
            }
            set
            {
                mAccessToken = value;
            }
        }

        /// <summary>
        /// 获取accesstoken
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private static string GetAccessToken(string appId, string appSecret)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret);
            string result = MyHttpUtility.SendGetHttpRequest(url);
            //using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/assets/log/log.txt", true, Encoding.UTF8))
            //{
            //    writer.WriteLine(DateTime.Now + ":" + "获取一次Token");
            //}            
            JObject jobj = JObject.Parse(result);
            //{"access_token":"ACCESS_TOKEN","expires_in":7200}
            var tempAccess = (string)jobj["access_token"] ?? string.Empty;
            var expires_in = (int)jobj["expires_in"];
            //if (string.IsNullOrEmpty(mAccessToken))
            //{
            //    return string.Empty;
            //}
            GetAccessToken_Time = DateTime.Now;
            Expires_Period = expires_in;
            //return "已经未缓存，或缓存过期，请重新获取---" + result + "--" + tempAccess + "--" + IsExpired();
            return tempAccess;
        }

        /// <summary>
        /// 判断Access_token是否过期
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsExpired()
        {
            if (GetAccessToken_Time != null)
            {
                //过期时间，允许有一定的误差，一分钟。获取时间消耗
                TimeSpan ts = DateTime.Now - GetAccessToken_Time;
                if (ts.TotalSeconds >= Expires_Period)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
