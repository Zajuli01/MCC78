using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasGG.View;

namespace TugasGG.Controller
{
    public class UniversityController
    {
        private University _university = new University();

        public void GetAll()
        {
            var results = _university.GetUniv();
            var view = new UniversityView();
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

        public void Insert(University university)
        {
            var result = _university.InsertUniv(university);
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
