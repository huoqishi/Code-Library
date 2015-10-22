using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using ForWeChat.BaseClass;

namespace ForWeChat.RequestClass
{
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class RequestText:BaseMessage
    {
        public RequestText()
        {
            Content = string.Empty;
        }
        public string Content { get; set; }
    }
}