using System;

namespace ModelSomaNamespace
{
    public delegate void voidNoArgs();

    public class ModelSoma
    {
        public int Soma { get; private set; }
        public event voidNoArgs SomaTerminada;
        public void Add(string item1, string item2)
        {
            Soma = Convert.ToInt32(item1) + Convert.ToInt32(item2);
            SomaTerminada?.Invoke();
        }
    }
}