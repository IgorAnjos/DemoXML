// See https://aka.ms/new-console-template for more information
using DemoXML;

Console.WriteLine("Hello, World!");


var nfe = ManipularXML.MapearXmlEmObjeto();
//Console.WriteLine(xml.OuterXml);

Console.WriteLine("serie " +nfe.Serie);
Console.WriteLine("numero  " +nfe.NumeroDaNota);
Console.WriteLine("data " +nfe.DataDeEmissao);
Console.WriteLine("valor " +nfe.ValorTotalDaNota);
