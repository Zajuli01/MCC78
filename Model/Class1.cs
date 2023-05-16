//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TugasGG
//{
//    public class Class1
//    {
//        public static void Looping()
//        {
//            for (int i = 0; true; i+=2)
//            {
//                if (i == 10)
//                {
//                    break;
//                }
//                Console.WriteLine(i);
//            }
//        }
//    }
//    public class E1<T>
//    {
//        public T id { get; set; }
//        public string name { get; set; }
//        public float salary { get; set; }
//        public string job { get; set; }
//        public E1(T id, string name, float salary, string job) {
//            this.id = id;
//            this.name = name;
//            this.salary = salary;
//            this.job = job;
//        }
//        public void Intro(T id, string name, float salary, string job)
//        {
            
//            Console.Write("Nama : " + name);
//        }
//    }

//    public class E2<TKey,TValue>
//    {
       
        
//    }

//    public class Program
//    {
//        static void Main()
//        {
//            var hanif = new Employee
//            {
//                NIK = "118633",
//                Name = "Hanif",
//                Salary = 50000
//            };

//            var budi = new Employee
//            {
//                NIK = "118634",
//                Name = "Budi",
//                Salary = 60000
//            };

//            var violet = new Employee
//            {
//                NIK = "118635",
//                Name = "Violet",
//                Salary = 70000
//            };

//            var employees = new List<Employee>();
//            employees.Add(hanif);
//            employees.Add(budi);
//            employees.Add(violet);

//            /*
//            foreach (var employee in employees) {
//                Console.WriteLine($"NIK: {employee.NIK}");
//                Console.WriteLine($"Name: {employee.Name}");
//                Console.WriteLine($"Salary: {employee.Salary}");
//                Console.WriteLine();
//            }*/

//            var numbers = new Queue<int>();

//            numbers.Enqueue(1);
//            numbers.Enqueue(2);
//            numbers.Dequeue();
//            numbers.Enqueue(3);
//            numbers.Enqueue(4);
//            numbers.Dequeue();
//            numbers.Enqueue(5);
//            numbers.Dequeue();

//            foreach (var number in numbers)
//            {
//                //Console.WriteLine(number);
//            }

//            var names = new Stack<string>();
//            names.Push("Hanif");
//            names.Push("Budi");
//            names.Push("Violet");
//            names.Pop();
//            names.Push("Tama");
//            names.Push("Aji");

//            foreach (var name in names)
//            {
//                //Console.WriteLine(name);
//            }

//            //Console.WriteLine(names.Peek());

//            var dictEmployees = new Dictionary<string, Employee>();

//            dictEmployees.Add("Hanif", hanif);
//            dictEmployees.Add("Budi", budi);
//            dictEmployees.Add("Violet", violet);

//            ArrayList listEmployees = new ArrayList();
//            listEmployees.Add(hanif);
//            listEmployees.Add("budi");
//            listEmployees.Add(1);
//        }
//    }
//}
