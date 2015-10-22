using ForWeChat;
using Huoqishi.ISC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wdage.ldd.WeChat
{
    /// <summary>
    /// 微信用户管理，用户信息管理
    /// </summary>
    public class UserManage
    {

        #region 获取已关注的用户列表，单次获取最多10000条 +string GetUserList(string next_openid = "")
        /// <summary>
        /// 获取已关注的用户列表，单次获取最多10000条
        /// </summary>
        /// <param name="next_openid"></param>
        /// <returns></returns>
        public string GetUserList(string next_openid = "")
        {
            //https://api.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&next_openid=NEXT_OPENID
            var url = string.Empty;
            var accessToken = UpdateAccessToken.AccessToken;
            if (string.IsNullOrEmpty(next_openid))
            {
                url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}", accessToken, next_openid);
            }
            return MyHttpUtility.SendGetHttpRequest(url);
            /// {
            ///  "total":23000,
            ///  "count":10000,
            ///  "data":{"
            ///     openid":[
            ///        "OPENID1",
            ///        "OPENID2",
            ///        ...,
            ///        "OPENID10000"
            ///     ]
            ///   },
            ///   "next_openid":"NEXT_OPENID1"
            ///  }
        } 
        #endregion

        #region 根据openId获取用户详细信息 +GetUserDetail(string openId = "")
        /// <summary>
        /// 根据openId获取用户详细信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public static string GetUserDetail(string openId = "")
        {
            if (openId == string.Empty)
            {
                return "null";
            }
            var accessToken = UpdateAccessToken.AccessToken;
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", accessToken, openId);
            return MyHttpUtility.SendGetHttpRequest(url);

            /// {
            //    "subscribe": 1, 
            //    "openid": "o6_bmjrPTlm6_2sgVt7hMZOPfL2M", 
            //    "nickname": "Band", 
            //    "sex": 1, 
            //    "language": "zh_CN", 
            //    "city": "广州", 
            //    "province": "广东", 
            //    "country": "中国", 
            //    "headimgurl":    "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0", 
            //    "subscribe_time": 1382694957,
            //    "unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL"
            //    "remark": "",
            //    "groupid": 0
            //}
        } 
        #endregion
    }
}
