using System.Collections;
using System.Collections.Generic;

namespace WPF_Ex8._1
{
    public class Universidade : IEnumerable
    {
        public string Nome { get; private set; }

        public readonly List<Escola> Escolas;

        public readonly List<Grau> Graus;

        public Universidade()
        {
            Escolas = new List<Escola>();
            Graus = new List<Grau>();
        }

        public void Init()
        {
            Escola escola;
            Grau grau;
            Nome = "Universidade Trás-os-Montes e Alto Douro";
            escola = new Escola("Escola de Ciências e Tecnologia");
            escola.Init();
            Escolas.Add(escola);
            escola = new Escola("Escola de Ciências Humanas e Sociais");
            escola.Init();
            Escolas.Add(escola);
            escola = new Escola("Escola de Ciências Agrárias e Veterinárias");
            escola.Init();
            Escolas.Add(escola);
            grau = new Grau("Licenciatura");
            grau.Init();
            Graus.Add(grau);
            grau = new Grau("Mestrado");
            grau.Init();
            Graus.Add(grau);
            grau = new Grau("Doutoramento");
            grau.Init();
            Graus.Add(grau);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Escolas.Count; i++)
            {
                yield return Escolas[i];
            }
        }

    }
}
