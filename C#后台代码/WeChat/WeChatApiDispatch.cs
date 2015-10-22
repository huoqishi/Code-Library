using ForWeChat.RequestClass;
using ForWeChat.ResponseClass;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Wdage.ldd.WeChat;

namespace ForWeChat
{
    /// <summary>
    /// 入口
    /// </summary>
    public class WeChatApiDispatch
    {
        //public HttpResponseBase Response { get; }

        // //public WeChatApiDispatch()
        // {

        // }
        /// <summary>
        /// 微信信息xml格式
        ///<xml>
        ///<ToUserName><![CDATA[toUser]]></ToUserName>
        ///<FromUserName><![CDATA[fromUser]]></FromUserName>
        ///<CreateTime>1348831860</CreateTime>
        ///<MsgType><![CDATA[image]]></MsgType>
        ///<PicUrl><![CDATA[this is a url]]></PicUrl>
        ///<MediaId><![CDATA[media_id]]></MediaId>
        ///<MsgId>1234567890123456</MsgId>
        ///</xml>
        /// </summary>
        /// <param name="postStr"></param>
        /// <returns></returns>
        public string Execute(string postStr)
        {
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(postStr);

            XmlElement rootElement = doc.DocumentElement;

            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");

            //RequestXML requestXML = new RequestXML();
            string ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;

            string FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;

            string CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;

            string msgType = MsgType.InnerText;

            string resxml = string.Empty;

            string replyMsg = string.Empty;

            string defaultMsg = string.Empty;

            //u3.Temp("全局XML数据："+postStr);
            switch (msgType.ToLower())
            {
                case "event":
                    #region 事件消息
                    string eventType = rootElement.SelectSingleNode("Event").InnerText.ToLower();
                    switch (eventType)
                    {
                        case "subscribe": replyMsg = @"微动时代，勇闯天涯！"; break;
                        case "unsubscribe": break;
                        case "click":
                            //                            <xml>
                            //<ToUserName><![CDATA[toUser]]></ToUserName>
                            //<FromUserName><![CDATA[FromUser]]></FromUserName>
                            //<CreateTime>123456789</CreateTime>
                            //<MsgType><![CDATA[event]]></MsgType>
                            //<Event><![CDATA[CLICK]]></Event>
                            //<EventKey><![CDATA[EVENTKEY]]></EventKey>
                            //</xml>
                            var keyCode = rootElement.SelectSingleNode("EventKey").InnerText;
                            switch (keyCode)
                            {
                                case "wdage110":
                                    //GetBasicInfo getinfo = new GetBasicInfo();
                                    //var json=getinfo.GetUserInfo(FromUserName);
                                    //JObject j = JObject.Parse(json);
                                    //replyMsg = "<a href='http://ldd.ishuchang.net'>奇异世界！" + json + "</a>";
                                    break;
                                default:
                                    break;
                            }
                            var json = UserManage.GetUserDetail(FromUserName);
                                    JObject j = JObject.Parse(json);
                                    replyMsg = "<a href='http://ldd.ishuchang.net'>奇异世界！" + json + "</a>"+keyCode;
                            break;
                        case "location":
                            double Latitude = 0;
                            double Longitude = 0;
                            try
                            {
                                Latitude = rootElement.SelectSingleNode("Latitude").InnerText.ToDouble();
                                Longitude = rootElement.SelectSingleNode("Longitude").InnerText.ToDouble();
                            }
                            catch (Exception e)
                            {

                            } break;
                        default:
                            break;
                    }

                    #endregion
                    break;
                case "view":
                    break;
                case "text":
                    string content = rootElement.SelectSingleNode("Content").InnerText;
                    replyMsg = "<a href='http://ldd.ishuchang.net'>欢迎关注学生这些事，这里你想要的都有！</a>";

                    //文字消息
                    break;
                default:
                    replyMsg = "default" + msgType;
                    break;
            }


            #region 其他类型消息

            //                //无匹配消息
            //                resxml = @"<xml>
            //                                <ToUserName><![CDATA[" + FromUserName + @"]]></ToUserName>
            //                                <FromUserName><![CDATA[" + ToUserName + @"]]></FromUserName>
            //                                <CreateTime>" + DateTime.Now.DateTimeToInt() + @"</CreateTime>
            //                                <MsgType><![CDATA[text]]></MsgType>
            //                                <Content><![CDATA[" + defaultMsg + @"]></Content>
            //                                </xml>";
            //                //图文消息
            //                resxml = @"<xml>
            //                                    <ToUserName><![CDATA[" + FromUserName + @"]]></ToUserName>
            //                                    <FromUserName><![CDATA[" + ToUserName + @"]]></FromUserName>
            //                                    <CreateTime>" + DateTime.Now.DateTimeToInt() + @"</CreateTime>
            //                                    <MsgType><![CDATA[news]]></MsgType>
            //                                    <ArticleCount>1</ArticleCount>
            //                                    <Articles>
            //                                            <item>
            //                                                <Title><![CDATA[" + title + @"]]></Title>
            //                                                <Description><![CDATA[" + msg + @"]]></Description>
            //                                                <PicUrl><![CDATA[" + imgUrl + @"]]></PicUrl>
            //                                                <Url><![CDATA[" + url + @"]]></Url>
            //                                            </item>
            //                                    </Articles>
            //                                    </xml>";

            //                //关注后消息
            //                resxml = @"<xml>
            //                            <ToUserName><![CDATA[" + FromUserName + @"]]></ToUserName>
            //                            <FromUserName><![CDATA[" + ToUserName + @"]]></FromUserName>
            //                            <CreateTime>" + DateTime.Now.DateTimeToInt() + @"</CreateTime>
            //                            <MsgType><![CDATA[text]]></MsgType>
            //                            <Content><![CDATA[欢迎关注哦]]></Content>
            //                            </xml>"; 
            #endregion
            msgType = "222";
            resxml = @"<xml>
                                <ToUserName>
                                        <![CDATA[" + FromUserName + @"]]>
                                </ToUserName>
                                <FromUserName>
                                        <![CDATA[" + ToUserName + @"]]>
                                </FromUserName>
                                <CreateTime>
                                        " + DateTime.Now.DateTimeToInt() + @"
                                </CreateTime>
                                <MsgType>
                                        <![CDATA[text]]>
                                </MsgType>
                                <Content>
                                        <![CDATA[" + replyMsg + @"]]>
                                </Content></xml>";
            return resxml;

            //ResponseText response = new ResponseText(info);
            //response.Content = "抱歉，此功能暂未开通。";
            //result = response.ToXml();
        }
        private string ResponseMsg(string postStr)
        {

            ///这里写你的返回信息代码

            string resxml = "";

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(postStr);

            XmlElement rootElement = doc.DocumentElement;

            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");

            //RequestXML requestXML = new RequestXML();

            string ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;

            string FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;

            string CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;

            string MsgType1 = MsgType.InnerText;

            if (MsgType1 == "text")
            {

                string Content = rootElement.SelectSingleNode("Content").InnerText;

                if (Content.Trim() == "2")
                {

                    resxml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now.DateTimeToInt() + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[回复内容]]></Content></xml>";

                }

                else if (Content.Trim() == "一战到底")
                {

                    string url = "http://182.92.154.134/default.aspx?name=" + FromUserName;

                    resxml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now.DateTimeToInt() + "</CreateTime><MsgType><![CDATA[news]]></MsgType><MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles><item><Title><![CDATA[一站到底]]></Title><Description><![CDATA[测试版]]></Description><PicUrl><![CDATA[http://www.你的域名.com/image/wx_yzdd.jpg]]></PicUrl><Url><![CDATA[" + url + "]]></Url></item></Articles></xml>";

                }

                else
                {

                    resxml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now.DateTimeToInt() + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[回复其他内容回复]]></Content></xml>";

                }


                //Response.Write(resxml);

                return resxml;

            }

            else
            {

                resxml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now.DateTimeToInt() + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[欢迎关注哦]]></Content></xml>";

                //Current.Response.Write(resxml);

                return resxml;

            }

        }

        private string tempXMl(string aaa)
        {
            return @"<xml>
                                <ToUserName>
                                        <![CDATA[wxcdea02d8372e5cf3]]>
                                </ToUserName>
                                <FromUserName>
                                        <![CDATA[ov1YDs8pD1jFg026SGrr6V7ZAa8Q]]>
                                </FromUserName>
                                <CreateTime>
                                        " + DateTime.Now.DateTimeToInt() + @"
                                </CreateTime>
                                <MsgType>
                                        <![CDATA[text]]>
                                </MsgType>
                                <Content>
                                        <![CDATA[" + aaa + @"]]>
                                </Content></xml>";
        }
    }
}
