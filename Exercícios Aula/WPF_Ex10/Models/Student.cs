namespace WPF_Ex10.Models
{
    public class Student
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string Course { get; private set; }
        public bool Subscribed { get; set; }

        public Student(int number, string name, string course, bool subscribed = false)
        {
            Number = number;
            Name = name;
            Course = course;
            Subscribed = subscribed;
        }
    }
}
