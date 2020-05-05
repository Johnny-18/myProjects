
namespace Task2_1Ex
{
    public class Student
    {
        public string name { get; private set; }
        public string dataTest { get; private set; }
        public string nameOfTest { get; private set; }
        public int markOfTest { get; private set; }

        public Student() { }

        public Student(string name, string dataTest, string nameOfTest, int markOfTest)
        {
            this.name = name;
            this.dataTest = dataTest;
            this.nameOfTest = nameOfTest;
            this.markOfTest = markOfTest;
        }

        public Student(Student data)
        {
            name = data.name;
            dataTest = data.dataTest;
            nameOfTest = data.nameOfTest;
            markOfTest = data.markOfTest;
        }
    }
}
