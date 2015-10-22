using ForWeChat;
using Huoqishi.ISC;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wdage.Ldd.BLL;



namespace Wdage.ldd.WeChat
{
    /// <summary>
    /// 微信验证
    /// </summary>
    public class WxVerified
    {
        /// <summary>
        /// 该方法已经禁用
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <param name="userguid"></param>
        /// <returns></returns>
        public static string Verified(string code, string state, string userguid)
        {
            var appid=ConfigurationManager.AppSettings["AppId"];
            var appsecret=ConfigurationManager.AppSettings["AppSecret"];
            var accesstoken = UpdateAccessToken.AccessToken;
            //var accesstoken = string.Empty;
            var returnVal = string.Empty;
            List<string> listName = new List<string>{
                "刘欢","李瑜","silence","暖","Silenceping","王朝华","Yearn"
            };

            
            #region 获取openId
            var url =string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",appid,appsecret,code);
            var resultJson=MyHttpUtility.SendGetHttpRequest(url);
            //{
            //   "access_token":"ACCESS_TOKEN",
            //   "expires_in":7200,
            //   "refresh_token":"REFRESH_TOKEN",
            //   "openid":"OPENID",
            //   "scope":"SCOPE",
            //   "unionid": "o6_bmasdasdsad6_2sgVt7hMZOPfL"
            //}
            JObject jobj = JObject.Parse(resultJson);
            string openid=(string)jobj["openid"];
            if (string.IsNullOrEmpty(openid))
            {
                returnVal = "请在微信中打开\n";
                return returnVal;
            }
            #endregion

            #region 设置Session
            #endregion


            #region 获取基本信息：测试账号需要用户关注
            var url2 = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN",accesstoken,openid);
            var userinfo=MyHttpUtility.SendGetHttpRequest(url2);
            //{
            //    "subscribe": 1, 
            //    "openid": "o6_bmjrPTlm6_2sgVt7hMZOPfL2M", 
            //    "nickname": "Band", 
            //    "sex": 1, 
            //    "language": "zh_CN", 
            //    "city": "广州", 
            //    "province": "广东", 
            //    "country": "中国", 
            //    "headimgurl":    "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0", 
            //   "subscribe_time": 1382694957,
            //   "unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL"
            //   "remark": "",
            //   "groupid": 0
            //}
            //UserBll ubll = new UserBll();
            //ubll.SaveWXInfo(userinfo, userguid);//保存用户微信信息到数据库
            JObject juInfo = JObject.Parse(userinfo);
            var temp = juInfo["subscribe"];
            if (null==temp)
            {
                //获取不到用户信息
            }
            #endregion

            int subscribe = (int)temp;
            var nickname = (string)juInfo["nickname"];
            if (!listName.Contains(nickname))
            {
                returnVal ="内部版本，非1215成员暂时无法访问\n";
                return returnVal;
            }
            return returnVal;
        }

        #region 获取openid,获取不到时返回null +string GetOpenId(string code, string state)
        /// <summary>
        /// 获取openid,获取不到时返回null
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns>string openid</returns>
        public static string GetOpenId(string code, string state)
        {
            var appid = ConfigurationManager.AppSettings["AppId"];
            var appsecret = ConfigurationManager.AppSettings["AppSecret"];
            var accesstoken = UpdateAccessToken.AccessToken;

            #region 获取openId
            var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", appid, appsecret, code);
            var resultJson = MyHttpUtility.SendGetHttpRequest(url);
            //{
            //   "access_token":"ACCESS_TOKEN",
            //   "expires_in":7200,
            //   "refresh_token":"REFRESH_TOKEN",
            //   "openid":"OPENID",
            //   "scope":"SCOPE",
            //   "unionid": "o6_bmasdasdsad6_2sgVt7hMZOPfL"
            //}
            JObject jobj = JObject.Parse(resultJson);
            string openid = (string)jobj["openid"];
            if (openid==null)
            {
                return resultJson;
            }
            return openid;
            #endregion
        } 
        #endregion
    }
}
