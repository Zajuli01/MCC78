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
    }
}
