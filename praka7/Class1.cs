
using System.Diagnostics;


namespace Praka7
{
    internal static class ProvodnikClass
    {
        public static string CottonField = "";
        public static int Otstup = 0;
        public static List<string> list = new List<string>();
        public static int Skoka = 0;
        public static void Start()
        {
            Console.WriteLine("               Проводильник по нулям и единицам  |  F1 - Создать папку | F2 - Создать файл | Delete - Удалить | Backspace - В меню дисков");
            Console.WriteLine("  -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            List<string> NapolnenieList = new List<string>();
            string[] Drives = new string[] { };
            string[] Files = new string[] { };

            if (ProvodnikClass.CottonField != "")
            {
                Drives = Directory.GetDirectories(ProvodnikClass.CottonField);
                Files = Directory.GetFiles(ProvodnikClass.CottonField);
                foreach (string napolnenieD in Drives)
                {
                    NapolnenieList.Add(napolnenieD);
                }
                foreach (string napolnenieF in Files)
                {
                    NapolnenieList.Add(napolnenieF);
                }
                foreach (string file in NapolnenieList)
                {
                    Console.WriteLine("  " + file + "............. Создан: " + File.GetCreationTime(file));
                    list.Add(file);
                    if (ProvodnikClass.Skoka == 0)
                    {
                        ProvodnikClass.Otstup = ProvodnikClass.Otstup + 1;
                    }
                }
            }

            else if (ProvodnikClass.CottonField == "")
            {
                Drives = Environment.GetLogicalDrives();
                foreach (string n in Drives)
                {
                    list.Add(n);
                }
                foreach (var file in DriveInfo.GetDrives())
                {
                    try
                    {
                        Console.WriteLine("  " + file.Name + "..................... " + "Свободно " + (file.AvailableFreeSpace / 1073741824) + " ГБ из " + (file.TotalSize / 1073741824) + " ГБ");
                    }
                    finally { }

                           }
            }
        }
    }

    public class Functions
    {
        bool NegrPashet = true;
        public int CursPos = 1;
        void Cursor(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow & CursPos != 0)
            {
                CursPos--;
                ProvodnikClass.Skoka = 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                CursPos++;
                ProvodnikClass.Skoka = 1;
            }
            //Strelki(0, 15, CursPos);
            if (key.Key == ConsoleKey.Enter)
            {
                if (Path.GetExtension(ProvodnikClass.list[CursPos]) == "")
                {
                    ProvodnikClass.CottonField = ProvodnikClass.list[CursPos];
                    CursPos = 2;
                    ProvodnikClass.Skoka = 0;
                    ProvodnikClass.Otstup = 0;

                }
                else if (Path.GetExtension(ProvodnikClass.list[CursPos]) != "")
                {
                    Process.Start(new ProcessStartInfo { FileName = ProvodnikClass.list[CursPos], UseShellExecute = true });

}
                ProvodnikClass.list.Clear();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                CursPos = 0;
                ProvodnikClass.Skoka = 1;
                ProvodnikClass.CottonField = "";
                ProvodnikClass.list.Clear();
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                Console.Clear();
                Console.WriteLine("Точно точно?");
                Console.WriteLine("Если да, введите:\nДа, я окончательно решил, что хочу удалить данный файл из памяти моего персонального компьютера. Я понимаю, что файл будет безвозвратно утерян. Подтверждаю удаление");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\");");
                string ConfirmDelete = Console.ReadLine();
                switch (ConfirmDelete)
                {
                    case "Да, я окончательно решил, что хочу удалить данный файл из памяти моего персонального компьютера. Я понимаю, что файл будет безвозвратно утерян. Подтверждаю удаление":
                        try
                        {
                            File.Delete(ProvodnikClass.list[CursPos]);
                        }
                        catch { }
                        Directory.Delete(ProvodnikClass.list[CursPos], true);
                        break;
                    default:
                        CursPos = 0;
                        ProvodnikClass.Skoka = 1;
                        ProvodnikClass.CottonField = "";
                        ProvodnikClass.list.Clear();
                        break;
                }



            }
            else if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                /*ProvodnikClass.Skoka = 0;*/
                Console.WriteLine("Введите название папки: ");
                string Papka = Console.ReadLine();
                ProvodnikClass.list.Clear();
                Directory.CreateDirectory(ProvodnikClass.CottonField + "\\" + Papka);
                /*ProvodnikClass.Otstup = 0;*/

            }
            else if (key.Key == ConsoleKey.F2)
            {
                /*ProvodnikClass.Skoka = 0;*/
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Введите название файла: ");
                string FileName = Console.ReadLine();
                Console.WriteLine("Введите расширение файла");
                string Rasshirenie = Console.ReadLine();
                ProvodnikClass.list.Clear();
                File.Create(ProvodnikClass.CottonField + "\\" + FileName + "." + Rasshirenie).Close();
                /*ProvodnikClass.Otstup = 0;*/
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                NegrPashet = false;
            }
            Console.Clear();
        }
        public void SolnceEsheVisoko()
        {
            ProvodnikClass.Start();
            while (NegrPashet == true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Cursor(key);
                ProvodnikClass.Start();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
                Console.SetCursorPosition(0, CursPos);
                Console.WriteLine("->");
            }
        }
    }
}
