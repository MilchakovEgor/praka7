using System.Diagnostics;
namespace Praka7
{
    internal static class Provodnik
    {
        public static string CottonField = "";
        public static int Otstup = 0;
        public static List<string> list = new List<string>();
        public static int Kolichestvo = 0;
        public static void Start()
        {
                Console.WriteLine("Проводильник по нулям и единицам  |  F1 - Создать папку | F2 - Создать файл | Delete - Удалить | Backspace - В меню дисков");
            List<string> Strukrura = new List<string>();
            string[] Drives = new string[] { };
            string[] Files = new string[] { };

            
            
            
            if (Provodnik.CottonField != "")
            {
                Drives = Directory.GetDirectories(Provodnik.CottonField);
                Files = Directory.GetFiles(Provodnik.CottonField);
                foreach (string napolnenieD in Drives)
                {
                    Strukrura.Add(napolnenieD);
                }
                foreach (string napolnenieF in Files)
                {
                    Strukrura.Add(napolnenieF);
                }
                foreach (string file in Strukrura)
                {
                    Console.WriteLine("  " + file + "Создан afqk: " + File.GetCreationTime(file));
                    list.Add(file);
                    if (Provodnik.Kolichestvo == 0)
                    {
                        Provodnik.Otstup = Provodnik.Otstup + 1;
                    }
                }
            }

            else if (Provodnik.CottonField == "")
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
                        Console.WriteLine("  " + file.Name  + "Свободно " + (file.AvailableFreeSpace / 1073741824) + " ГБ из " + (file.TotalSize / 1073741824) + " ГБ");
                    }
                    finally { }

                           }
            }
        }
    }

    public class Functions
    {
        bool Bool = true;
        public int CursPos = 1;
        void Cursor(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow & CursPos != 0)
            {
                CursPos--;
                Provodnik.Kolichestvo = 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                CursPos++;
                Provodnik.Kolichestvo = 1;
            }
            
            if (key.Key == ConsoleKey.Enter)
            {
                if (Path.GetExtension(Provodnik.list[CursPos]) == "")
                {
                    Provodnik.CottonField = Provodnik.list[CursPos];
                    CursPos = 2;
                    Provodnik.Kolichestvo = 0;
                    Provodnik.Otstup = 0;

                }
                else if (Path.GetExtension(Provodnik.list[CursPos]) != "")
                {
                    Process.Start(new ProcessStartInfo { FileName = Provodnik.list[CursPos], UseShellExecute = true });

}
                Provodnik.list.Clear();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                CursPos = 0;
                Provodnik.Kolichestvo = 1;
                Provodnik.CottonField = "";
                Provodnik.list.Clear();
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                Console.Clear();
                Console.WriteLine("Точно точно?");
                Console.WriteLine("Если да, введите:\nДа, я окончательно решил, что хочу удалить данный файл из памяти моего персонального компьютера. Я понимаю, что файл будет безвозвратно утерян. Подтверждаю удаление");
                string ConfirmDelete = Console.ReadLine();
                switch (ConfirmDelete)
                {
                    case "Да, я окончательно решил, что хочу удалить данный файл из памяти моего персонального компьютера. Я понимаю, что файл будет безвозвратно утерян. Подтверждаю удаление":
                        try
                        {
                            File.Delete(Provodnik.list[CursPos]);
                        }
                        catch { }
                        Directory.Delete(Provodnik.list[CursPos], true);
                        break;
                    default:
                        CursPos = 0;
                        Provodnik.Kolichestvo = 1;
                        Provodnik.CottonField = "";
                        Provodnik.list.Clear();
                        break;
                }



            }
            else if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("Введите название папки: ");
                string Papka = Console.ReadLine();
                Provodnik.list.Clear();
                Directory.CreateDirectory(Provodnik.CottonField + "\\" + Papka);

            }
            else if (key.Key == ConsoleKey.F2)
            {
                Console.Clear();
                Console.WriteLine("Введите название файла: ");
                string FileName = Console.ReadLine();
                Console.WriteLine("Введите расширение файла");
                string Rasshirenie = Console.ReadLine();
                Provodnik.list.Clear();
                File.Create(Provodnik.CottonField + "\\" + FileName + "." + Rasshirenie).Close();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Bool = false;
            }
            Console.Clear();
        }
        public void Function()
        {
            Provodnik.Start();
            while (Bool == true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Cursor(key);
                Provodnik.Start();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
                Console.SetCursorPosition(0, CursPos);
                Console.WriteLine("->");
            }
        }
    }
}
