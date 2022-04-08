using System;

namespace Ex9e10.Models
{
    public class Noticia
    {
        public DateTime Data { get; init; }

        public string Descricao { get; init; }

        public string Link { get; init; }

        public string Titulo { get; init; }

        public Noticia(string titulo, string link, DateTime data, string descricao)
        {
            Titulo = titulo;
            Data = data;
            Link = link;
            Descricao = descricao;
        }
    }
}
