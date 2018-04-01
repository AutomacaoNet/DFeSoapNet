using System.Xml;
using DFeSoapNet.Http;

namespace DFeSoapNet.Wsdl
{
    public abstract class DFeSoapHttpClientProtocol
    {
        protected string Invoke(DFeSoapConfig soapConfig)
        {
            var xmlRetorno = RequestWS.EnviaSefaz(soapConfig);

            return xmlRetorno;
        }

        protected virtual string GetTagConverter(string ret, string tag)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(new System.IO.StringReader(ret));
            XmlNodeList xmlList = doc.GetElementsByTagName(tag);
            var xmlConverter = xmlList[0].OuterXml;
            return xmlConverter;
        }
    }
}
