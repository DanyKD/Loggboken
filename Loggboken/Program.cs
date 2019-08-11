using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggboken
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] inlägg = new String[2];
            List<String[]> loggboken = new List<String[]>();
            bool looping = true;
            while (looping)
            {
                Console.Clear();
                Console.WriteLine("\n\tVälkommen till Loggboken\n\t#########################\n\n\t[1]Skriv nytt inlägg i loggbken\n\t[2]Sök inlägg i loggboken\n\t[3]Skriv ut alla loggar\n\t[4]Avsluta program");
                Console.Write("\n\tVälja nummer: ");
                Int32.TryParse(Console.ReadLine(), out int meny); // Tar emot användarinput för vår meny
                switch (meny)
                {
                    case 1:
                        inlägg = LäggtillInlägg();
                        LäggtillLoggboken(loggboken,inlägg);
                        SkrivutLoggboken(loggboken);
                        MenyAvslut();
                        break;
                    case 2:
                        break;
                    case 3:
                        SkrivutLoggboken(loggboken);
                        MenyAvslut();
                        break;
                    case 4:
                        looping = false;
                        break;
                    
                }
            }
        }
        static void SkrivutLoggboken(List<String[]> loggar)
        {
            foreach (String[] inlägg in loggar)
            {
                Console.WriteLine("\n\tTitel: " + inlägg[0] + ", Meddelande: " + inlägg[1]);
            }
        }
        static void MenyAvslut() 
        {
            Console.WriteLine("\n\tTryck ENTER för att återgå till menyn.");
            Console.ReadLine();
        }
        static void LäggtillLoggboken(List<String[]> loggar, String[] inlägg)
        {
            if (!inlägg.Equals(null) )
                loggar.Add(inlägg);
        }
        static String MataInText(String adress)
        {
            Console.Write("\n\tAnge en " + adress+": ");
            String text = Console.ReadLine();
            return text;
        }
        static String[] LäggtillInlägg()
        {
            String Titel=MataInText("Titel");
            String Medelande = MataInText("Medelande");
            String[] inlägg = new string[2];
            if (Titel != null && Medelande != null)
            {
                inlägg[0] = Titel;
                inlägg[1] = Medelande;
            }
            else
                Console.WriteLine("\n\tDu har angett fel värde.");
            return inlägg;
        }

    }
}
