using static SchoolFees.Student;

namespace SchoolFees
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student() {FirstName = "Paul", LastName = "James", Level = "100" },
                new Student(){FirstName = "David", LastName = "Kunle", Level= "200" },
                new Student() {FirstName = "Pelumi", LastName = "Ariyo", Level = "300"}
            };
            Console.WriteLine("The following are student(s) in the school");
            Console.WriteLine("First Name\t" + "Last Name\t" + "Level");
            foreach(var numberOfStudent in students)
            {
                Console.WriteLine(numberOfStudent.FirstName + "\t\t " + numberOfStudent.LastName + "\t\t " + numberOfStudent.Level);
            }

            Console.WriteLine();
            Student s = new Student();
            Console.WriteLine("Enter your level to know your schoolfees:");
            string level = Console.ReadLine();


            decimal schoolfees = s.SchoolFees(level);
            Console.WriteLine("The school fee for " + level + " level is: " + schoolfees);



            Console.WriteLine("Course 1 score: ");
            int courseOne = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course 1 unit: ");
            int courseOneUnit = Convert.ToInt32(Console.ReadLine());

            Student scores = new Student();
            int result = scores.Score(courseOne, courseOneUnit);
            Console.WriteLine("Total point for course is: " + result);

            Console.WriteLine();

            Console.WriteLine("Faculty in the school are");
            facultyDelegate listOfFaculty = new facultyDelegate(s.Faculty);
            listOfFaculty();

        }
    }

    //Interface class member to calulate point
    interface IStudent
    {
        public int Score(int score, int unit);
    }

    //Interface method inherited by Student class
    public class Student : IStudent
    {

        public int Score(int score, int unit)
        {
            if(score >= 70)
            {
                Console.WriteLine("You have " + (int)Grade.A + "points");
                return 5 * unit;
            }
            else if (score >= 60 && score <= 69)
            {
                Console.WriteLine("You have " + (int)Grade.B + " points");
                return 4 * unit;
            }else if (score >= 50 && score <= 59)
            {
                Console.WriteLine("You have " + (int)Grade.C + " points");
                return 3 * unit;
            }
            else if (score >= 40 && score <= 49)
            {
                Console.WriteLine("You have " + (int)Grade.D + " points");
                return 2 * unit;
            }
            else if (score >= 40 && score <= 44)
            {
                Console.WriteLine("You have " + (int)Grade.E + " points");
                return 1 * unit;
            }
            else if (score == 0 && score <= 39)
            {
                Console.WriteLine("You have " + (int)Grade.F + " points");
                return 0 * unit;
            }
            return 0;
        }
       
        //Property class member
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }

        //Construtor class member
        public Student(){}

        //Method class member to calculate school fees based on level
        public decimal SchoolFees(string level)  
        {
            if (level == "100")
            {
                return 100000;
            }else if (level == "200")
            {
                return 200000;
            }else if(level == "300")
            {
                return 300000;

            }else { return 0; }
        }
         //Enumerate class member with associated points
        enum Grade
        {
           A = 5,
           B = 4,
           C = 3,
           D = 2,
           E = 1,
           F = 0,
        }

        //Delegate member to print list of faculty
        public delegate void facultyDelegate();
        public void Faculty()
        {
            string[] facultyArray = new string[] { "Engineering", "Medicine", "Law", "Science" };

            foreach (var faculty in facultyArray)
            {
                Console.WriteLine(Array.IndexOf(facultyArray, faculty) + 1 + ". " + faculty);
            }
        }
   //Destructors
        ~Student()
        {
            Console.WriteLine("End of program");
        }

    }
}