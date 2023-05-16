using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.View
{
    public class MenuView
    {
        public static void Menu1()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("=           MENU            =");
            Console.WriteLine("=============================");
            Console.WriteLine("=                           =");
            Console.WriteLine("=        1. Create          =");
            Console.WriteLine("=        2. Read            =");
            Console.WriteLine("=        3. Update          =");
            Console.WriteLine("=        4. Delete          =");
            Console.WriteLine("=        5. Exit            =");
            Console.WriteLine("=                           =");
            Console.WriteLine("=============================");
            Console.WriteLine("Pilih menu (1/2/3/4/5): ");
        }

        public static void MenuInsert()
        {
            Console.WriteLine("===== INGIN MELAKUKAN INSERT PADA TABEL =====");
            Console.WriteLine("=====                                   =====");
            Console.WriteLine("=====        1. Universities            =====");
            Console.WriteLine("=====        2. Educations              =====");
            Console.WriteLine("=====        3. Employees (Khusus)      =====");
            Console.WriteLine("=====        4. Back                    =====");
            Console.WriteLine("=====                                   =====");
            Console.WriteLine("Pilih menu (1/2/3/4): ");
        }
        
        public static void MenuGetAll()
        {
            Console.WriteLine("===== PILIH TABEL YANG AKAN DITAMPILKAN =====");
            Console.WriteLine("=====                                   =====");
            Console.WriteLine("=====        1. Universities            =====");
            Console.WriteLine("=====        2. Educations              =====");
            Console.WriteLine("=====        3. Employees               =====");
            Console.WriteLine("=====        4. Profillings             =====");
            Console.WriteLine("=====        5. Tampil Semua Tabel      =====");
            Console.WriteLine("=====        6. Back                    =====");
            Console.WriteLine("=====                                   =====");
            Console.WriteLine("Pilih menu (1/2/3/4/5): ");
        }
        public static void MenuUpdate()
        {
            Console.WriteLine("===== PILIH TABEL YANG AKAN DIUBAH =====");
            Console.WriteLine("=====                              =====");
            Console.WriteLine("=====        1. Universities       =====");
            Console.WriteLine("=====        2. Educations         =====");
            Console.WriteLine("=====        3. Back               =====");
            Console.WriteLine("=====                              =====");
            Console.WriteLine("Pilih menu (1/2): ");
        }
        public static void MenuDelete()
        {
            Console.WriteLine("===== PILIH TABEL YANG AKAN DIHAPUS =====");
            Console.WriteLine("=====                               =====");
            Console.WriteLine("=====        1. Universities        =====");
            Console.WriteLine("=====        2. Educations          =====");
            Console.WriteLine("=====        3. Back                =====");
            Console.WriteLine("=====                               =====");
            Console.WriteLine("Pilih menu (1/2): ");
        }
    }
}

