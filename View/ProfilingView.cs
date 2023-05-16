using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.View
{
    public class ProfilingView
    {
        public static void GetAllProfil()
        {
            Profiling Profiling = new Profiling();
            Console.WriteLine("Menampilkan Data Profilings");
            var resultss = Profiling.GetProfilings();
            foreach (var result in resultss)
            {
                Console.WriteLine("EmployeeId: " + result.EmployeeId);
                Console.WriteLine("EducationId: " + result.EducationId);
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("");
            }
        }
        public void Outputee(Profiling profiling)
        {
            Console.WriteLine("EmployeeId: " + profiling.EmployeeId);
            Console.WriteLine("EducationId: " + profiling.EducationId);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("");
        }

        public void Outpute(List<Profiling> profiling)
        {
            foreach (var pro in profiling)
            {
                Outputee(pro);
            }
        }

        public void Outpute(string message)
        {
            Console.WriteLine(message);
        }
    }
}
