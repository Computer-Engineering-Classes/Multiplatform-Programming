using System.Collections.ObjectModel;
using System.IO;

namespace WPF_Ex10.Models
{
    public class Courses
    {
        public ObservableCollection<string> CoursesList { get; set; }

        public event voidNoArgs WriteEnded;

        public Courses()
        {
            CoursesList = new ObservableCollection<string>();
        }

        public void ReadFromTxt(string file)
        {
            CoursesList.Clear();
            StreamReader reader = new(file);
            while (!reader.EndOfStream)
            {
                CoursesList.Add(reader.ReadLine());
            }
            reader.Close();
        }

        public void WriteToTxt(string file)
        {
            if (CoursesList.Count == 0)
                throw new InvalidOperationException("Nao existem dados para serem guardados!");
            StreamWriter sw = new(file);
            foreach (string course in CoursesList)
            {
                sw.WriteLine(course);
            }
            sw.Close();
            WriteEnded?.Invoke();
        }

    }
}
