using System.IO;

namespace WPF_Ex6
{
    public delegate void MethodWithoutArgs();

    public class ModelFile
    {
        public string Content ="";

        public event MethodWithoutArgs ReadingFinished;
        
        public void ReadFile(string file)
        {
            StreamReader sr = new(file);
            if (sr != null)
            {
                Content = sr.ReadToEnd();
                sr.Close();
                ReadingFinished?.Invoke();
            }
        }

        public event MethodWithoutArgs WritingFinished;

        public void WriteFile(string file, string text)
        {
            StreamWriter sw = new(file);
            if (sw != null)
            {
                Content = text;
                sw.Write(Content);
                sw.Close();
                WritingFinished?.Invoke();
            }
        }
    }
}
