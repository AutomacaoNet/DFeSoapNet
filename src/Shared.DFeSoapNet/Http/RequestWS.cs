﻿using System;
using System.IO;
using System.Net;
using System.Text;
using DFeSoapNet.Wsdl;
using Shared.DFeSoapNet.Http;

namespace DFeSoapNet.Http
{
    public class RequestWS
    {
        public static string EnviaSefaz(DFeSoapConfig soapConfig)
        {
            try
            {
                string XMLRetorno = string.Empty;
                string xmlSoap = Envelope.Construir(soapConfig);

                Uri uri = new Uri(soapConfig.Url);

                WebRequest webRequest = WebRequest.Create(uri);
                HttpWebRequest httpWR = (HttpWebRequest)webRequest;
                httpWR.Timeout = soapConfig.TimeOut == 0 ? 2000 : soapConfig.TimeOut;

                httpWR.ContentLength = Encoding.UTF8.GetBytes(xmlSoap).Length;

                httpWR.ClientCertificates.Add(soapConfig.Certificado);

                httpWR.ComposeContentType("application/soap+xml", Encoding.UTF8, soapConfig.Metodo);

                httpWR.Method = "POST";

                Stream reqStream = httpWR.GetRequestStream();
                StreamWriter streamWriter = new StreamWriter(reqStream);
                streamWriter.Write(xmlSoap, 0, Encoding.UTF8.GetBytes(xmlSoap).Length);
                streamWriter.Close();

                WebResponse webResponse = httpWR.GetResponse();
                Stream respStream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(respStream);

                XMLRetorno = streamReader.ReadToEnd();

                return XMLRetorno;
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
                throw;
            }
        }
    }
}
