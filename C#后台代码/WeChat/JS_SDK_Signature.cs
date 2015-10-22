using ForWeChat;
using Huoqishi.ISC;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Wdage.ldd.WeChat
{
    public class JS_SDK_Signature
    {
        private static string appId;
        private static string AppId
        {
            get { return ConfigurationManager.AppSettings["AppId"];}
            set { appId = value; }
        }
        private static string jsApi_Ticket;

        //获取jsapi_ticket的时间
        private static DateTime GetJS_SDK_Ticket_Time;

        /// <summary>
        /// 过期时间为7200秒
        /// </summary>
        private static int Expires_Period = 7200;

        /// <summary>
        /// js_sdk _ticket 获取不到返回null
        /// </summary>
        public static string JsApi_Ticket
        {
            get
            {
                if (!string.IsNullOrEmpty(jsApi_Ticket)&&!IsExpires)
                {
                    return jsApi_Ticket;
                }
                else
                {
                    var accessToken = UpdateAccessToken.AccessToken;
                    var url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", accessToken);
                    var result = MyHttpUtility.SendGetHttpRequest(url);
                    JObject jobj = JObject.Parse(result);
                    //{
                    //"errcode":0,
                    //"errmsg":"ok",
                    //"ticket":"bxLdikRXVbTPdHSM05e5u5sUoXNKd8-41ZO3MhKoyN5OfkWITDGgnr2fwJ0m9E8NYzWKVZvdVtaUgWvsdshFKA",
                    //"expires_in":7200
                    //}
                    var ticket = string.Empty;
                    try
                    {
                        ticket = (string)jobj["ticket"];
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                    jsApi_Ticket = ticket;
                    return ticket;
                }

            }
        }

        /// <summary>
        /// 判断ticket是否过期
        /// true 为已经过期
        /// </summary>
        public static  bool IsExpires
        {
            get
            {
                if (GetJS_SDK_Ticket_Time != null)
                {
                    //过期时间，允许有一定的误差，一分钟。获取时间消耗
                    TimeSpan ts = DateTime.Now - GetJS_SDK_Ticket_Time;

                    if (ts.Ticks / 10000 >= 7200)
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

        /// <summary>
        /// 获取计算后的js_sdk签名
        /// </summary>
        /// <param name="jsapi_ticket"></param>
        /// <param name="noncestr"></param>
        /// <param name="timestamp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static  string GetSignature(string jsapi_ticket, string noncestr, string timestamp, string url)
        {
            //jsapi_ticket=sM4AOVdWfPE4DxkXGEs8VMCPGGVi4C3VM0P37wVUCFvkVAy_90u5h9nbSlYy3-Sl-HhTdfl2fzFy1AOcHKP7qg&noncestr=Wm3WZYTPz0wzccnW&timestamp=1414587457&url=http://mp.weixin.qq.com
            string tmpStr=string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}",jsapi_ticket,noncestr,timestamp,url);

            //return FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            return FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
        }
    }
}
