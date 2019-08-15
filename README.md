# Loggboken


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
                            // om det kan inte hitta posten
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 3:
                        //Skriv ut alla loggar
                        SkrivutLoggboken(loggboken);
                        MenyAvslut();
                        break;
                    case 4:
                        // Ber användaren att skriva i en ny tillfällig titel för att söka efter i loggboken
                        temp = MataInText("titel du vill söka på?");
                        //Söka efter titeln inom loggboken 
                        result = LinjärSökning(loggboken, temp);
                        //Returnera -1 om den inte hittade titeln
                        if (result != -1)
                        {
                            //Redigera posten efter hittade i loggboken
                            RedigeraInlägg(loggboken, result);
                            //Skriv ut alla loggar
                            SkrivutLoggboken(loggboken);
                        }
                        else
                            // om det kan inte hitta posten
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 5:
                         // Ber användaren att skriva i en ny tillfällig titel för att söka efter i loggboken
                        temp = MataInText("titel du vill radera?");
                        //Söka efter titeln inom loggboken 
                        result = LinjärSökning(loggboken, temp);
                        //Returnera -1 om den inte hittade titeln
                        if (result != -1)
                        {
                            //Redera posten efter hittade i loggboken
                            RederaInlägg(loggboken, result);
                            //Skriv ut alla loggar
                            SkrivutLoggboken(loggboken);
                        }
                        else
                            // om det kan inte hitta posten
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 6:
                        //Looping false för att lämna slingan
                        looping = false;
                        break;
                    case 7:
                    SorteringLoggboken(loggboken);
                    MenyAvslut();
                    break;
        
                }
            }
        }
        //Skriv ut alla loggar genom att lämna loggboken som parameter
        static void SkrivutLoggboken(List<String[]> loggar)
        {
            // deklarera item of loggboken som vill skriv ut
            string[] inlägg = new string[3];
            Console.WriteLine("\n\tLoggboken är:");
            //loop för att akriv ut alla loggar
            for (int i = 0; i < loggar.Count; i++)
            {
                //Sätta varje log i loggboken i inlägget genom att slinga 
                inlägg = loggar[i];
                //skriv ut inlägget
                Console.WriteLine("\n\t" + (i + 1) + "- Titel: " + inlägg[0] + ", Meddelande: " + inlägg[1] + ", Datum:" + inlägg[2]);
            }
        }
        //Vänta på användarens svar
        static void MenyAvslut()
        {
            Console.WriteLine("\n\tTryck ENTER för att återgå till menyn.");
            Console.ReadLine();
        }
        //Lägga till inlägg i loggboken genom att passera loggboken och inlägg
        static void LäggtillLoggboken(List<String[]> loggar, String[] inlägg)
        {
            //Kolla om inlägg inte är noll
            if (!inlägg.Equals(null))
                //Använd add-funktion för att lägga till inlägg till loggboken
                loggar.Add(inlägg);
            else
                //Om inlägg är noll
                Console.WriteLine("\n\tDet finns inte inlägg att lägga till!.");
        }
        //En metod för att mata in en strängvariabel och returnera den för att använda den i alla ingångsar
        static String MataInText(String adress)
        {
            Console.Write("\n\tAnge en " + adress + ": ");
            //Be användaren att mata in strängen
            String text = Console.ReadLine();
            //Returnera strängen i en stor bokstav
            return text.ToUpper();
        }
        //Använd den här metoden för att skapa ett nytt inlägg och returnera det som en strängvektor
        static String[] LäggtillInlägg()
        {
            // deklarera item of loggboken som vill skapa
            String[] inlägg = new string[3];
            //Mata in första position i vektor som vara titel
            inlägg[0] = MataInText("Titel");
            //mata in andra position i vektor som vara medelande
            inlägg[1] = MataInText("Medelande");
            //Initiera tredje position i vektor som vara datum
            inlägg[2] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");
            //Kolla om första och andra positioner i vektor är inte noll sen vi kan returnera inlägg
            if (inlägg[0] != null && inlägg[1] != null)
                return inlägg;
            else
            {
                //Om första eller andra positioner i vektor är noll returnera noll
                Console.WriteLine("\n\tDu har angett fel värde.");
                return null;
            }

        }
        //en metod för att söka efter en text i list av vektor
        static int LinjärSökning(List<String[]> list, string text)
        {
            //en loop för att läsa alla inlägg
            for (int i = 0; i < list.Count; i++)
            {
                //Ställa in element i listan varje gång i posten
                string[] inlägg = list[i];
                //Kolla om varje element i list är lika med texten retrunera 1 eller inte returnera -1  
                if (inlägg[0].Equals(text.ToUpper()))

                    return i;
            }
            return -1;
        }
        //En metod för att skriva ut inlägg genom att skicka listan över vektor och index för listan
        static void SkrivutInlägg(List<String[]> list, int i)
        {
            // Kolla om om listan inte är tom
            if (list.Count != 0)
            {
                //Ställa in elementet i listan i inlägget
                String[] inlägg = list[i];
                //Skriva ut inlägget
                Console.WriteLine("\n\t" + (i + 1) + "- Titel: " + inlägg[0] + ", Meddelande: " + inlägg[1] + ", Date: " + inlägg[2]);
            }
            else
                //Om listen är tom
                Console.WriteLine("Listen är tomt.");
        }
        //En metod för att Radera inlägg genom att skicka listan över vektor och index för listan
        static void RederaInlägg(List<String[]> list, int i)
        {
            //använda removeat-function för att radera inlägg
            list.RemoveAt(i);
            Console.WriteLine("\n\tPosten raderades.");
        }
        ////En metod för att Redigera inlägg genom att skicka listan över vektor och index för listan
        static void RedigeraInlägg(List<String[]> list, int i)
        {
            //ställa in elementet i listan i inlägg
            String[] inlägg = new String[3];
            //Mata in första position i vektor som vara titel
            inlägg[0] = MataInText("En ny titel");
            //Mata in första position i vektor som vara medelande
            inlägg[1] = MataInText("En ny medelande");
            //Initiera tredje position i vektor som vara datum
            inlägg[2] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");
            //Ställa den redigerade posten i listan
            list[i] = inlägg;
            Console.WriteLine("\n\tInlägget redigerades.");
        }
        static void SorteringLoggboken(List<String[]> list){
          // kolla om lista är inte tom
          if(list.Count>0)
          {
            for(int i=0;i<list.Count-1;i++)
            {
              for(int index=0;index<list.Count-1-i;index++)
              {
                string[] tmptitel1=list[index];
                string[] tmptitel2=list[index+1];
                int tmp = tmptitel1[0].CompareTo(tmptitel2[0]);
                 if (tmp > 0)
                        {
                            String[] temp = list[index];
                            list[index] = list[index + 1];
                            list[index + 1] = temp;
                        }          
              }
            }
          //skriver ut alla inlägg för att visa att de är nu i bokstavsordning efter titel.
          SkrivutLoggboken(list); 
          }
          // listen är tom
          else
            {
            Console.WriteLine("\n\tKan EJ sortera eftersom att Loggboken är tom!");
            }
        }
    }
}
