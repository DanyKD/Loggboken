using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggboken
{
    class Program
    {
        

        //global Lista som ska innehålla vektor objecktet
        static List<String[]> Loggboken = new List<String[]>();

        static void Main(string[] args)
        {
            // Vektor som innehållar titel, medelande och datum
            String[] inlägg = new String[3];

            //Variabel som kontrollerar loopen för användarval
            bool looping = true;
            while (looping)
            {
                Console.Clear();
                //Skriver ut en meny som använder ska val en av dem varje loopen
                Console.WriteLine("\n\tVälkommen till Loggboken\n\t#########################\n\n\t[1]Skapa nytt inlägg i loggbken\n\t[2]Sök inlägg i loggboken\n\t[3]Skriv ut alla loggar\n\t[4]Sortering Loggboken\n\t[5]Redigera inlägg\n\t[6]Radera inlägg\n\t[7]Avsluta program");
                Console.Write("\n\tVälja nummer: ");
                //Tar emot användarinput för vår meny
                Int32.TryParse(Console.ReadLine(), out int meny);
                switch (meny)
                {
                    case 1:
                        //Skappa en ny post och lägga till logboken
                        inlägg = LäggtillInlägg();
                        LäggtillLoggboken(inlägg);
                        // Skriv ut loggboken efter updetering
                        SkrivutLoggboken();
                        MenyAvslut();
                        break;
                    case 2:
                        //ber användaren att mata in titel som söka efter
                        String temp = MataInText("titel du vill söka efter?");
                        //Söka efter titeln inom loggboken 
                        //int result = LinjärSökning(loggboken, temp);
                        int result = BinärSökning(temp);
                        //Returnera -1 om den inte hittade titeln
                        if (result != -1)
                        {
                            Console.WriteLine("\n\tinlägget är hittat");
                            //skriv ut hittade posten
                            SkrivutInlägg(result);
                        }
                        else
                            // om det kan inte hitta posten
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 3:
                        //Skriv ut alla loggar
                        SkrivutLoggboken();
                        MenyAvslut();
                        break;
                    case 4:
                        BubbleSortering();
                        SkrivutLoggboken();
                        MenyAvslut();
                        break;
                    case 5:
                        // Ber användaren att skriva i en ny tillfällig titel för att söka efter i loggboken
                        temp = MataInText("titel du vill söka på?");
                        //Söka efter titeln inom loggboken 
                        //result = LinjärSökning(temp);
                        result = BinärSökning(temp);
                        //Returnera -1 om den inte hittade titeln
                        if (result != -1)
                        {
                            //Redigera posten efter hittade i loggboken
                            RedigeraInlägg(result);
                            //Skriv ut alla loggar
                            SkrivutLoggboken();
                        }
                        else
                            // om det kan inte hitta posten
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 6:
                        // Ber användaren att skriva i en ny tillfällig titel för att söka efter i loggboken
                        temp = MataInText("titel du vill radera?");
                        //Söka efter titeln inom loggboken 
                        //result = LinjärSökning(temp);
                        result = BinärSökning(temp);
                        //Returnera -1 om den inte hittade titeln
                        if (result != -1)
                        {
                            //Redera posten efter hittade i loggboken
                            RaderaInlägg(result);
                            //Skriv ut alla loggar
                            SkrivutLoggboken();
                        }
                        else
                            // om det kan inte hitta posten
                            Console.WriteLine("\n\tKunde inte hitat.");
                        MenyAvslut();
                        break;
                    case 7:
                        //Looping false för att lämna slingan
                        looping = false;
                        break;


                }
            }
        }
        //Skriv ut alla loggar genom att lämna loggboken som parameter
        static void SkrivutLoggboken()
        {
            // deklarera item of loggboken som vill skriv ut
            string[] inlägg = new string[3];
            if (Loggboken.Count > 0)
            {
                Console.WriteLine("\n\tLoggboken är:");
                //loop för att akriv ut alla loggar
                for (int i = 0; i < Loggboken.Count; i++)
                {
                    //Sätta varje log i loggboken i inlägget genom att slinga 
                    inlägg = Loggboken[i];
                    //skriv ut inlägget
                    Console.WriteLine("\n\t" + (i + 1) + "- Titel: " + inlägg[0] + ", Meddelande: " + inlägg[1] + ", Datum:" + inlägg[2]);
                }
            }
            else Console.WriteLine("\n\tLoggboken är tom.");
        }
        //Vänta på avändarens svar
        static void MenyAvslut()
        {
            Console.WriteLine("\n\tTryck ENTER för att återgå till menyn.");
            Console.ReadLine();
        }
        //Lägga till inlägg i loggboken genom att passera loggboken och inlägg
        static void LäggtillLoggboken(String[] inlägg)
        {
            //Kolla om inlägg inte är noll
            if (!inlägg.Equals(null))
            {
                //Använd add-funktion för att lägga till inlägg till loggboken
                Loggboken.Add(inlägg);  
            }
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
        static int LinjärSökning(string text)
        {
            //en loop för att läsa alla inlägg
            for (int i = 0; i < Loggboken.Count; i++)
            {
                //Ställa in element i listan varje gång i posten
                string[] inlägg = Loggboken[i];
                //Kolla om varje element i list är lika med texten retrunera 1 eller inte returnera -1  
                if (inlägg[0].Equals(text.ToUpper()))

                    return i;
            }
            return -1;
        }
        //En metod för att skriva ut inlägg genom att skicka listan över vektor och index för listan
        static void SkrivutInlägg(int i)
        {
            // Kolla om om listan inte är tom
            if (Loggboken.Count != 0)
            {
                //Ställa in elementet i listan i inlägget
                String[] inlägg = Loggboken[i];
                //Skriva ut inlägget
                Console.WriteLine("\n\t" + (i + 1) + "- Titel: " + inlägg[0] + ", Meddelande: " + inlägg[1] + ", Date: " + inlägg[2]);
            }
            else
                //Om listen är tom
                Console.WriteLine("Loggboken är tomt.");
        }
        //En metod för att Radera inlägg genom att skicka listan över vektor och index för listan
        static void RaderaInlägg(int i)
        {
            //använda removeat-function för att radera inlägg
            Loggboken.RemoveAt(i);
            Console.WriteLine("\n\tinlägg raderades.");
        }
        ////En metod för att Redigera inlägg genom att skicka listan över vektor och index för listan
        static void RedigeraInlägg(int i)
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
            Loggboken[i] = inlägg;
            Console.WriteLine("\n\tInlägget redigerades.");
        }
        static void BubbleSortering()
        {
            // kolla om lista är inte tom
            if (Loggboken.Count > 0)
            {
                for (int i = 0; i < Loggboken.Count - 1; i++)
                {
                    for (int index = 0; index < Loggboken.Count - 1 - i; index++)
                    {
                        string[] tmptitel1 = Loggboken[index];
                        string[] tmptitel2 = Loggboken[index + 1];
                        int tmp = tmptitel1[0].CompareTo(tmptitel2[0]);
                        if (tmp > 0)
                        {
                            String[] temp = Loggboken[index];
                            Loggboken[index] = Loggboken[index + 1];
                            Loggboken[index + 1] = temp;
                        }
                    }
                }
                //Console.WriteLine("\n\tLoggboken är sorterad.");
                //skriver ut alla inlägg för att visa att de är nu i bokstavsordning efter titel.
            }
            // listen är tom
            else
            {
                Console.WriteLine("\n\tKan inte sortera, loggboken är tom!");
            }
        }
        //en metod för att söka efter en text i list av vektor
        static int BinärSökning(string text)
        {
            //Sortera listan för att kunna göra en binär sökning
            BubbleSortering();
            //Initiera min- och maxvärden är början och slutet på listan
            int minvärde = 0;
            int maxvärde = Loggboken.Count - 1;
            //Loopen körs så länge minvärde är mindre än maxvärdet
            while (minvärde <= maxvärde)
            {
                //Initierar int variabel mellanvärdet som är medel mellan min och maxvärdet
                int mellanvärde = (minvärde + maxvärde) / 2;
                //Ställa in mittposten i listan i en tillfällig vektor som begreppet binär sökning
                String[] tmptitel = Loggboken[mellanvärde];
                //Jämföra användarposten med titeln på mitten av listan
                //tmp>0 Sökvärdet kommer att vara på andra hälften
                //tmp<0 sökvärdet kommer att vara på första hälften
                //tmp=0 sökvärdet kommer att vara lika index av mellanvärdet
                int tmp = text.CompareTo(tmptitel[0]);
                if (tmp > 0)
                    minvärde = mellanvärde + 1;
                else if (tmp < 0)
                    maxvärde = mellanvärde - 1;
                else
                    //Om den hittades
                    return mellanvärde;
            }
            //Om den inte hittas
            return -1;
        }
    }
}
