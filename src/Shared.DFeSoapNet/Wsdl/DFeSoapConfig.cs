using System.Security.Cryptography.X509Certificates;

namespace DFeSoapNet.Wsdl
{
    public class DFeSoapConfig
    {
        public DFeCabecalho DFeCabecalho { get; set; }

        public DFeCorpo DFeCorpo { get; set; }

        public string Url { get; set; }

        public int TimeOut { get; set; }

        public string Metodo { get; set; }

        public X509Certificate2 Certificado { get; set; }
    }
}
