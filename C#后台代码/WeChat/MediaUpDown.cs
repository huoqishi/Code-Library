using ForWeChat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wdage.ldd.WeChat
{
    public class MediaUpDown
    {
        /// <summary>
        /// 请求微信图片文件，并保存到本地，get请求,
        /// </summary>
        /// <param name="media_ID"></param>
        /// <returns></returns>
        public string GetImg(string media_ID)
        {
            var access_token = UpdateAccessToken.AccessToken;
            var url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", access_token, media_ID);
            WebRequest request = (WebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "image/jpeg";
            var filepath=string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                if (response != null)
                {
                    var relpath = "assets/img/upload/";
                    using (Stream reader = response.GetResponseStream())
                    {

                        string s = response.Headers["Content-disposition"];
                        var start = s.IndexOf("\"");
                        var end = s.LastIndexOf("\"");
                        var filename = s.Substring(start+1, end - start-1);
                        relpath += filename;
                        filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,relpath );
                        using (FileStream writer = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            byte[] buff = new byte[1024];
                            int len = 0;
                            while ((len = reader.Read(buff, 0, buff.Length)) > 0)
                            {
                                writer.Write(buff, 0, len);
                            }
                        }

                    }
                    return '/' + relpath;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
