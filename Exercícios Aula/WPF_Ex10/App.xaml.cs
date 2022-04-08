using System.Windows;
using WPF_Ex10.Models;

namespace WPF_Ex10
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Enrollments Enrollments { get; private set; }

        public Courses Courses { get; private set; }

        public App()
        {
            Enrollments = new Enrollments();
            Courses = new Courses();
        }
    }
}
