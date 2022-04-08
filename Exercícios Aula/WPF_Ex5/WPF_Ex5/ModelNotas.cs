using System.Collections.Generic;

namespace WPF_Ex5
{
    public class ModelNotas
    {
        //Criar delegate
        public delegate void MetodosComString(string str);
        public delegate void ErroHandling(string erro);
        //Criar evento
        public event MetodosComString NotaAdicionada;
        public event ErroHandling MensagemErro;
        
        public List<string> ListaNotas
        {
            get;
            private set;
        }
 
        public ModelNotas()
        {
            ListaNotas = new List<string>();
        }

        public void Adiciona(string nota)
        {
            if (!string.IsNullOrWhiteSpace(nota))
                if (double.TryParse(nota, out double tmp))
                    if (tmp >= 0 && tmp <= 20)
                    {
                        ListaNotas.Add(nota);
                        //Lançar event
                        NotaAdicionada?.Invoke(nota);
                        MensagemErro?.Invoke("Operação bem sucedida.");
                    }
                    else
                        MensagemErro?.Invoke("Nota fora dos limites (0-20).");
                else
                    MensagemErro?.Invoke("Nota inválida.");
            else
                MensagemErro?.Invoke("Nota vazia.");
        }
    }
}
