using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasGG.View;

namespace TugasGG.Controller
{
    public class EducationController
    {
        private Education edu = new Education();

        public void GetAll()
        {
            var results = edu.GetEducation();
            var view = new EducationView();
            if (results.Count == 0)
            {
                view.Outpute("Data Tidak Ditemukan");
            }
            else
            {
                view.Outpute(results);
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

        public void Insert(Education education)
        {
            var result = edu.InsertEduc(education);
            var view = new UniversityView();
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
