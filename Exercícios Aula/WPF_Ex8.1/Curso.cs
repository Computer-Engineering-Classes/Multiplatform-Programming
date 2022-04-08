namespace WPF_Ex8._1
{
    public class Curso
    {
        public string Nome { get; private set; }

        public int NAlunos { get; private set; }

        public Curso(string nome, int nalunos)
        {
            Nome = nome;
            NAlunos = nalunos;
        }
    }
}
