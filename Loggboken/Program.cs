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
            // Vektor som innehållar titel, medelande och datum
            String[] inlägg = new String[3];

            //global Lista som ska innehålla vektor objecktet
            List<String[]> loggboken = new List<String[]>();

            //Variabel som kontrollerar loopen för användarval
            bool looping = true;
            while (looping)
            {
                Console.Clear();
                //Skriver ut en meny som använder ska val en av dem varje loopen
                Console.WriteLine("\n\tVälkommen till Loggboken\n\t#########################\n\n\t[1]Skapa nytt inlägg i loggbken\n\t[2]Sök inlägg i loggboken\n\t[3]Skriv ut alla loggar\n\t[4]Redigera inlägg\n\t[5]Radera inlägg\n\t[6]Avsluta program");
                Console.Write("\n\tVälja nummer: ");
                //Tar emot användarinput för vår meny
                Int32.TryParse(Console.ReadLine(), out int meny); 
                switch (meny)
                {
                    case 1:
                        //Skappa en ny post och lägga till logboken
                        inlägg = LäggtillInlägg();
                        LäggtillLoggboken(loggboken, inlägg);
                        // Skriv ut loggboken efter updetering
                        SkrivutLoggboken(loggboken);
                        MenyAvslut();
                        break;
                    case 2:
                        //ber användaren att mata in titel som söka efter
                        String temp = MataInText("titel du vill söka efter?");
                        //Söka efter titeln inom loggboken 
                        int result = LinjärSökning(loggboken, temp);
                        //Returnera -1 om den inte hittade titeln
                        if (result != -1)
                            //skriv ut hittade posten
                            SkrivutInlägg(loggboken, result);
                        else
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 3:
                        //Skriv ut alla loggar
                        SkrivutLoggboken(loggboken);
                        MenyAvslut();
                        break;
                    case 4:

                        temp = MataInText("titel du vill söka på?");
                        result = LinjärSökning(loggboken, temp);
                        if (result != -1)
                        {
                            RedigeraInlägg(loggboken, result);
                            SkrivutLoggboken(loggboken);
                        }
                        else
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 5:
                        temp = MataInText("titel du vill radera?");
                        result = LinjärSökning(loggboken, temp);
                        if (result != -1)
                        {
                            RederaInlägg(loggboken, result);
                            SkrivutLoggboken(loggboken);
                        }
                        else
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 6:
                        looping = false;
                        break;

                }
            }
        }
        static void SkrivutLoggboken(List<String[]> loggar)
        {
            string[] inlägg = new string[3];
            Console.WriteLine("\n\tLoggboken är:");
            for (int i = 0; i < loggar.Count; i++)
            {
                inlägg = loggar[i];
                Console.WriteLine("\n\t" + (i + 1) + "- Titel: " + inlägg[0] + ", Meddelande: " + inlägg[1] + ", Datum:" + inlägg[2]);
            }
        }
        static void MenyAvslut()
        {
            Console.WriteLine("\n\tTryck ENTER för att återgå till menyn.");
            Console.ReadLine();
        }
        static void LäggtillLoggboken(List<String[]> loggar, String[] inlägg)
        {
            if (!inlägg.Equals(null))
                loggar.Add(inlägg);
            else
                Console.WriteLine("\n\tDet finns inte inlägg att lägga till!.");
        }
        static String MataInText(String adress)
        {
            Console.Write("\n\tAnge en " + adress + ": ");
            String text = Console.ReadLine();
            return text.ToUpper();
        }
        static String[] LäggtillInlägg()
        {
            String[] inlägg = new string[3];
            inlägg[0] = MataInText("Titel");
            inlägg[1] = MataInText("Medelande");
            inlägg[2] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");
            if (inlägg[0] != null && inlägg[1] != null)
                return inlägg;
            else
            {
                Console.WriteLine("\n\tDu har angett fel värde.");
                return null;
            }

        }
        static int LinjärSökning(List<String[]> list, string text)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string[] inlägg = list[i];
                if (inlägg[0].Equals(text.ToUpper()))
                    return i;
            }
            return -1;
        }
        static void SkrivutInlägg(List<String[]> list, int i)
        {
            if (list.Count != 0)
            {
                String[] inlägg = list[i];
                Console.WriteLine("\n\t" + (i + 1) + "- Titel: " + inlägg[0] + ", Meddelande: " + inlägg[1] + ", Date: " + inlägg[2]);
            }
            else
                Console.WriteLine("Listen är tomt.");
        }
        static void RederaInlägg(List<String[]> list, int i)
        {
            list.RemoveAt(i);
            Console.WriteLine("\n\tPosten raderades.");
        }
        static void RedigeraInlägg(List<String[]> list, int i)
        {
            String[] inlägg = new String[3];
            inlägg[0] = MataInText("En ny titel");
            inlägg[1] = MataInText("En ny medelande");
            inlägg[2] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");
            list[i] = inlägg;
            Console.WriteLine("\n\tInlägget redigerades.");
        }
    }
}
