using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasGG.View;

namespace TugasGG.Controller
{
    public class EmployeeController
    {
        private Employee emp = new Employee();

        public void GetAll()
        {
            var results = emp.GetEmployees();
            var view = new EmployeeView();
            if (results.Count == 0)
            {
                view.Output("Data Tidak Ditemukan");
            }
            else
            {
                view.Output(results);
            }
        }

        public void GetById(int id)
        {
            /*var result = _university.(id);
            var view = new UniversityView();
            if (result == null) {
                view.Output("Data Tidak Ditemukan");
            }
            else {
                view.Output(result);
            }*/
        }

        public void Insert(Employee employee)
        {
            var result = emp.InsertEmployee(employee);
            var view = new EmployeeView();
            if (result == 0)
            {
                view.Output("Sesuatu Salah!");
            }
            else
            {
                view.Output("Data Berhasil Ditambahkan");
            }
        }
    }
}
