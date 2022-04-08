using System.Collections.Generic;

namespace Ex9e10.Models
{
    public class Canal
    {
        public string Descricao { get; init; }

        public string Link { get; init; }

        public string Titulo { get; init; }

        public List<Noticia> Noticias { get; init; }

        public Canal(string titulo, string link, string descricao)
        {
            Titulo = titulo;
            Link = link;
            Descricao = descricao;
            Noticias = new List<Noticia>();
        }

        public void AdicionaNoticia(Noticia noticia)
        {
            Noticias.Add(noticia);
        }
    }
}
