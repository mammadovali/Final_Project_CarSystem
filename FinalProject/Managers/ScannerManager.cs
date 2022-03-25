using FinalProject.Infrastructures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public static class ScannerManager
    {
      
        public static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!int.TryParse(Console.ReadLine(),out int value))
            {
                PrintError("Ədəd düzgün daxil edilməyib, yenidən cəhd edin.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                PrintError("Eded duzgun daxil edilmeyib, yeniden cehd edin.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static string ReadString(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("Daxil etdiyiniz məlumat düzgün deyil, yenidən cəhd edin.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static DateTime ReadDate(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy", null, DateTimeStyles.None, out DateTime value))
            {
                PrintError("Daxil etdiyiniz məlumat düzgün deyil, yenidən cəhd edin.");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static Menu ReadMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!Enum.TryParse(Console.ReadLine(), out Menu m))
            {
                PrintError("Menudan seçin");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }

        public static FuelTypeMenu ReadFuelTypeMenu(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!Enum.TryParse(Console.ReadLine(), out FuelTypeMenu m))
            {
                PrintError("Menudan seçin");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.Beep();
            Console.ResetColor();          
        }

       
    }
}
