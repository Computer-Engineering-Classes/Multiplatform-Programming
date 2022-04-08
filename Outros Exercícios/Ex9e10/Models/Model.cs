using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Ex9e10.Models
{
    public class Model
    {
        public List<Canal> Canais { get; init; }

        public Model()
        {
            Canais = new List<Canal>();
        }

        public void AdicionarCanal(string uri)
        {
            XmlReader reader = XmlReader.Create(uri);
            XDocument document = XDocument.Load(reader);
            XElement element = document.Root.Element("channel");
            Canal canal = new(element.Element("title").Value,
                element.Element("link").Value,
                element.Element("description").Value);
            var elements = from item in element.Descendants("item") select item;
            foreach (XElement fields in elements)
            {
                Noticia noticia = new(
                    fields.Element("title").Value,
                fields.Element("link").Value,
                Convert.ToDateTime(fields.Element("pubDate").Value),
                fields.Element("description").Value);
                canal.AdicionaNoticia(noticia);
            }
            Canais.Add(canal);
        }
    }
}
