using System.Xml;

namespace DemoXML
{
    public static class ManipularXML
    {
        static string caminho = @"C:\Users\ianjos\Desktop\xml.xml";
        public static XmlDocument Carregar(string caminho)
        {
            var xml = new XmlDocument();
            xml.Load(caminho);
            return xml;
        }

        public static NFe MapearXmlEmObjeto()
        {
            var nfe = new NFe();
            var xml = Carregar(caminho);

            var infNFe = xml.GetElementsByTagName("infNFe")[0];

            if (infNFe?.HasChildNodes is true)
            {
                var tags = infNFe?.ChildNodes.OfType<XmlNode>();
                if (tags?.FirstOrDefault(_ => _.Name == "ide")?.HasChildNodes is true)
                {
                    var ide = tags.FirstOrDefault(_ => _.Name == "ide")?.ChildNodes.OfType<XmlNode>();
                    nfe.Serie = ide?.FirstOrDefault(_ => _.Name == "serie")?.FirstChild?.Value;

                    if (int.TryParse(ide?.FirstOrDefault(_ => _.Name == "nNF")?.FirstChild?.Value, out int nNF))
                    {
                        nfe.NumeroDaNota = nNF;
                    }

                    if (DateTime.TryParse(ide?.FirstOrDefault(_ => _.Name == "dEmi")?.FirstChild?.Value, out DateTime dEmi))
                    {
                        nfe.DataDeEmissao = dEmi;
                    }

                    var total = tags?.FirstOrDefault(_ => _.Name == "total")?.ChildNodes.OfType<XmlNode>();

                    if (total?.FirstOrDefault(_ => _.Name == "ICMSTot")?.HasChildNodes is true)
                    {
                        var icmsTotal = total?.FirstOrDefault(_ => _.Name == "ICMSTot")?.ChildNodes.OfType<XmlNode>();

                        if (decimal.TryParse(icmsTotal.FirstOrDefault(_ => _.Name == "vNF")?.FirstChild?.Value, out decimal vNF))
                        {
                            nfe.ValorTotalDaNota = vNF;
                        }
                    }
                }
            }

            return nfe;
        }
    }
}
