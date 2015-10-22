using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Configuration;
using ForWeChat;
using LOAF.DAL;
using GRK.DAL;

namespace GRK.MVCUI.Controllers
{
    public class WeChatController : Controller
    {
        //
        // GET: /WeChat/专门用于处理微信相关信息

        [HttpPost]
        public ActionResult Index()
        {
            string postString = string.Empty;
            string echoString = string.Empty;
            using (Stream stream = Request.InputStream)
            {
                Byte[] postBytes = new Byte[stream.Length];
                stream.Read(postBytes, 0, (Int32)stream.Length);
                postString = Encoding.UTF8.GetString(postBytes);
                //                    postString = @"<xml>
                //<ToUserName><![CDATA[toUser]]></ToUserName>
                //<FromUserName><![CDATA[fromUser]]></FromUserName>
                //<CreateTime>1348831860</CreateTime>
                //<MsgType><![CDATA[image]]></MsgType>
                //<PicUrl><![CDATA[this is a url]]></PicUrl>
                //<MediaId><![CDATA[media_id]]></MediaId>
                //<MsgId>1234567890123456</MsgId>
                //</xml>";
            }

            if (!string.IsNullOrEmpty(postString))
            {
                //执行一些操作
                echoString = Execute(postString);
                //Response.Write("123");
            }
            return Content(echoString);
        }

        [HttpGet]
        public ActionResult Index(string echostr, string signature, string timestamp)
        {
            //string echoString = context.Request["echostr"]==null?"kf":context.Request["echostr"].ToString();
            //string sql = "insert into wxapi(`echostr`) values(?ec)";
            //MySqlParameter p = new MySqlParameter("?ec", echoString);
            //MysqlHelper.ExecuteNonQuery(sql,p);
            //context.Response.Write(echoString);
            //context.Response.Flush();
            //context.Response.End();
            return Content(Auth(echostr, signature, timestamp)); //微信接入的测试
        }
        public ActionResult Action()
        {
            return View();
        }

        /////////////////////////////////////////////////////////私有方法/////////////////////////////////////////////////////

        /// <summary>
        /// 成为开发者的第一步，验证并相应服务器的数据
        /// </summary>
        private string Auth(string echostr, string signature, string timestamp)
        {
            string token = ConfigurationManager.AppSettings["WeChatToken"];//从配置文件获取Token
            if (string.IsNullOrEmpty(token))
            {
                //LogTextHelper.Error(string.Format("WeixinToken 配置项没有配置！"));
            }
            //string signature = Request.QueryString["signature"];
            //string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];

            if (new BasicApi().CheckSignature(token, signature, timestamp, nonce))
            {
                if (!string.IsNullOrEmpty(echostr))
                {
                    return echostr;
                }
            }

            return null;
        }

        /// <summary>
        /// 处理各种请求信息并应答（通过POST的请求）
        /// </summary>
        /// <param name="postStr">POST方式提交的数据</param>
        /// <returns></returns>
        private string Execute(string postStr)
        {
            //MysqlHelper.ExecuteNonQuery("insert into wxapi(`echostr`) values('121')");
            WeChatApiDispatch dispatch = new WeChatApiDispatch();
            string responseContent = string.Empty;
            responseContent = dispatch.Execute(postStr);
            Response.ContentEncoding = Encoding.UTF8;
            return responseContent;

            //ResponseMsg(postStr);
        }

        public ActionResult OAuth2_0()
        {
            string appid = "wxcdea02d8372e5cf3";
            string redirect_uri = "http://grk.ichuizhi.com";
            string response_type = "code";
            string scope = "snsapi_base";
            string state = "1";
            string url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={3}#wechat_redirect", redirect_uri, response_type, scope, state);
            string s = @"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxcdea02d8372e5cf3&redirect_uri=http://grk.ichuizhi.com&response_type=code&scope=snsapi_base&state=1#wechat_redirect";
            return Content("");
        }
    }
}
