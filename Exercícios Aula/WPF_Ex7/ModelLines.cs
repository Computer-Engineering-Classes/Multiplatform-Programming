using System;
using System.Collections.Generic;

namespace WPF_Ex7
{
    public class ModelLines
    {
        public event MethodWithAString LineInserted;

        public List<string> Lines;

        public ModelLines()
        {
            Lines = new();
        }

        public void Add(string text)
        {
            if ((text.Length == 0) || (text.Length > 5))
            {
                throw new InvalidLineException("Erro! O texto deve estar no intervalo [1-5] carateres!");
            }
            Lines.Add(text.ToUpper());
            LineInserted?.Invoke(text.ToUpper());
        }
    }
}
