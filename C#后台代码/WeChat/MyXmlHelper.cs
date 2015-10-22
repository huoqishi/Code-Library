using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ForWeChat
{
    public class MyXmlHelper
    {
        public static string ObjectToXml(object o)
        {
            StringWriter sw = new StringWriter();
            //创建XML命名空间
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            serializer.Serialize(sw, o, ns);
            sw.Close();
            return sw.ToString();
        }

        public static XDocument ParseJson(string json, string rootName)
        {
            return JsonConvert.DeserializeXNode(json, rootName);
        }
    }
}