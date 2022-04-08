using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Teste2
{
    public class Browser
    {
        public string Nome { get; private set; }

        public int Info { get; private set; }

        public Browser(string nome, int info)
        {
            Nome = nome;
            Info = info;
        }
    }

    public delegate void MethodWithoutArg();

    public interface IEstrutura
    {
        public List<Browser> ListaEntidades { get; }

        public event MethodWithoutArg TarefaTerminada;

        public void FluxoDados();

        public void Pesquisa();
    }

    public class Implementacao : IEstrutura
    {
        public List<Browser> ListaEntidades { get; private set; }

        public event MethodWithoutArg TarefaTerminada;

        public Implementacao()
        {
            ListaEntidades = new List<Browser>();
        }

        public void FluxoDados()
        {
            XDocument document = XDocument.Load("browsers.xml");
            var collection = from element in document.Element("Browsers").Descendants("browser") 
                             select element;
            foreach (XElement element in collection)
            {
                Browser browser = new Browser(element.Element("Nome").Value, 
                                              Convert.ToInt32(element.Element("Info").Value));
                ListaEntidades.Add(browser);
            }
            TarefaTerminada?.Invoke();
        }

        public void Pesquisa()
        {
            if (ListaEntidades.Count != 0)
            {
                var infos = from browser in ListaEntidades
                            orderby browser.Info ascending
                            select browser.Info;
                int minimo = infos.First();

                var collection = from browser in ListaEntidades
                                 where browser.Info == minimo
                                 select browser;
                if (collection.Count() != 0)
                {
                    TarefaTerminada?.Invoke();
                }
                else
                {
                    throw new PesquisaException("A pesquisa não encontrou nenhuma entidade.");
                }
            }
        }
    }

    public class PesquisaException : ApplicationException
    {
        public PesquisaException(string message) : base(message)
        {
        }
    }
}
