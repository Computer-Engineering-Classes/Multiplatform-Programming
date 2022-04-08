namespace WPF_Ex8
{
    public class Departamento
    {
        public string Nome { get; private set; }

        public int NDocentes { get; private set; }

        public Departamento(string nome, int ndocentes)
        {
            Nome = nome;
            NDocentes = ndocentes;
        }
    }
}
