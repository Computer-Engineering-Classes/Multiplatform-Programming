using System.Collections;
using System.Collections.Generic;

namespace WPF_Ex8._1
{
    public class Escola : IEnumerable
    {
        public string Nome { get; private set; }

        private readonly List<Curso> Cursos;

        public Escola(string nome)
        {
            Nome = nome;
            Cursos = new List<Curso>();
        }

        public void Init()
        {
            Cursos.Add(new Curso("Engenharia Informática", 120));
            Cursos.Add(new Curso("Engenharia Mecânica", 50));
            Cursos.Add(new Curso("Engenharia Civil", 10));
        }

        public int GetNAlunos(int index)
        {
            return Cursos[index].NAlunos;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Cursos.Count; i++)
            {
                yield return Cursos[i];
            }
        }
    }
}
