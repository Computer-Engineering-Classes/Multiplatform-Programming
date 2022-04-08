using System.Collections.ObjectModel;
using System.Windows;
using WPF_Ex10.Models;

namespace WPF_Ex10.ViewModels
{
    public class AddAlunoViewModel
    {
        private readonly App app;

        public string Name { get; set; }

        public int Number { get; set; }

        public ObservableCollection<string> Courses { get; set; }

        public string SelectedCourse { get; set; }

        public (bool, bool) Subscription { get; set; }

        public AddAlunoViewModel()
        {
            app = Application.Current as App;
            Courses = app.Courses.CoursesList;
        }

        public void AddAluno()
        {
            if (Number != 0)
                if (Name != null)
                    if (SelectedCourse != null)
                    {
                        Student student = new(Number, Name, SelectedCourse);
                        if (Subscription.Item1)
                            student.Subscribed = true;
                        else
                            student.Subscribed = false;
                        app.Enrollments.Students.Add(student.Number, student);
                    }
                    else
                        throw new InvalidOperationException("Curso em falta.");
                else
                    throw new InvalidOperationException("Nome em falta.");
            else
                throw new InvalidOperationException("Número em falta.");
        }
    }
}
