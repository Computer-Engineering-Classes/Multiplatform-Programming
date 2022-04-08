using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WPF_Ex10.Models
{
    public class Enrollments
    {
        private const char IFS = ';';
        private const string Inscrito = "Inscrito";
        private const string NaoInscrito = "NaoInscrito";

        public Dictionary<int, Student> Students { get; set; }

        public event voidNoArgs ReadEnded;
        public event voidNoArgs WriteEnded;
        public event voidNoArgs EnrolmentsUpdated;

        public Enrollments()
        {
            Students = new Dictionary<int, Student>();
        }

        public void ChangeSubscription(int number)
        {
            if (Students.TryGetValue(number, out Student student))
            {
                student.Subscribed = !student.Subscribed;
                EnrolmentsUpdated.Invoke();
            }
        }

        public void ReadFromXml(string file)
        {
            XDocument document = XDocument.Load(file);
            var registries  = from student in document.Element("Alunos").Element("Inscritos").Descendants("Aluno") select student;
            foreach(XElement fields in registries)
            {
                Student student = new(Convert.ToInt32(fields.Element("Numero").Value),
                    fields.Element("Nome").Value, fields.Element("Curso").Value);
                student.Subscribed = true;
                Students.Add(student.Number, student);
            }
            registries = from student in document.Element("Alunos").Element("NaoInscritos").Descendants("Aluno") select student;
            foreach (XElement fields in registries)
            {
                Student student = new(Convert.ToInt32(fields.Element("Numero").Value), 
                    fields.Element("Nome").Value, fields.Element("Curso").Value);
                student.Subscribed = false;
                Students.Add(student.Number, student);
            }
            ReadEnded?.Invoke();
        }

        public void WriteToXml(string file)
        {
            if (Students.Count == 0)
                throw new InvalidOperationException("Nao existem dados para serem guardados!");
            XDocument xdoc = new(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                new XComment("Listagem de alunos"),
                new XElement("Alunos",
                    new XElement("Inscritos"),
                    new XElement("NaoInscritos")));
            foreach (Student student in Students.Values)
            {
                XElement xstudent = new("Aluno", 
                    new XElement("Numero", student.Number),
                    new XElement("Nome", student.Name),
                    new XElement("Curso", student.Course));
                if (student.Subscribed)
                    xdoc.Element("Alunos").Element("Inscritos").Add(xstudent);
                else
                    xdoc.Element("Alunos").Element("NaoInscritos").Add(xstudent);
            }
            xdoc.Save(file);
            WriteEnded?.Invoke();
        }

        public void ReadFromTxt(string file)
        {
            StreamReader reader = new(file);
            Students.Clear();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] StudentData = line.Split(IFS);

                Student student = new(Convert.ToInt32(StudentData[0]), StudentData[1], StudentData[2]);
                if (StudentData[3] == Inscrito)
                    student.Subscribed = true;
                Students.Add(student.Number, student);
            }
            reader.Close();
            ReadEnded.Invoke();
        }

        public void WriteToTxt(string file)
        {
            if (Students.Count == 0)
                throw new InvalidOperationException("Nao existem dados para serem guardados!");
            StreamWriter sw = new(file);
            foreach (Student student in Students.Values)
            {
                string line = $"{student.Number}{IFS}{student.Name}{IFS}{student.Course}{IFS}";
                if (student.Subscribed)
                    line += Inscrito;
                else
                    line += NaoInscrito;
                sw.WriteLine(line);
            }
            sw.Close();
            WriteEnded?.Invoke();
        }
    }
}
