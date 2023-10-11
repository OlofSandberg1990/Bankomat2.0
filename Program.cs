using System.Runtime.CompilerServices;
using System.Threading.Channels;
using static Bankomat2._0.Program;

namespace Bankomat2._0
{
    internal class Program
    {
        public class Användare
        {
            public string Förnamn;
            public string Efternamn;                                                    //created a new class with some variables for the users of the bank.
            public string Användarnamn;
            public int Pinkod;
            public List<Konton> AnvändarkontonList = new List<Konton>();              //Also declared a new list so the Users kan havev uniqe accounts. The list is designed to store instances of the Konton class.
                                                                                      


            public Användare(string förnamn, string efternamn, string användarnamn, int pinkod)
            {

                Förnamn = förnamn;
                Efternamn = efternamn;                                                  //Made a constructor for the variables
                Användarnamn = användarnamn;
                Pinkod = pinkod;


            }
           

        }

        public class Konton
        {

            public string Kontonamn;                                                //Another class for the bankaccounts
            public decimal Saldo;

            public Konton(string kontonamn, decimal saldo)
            {
                Kontonamn = kontonamn;                                          //A constructor for the variables above.
                Saldo = saldo;
            }

        }

        public static Användare LoggaIn(Dictionary<string, Användare> tillfälligtDictionary)            //created a method to handle a user login and return a logged in user.
        {


            while (true)
            {


                Console.WriteLine("Ange användarnamn : ");
                string inputAnvändarnamn = Console.ReadLine();

                if (tillfälligtDictionary.ContainsKey(inputAnvändarnamn))                               //if the dictionary has a key that contains a valid username, it gets
                {                                                                                       //stored in the temporary variable "tillfälligtAnvändarnamn"
                    var tillfälligtAnvändarnamn = tillfälligtDictionary[inputAnvändarnamn];
                    int antalFösök = 0;
                    while (true)
                    {

                        Console.WriteLine("Ange din 4-siffriga pinkod : ");
                        int inputPinkod = 0;

                        try
                        {
                            inputPinkod = int.Parse(Console.ReadLine());                                //Try to convert the inputPinkod to a valid int. It it's not valid an error-message
                        }                                                                           //occur, but the program will continue to run.
                        catch (Exception)
                        {
                            Console.WriteLine("Fel inmatning, pinkoden måste vara 4 siffror");

                        }


                        if (tillfälligtAnvändarnamn.Pinkod == inputPinkod)                          //if the pinKod of tillfälligAnvändare is equal to the inputPinkod the method will 
                        {                                                                           //return the information of tillfälligtAnvändarnamn...
                            Console.WriteLine("Inloggning lyckades!");
                            Console.ReadKey();
                            return tillfälligtAnvändarnamn;
                        } else
                        {
                            antalFösök++;
                            Console.WriteLine("Fel pinkod");                                           //...else it will show that the user tried the wrong pincode and the number
                            Console.WriteLine($"Försök {antalFösök}/3");                                //of tries will be shown.
                            Console.WriteLine();
                        }

                        if (antalFösök == 3)
                        {
                            Console.WriteLine("Antal försök har överskridits, programmet avslutas");    //If the user tries more than three times, the program will be shut down.
                            Console.ReadKey();
                            Environment.Exit(0);
                        }



                    }

                } else
                {
                    Console.WriteLine("Ingen användare kunde hittas");                  //And if the användarnamn could not be found, the program will just continue to run
                }                                                                       //since our Bool is set to "true".
            }


        }

        static void VisaKonton(Användare tillfälligAnvändare)                                       //created a method to show the user their accounts.
        {
            int kontoIndex = 0;

            foreach (var konton in tillfälligAnvändare.AnvändarkontonList)                          //using a foreach-loop the write ut the accounts. Also an int called kontoIndex to get a number for each account.
            {
                kontoIndex++;

                Console.WriteLine($"{kontoIndex}, {konton.Kontonamn}        {konton.Saldo}kr");

            }



        }

        public static decimal KollaDecimalInput()                               //created a method to make sure a decimal is written is a correct format and is not a negative number 
        {

            bool fortsättLoop = true;
            decimal värdeAttKolla = 0;
            while (fortsättLoop)                                         //a while-loop so you can try again if the input is not a valid decimal          
            {
                
                try
                {
                    värdeAttKolla = Convert.ToDecimal(Console.ReadLine());          //try to convert the number input from the user to a decimal
                    

                    if (värdeAttKolla > 0)                                          // If it is correct, check so the input is a positive number
                    {

                        fortsättLoop = false;                                       //If it is, the bool will return false, and the value of värdeAttKolla will be returned from the method.
                    } else
                    {
                        Console.WriteLine("Beloppet kan inte vara negativt, försök igen");      //If the number is negative, the loop will continue to execute.
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");           //A message will be written if the convert fails, and the loop will continue to execute.
                    
                    
                }
                
            }
            return värdeAttKolla;

        }

        static void Meny(string namn)                   // created a new method with one in-parameter called namn. This will get the "förnamn" of the logged in user.
        {
            Random rand = new Random();
            int slumpaNummer = rand.Next(0, 4);         //created a new random, and an int called "slumpaNummer". This will be used to randomize a number between 0 - 3.

            string[] citatArray = new string[4];        //an array with 4 different quotes about economy. 

            citatArray[0] = "”Ränta-på-ränta är världens åttonde underverk.” – Albert Einstein";
            citatArray[1] = "“Köp billigt, sälj dyrt!” – Benjamin Graham";
            citatArray[2] = "”Riktig koll på sin ekonomi har man bara när man inte behöver det. Tack och lov sker detta inte allt för ofta.” - Okänd";
            citatArray[3] = "”Det finns ett sätt att lösa samtliga ekonomiska problem: att göra självgodheten skattepliktig.” - Jacques Tati";

            Console.Clear();


            Console.WriteLine("=======Bankomat=======");
            Console.WriteLine();
            Console.WriteLine("Välkommen " + namn);             //Shows a welcome-message with the users firstname. 

            Console.WriteLine("1, Se dina konton och saldo");
            Console.WriteLine("2, Överföring mellan konton");   //A simple menu with 5 different options.
            Console.WriteLine("3, Sätt in pengar");
            Console.WriteLine("4, Ta ut pengar");
            Console.WriteLine("5, Logga ut");
            Console.WriteLine();
            Console.WriteLine(citatArray[slumpaNummer]);        //In the bottom of the menu, one of the four economy-quotes from the citatArray will be shown.


        }


        static void KontonOchSaldo(Användare tillfälligAnvändare)                       //Another method to show the users bank-accounts.
        {
            Console.WriteLine("=======Konton och saldo =======");
            Console.WriteLine();
            VisaKonton(tillfälligAnvändare);

            Console.WriteLine();
            Console.WriteLine("Tryck på enter för att gå tillbaka till huvudmenyn");
            Console.ReadKey();                                                                  //A readkey to stop the program followed by console.clear to clean the console before going back to our
            Console.Clear();                                                                    //main method


        }

        static void Insättning(Användare tillfälligAnvändare)
        {
            Console.WriteLine("=======Instänning=======");
            Console.WriteLine();
            Console.WriteLine("Hur mycket pengar vill du sätta in?");                   //Asking the user to insert the amount he/she wants to deposit.


            decimal inputInsättning = KollaDecimalInput();                              //declare a new decimal, and run it through the KollaDecimalInput-method.


            Console.WriteLine("Till vilket konto vill du sätta in pengarna?");

            bool kontoValBool = true;
            VisaKonton(tillfälligAnvändare);                                    //show a list of the users bankaccounts.
            int inputVal = 0;                                                   //declaring a new int outside the while-loop.
            while (kontoValBool)
            {
                                
                try
                {
                    inputVal = Convert.ToInt32(Console.ReadLine());                                         //The selected account gets stored in the variable "valtKonto". The -1 is there since  
                    var valtKonto = tillfälligAnvändare.AnvändarkontonList[inputVal - 1];                   //the index of the list starts on 0 and not 1.
                    Console.WriteLine($"{inputInsättning}kr sattes in på {valtKonto.Kontonamn}");           

                    valtKonto.Saldo += inputInsättning;                                                     //Adding the deposit to the users choice of account.

                    Console.WriteLine("Nytt saldo : " + valtKonto.Saldo);
                    Console.WriteLine();
                    Console.WriteLine("Tryck på enter för att komma tillbaka till huvudmenyn");
                    Console.ReadKey();
                    Console.Clear();
                    kontoValBool = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");                                   //If the inputVal isn't a valid choice, this message will be printed and the user needs to try again
                    
                }

            }


        }

        static void BeräftaPinkod(Användare tillfälligAnvändare)
        {
            int inputPinkod = 0;
            Console.WriteLine("Bekräfta din pinkod : ");
            while (tillfälligAnvändare.Pinkod != inputPinkod)                   //if the inputPinkod is the same as tillfälligAnvädare.pinkod the bool will return false.
            {
                try
                {
                    inputPinkod = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");       //If the input pinkod isn't a valid int, the bool will run again from the begining
                    continue;
                }


                if (inputPinkod == tillfälligAnvändare.Pinkod)
                {
                    Console.WriteLine("Pinkod korrekt");                        //if the inputPinkod is equal to tillfälligAnvändare.Pinkod the method will exit.
                    return;
                }
                Console.WriteLine("Fel pinkod, försök igen");

            }


        }

        static void Uttag(Användare tillfälligAnvändare)                        //created another method for Uttag. Copied pretty much from my code Isättning above.
        {

            Console.WriteLine("=======Uttag=======");
            Console.WriteLine();
            Console.WriteLine("Hur mycket pengar vill du ta ut?");

            decimal inputUttag = KollaDecimalInput();                               //declare a new decimal, and run it through the KollaDecimalInput-method.


            Console.WriteLine("Från vilket konto vill du ta ut pengar?");
                        
            VisaKonton(tillfälligAnvändare);
            int inputVal = 0;
            bool taUtPengar = true;

            while (taUtPengar)
            {

                try
                {
                    inputVal = Convert.ToInt32(Console.ReadLine());
                    var valtKonto = tillfälligAnvändare.AnvändarkontonList[inputVal - 1];

                    if (valtKonto.Saldo > inputUttag)                                                                  //An if-statement to make sure the balance of the account is more than the amount the users wants to withdraw.
                    {

                        BeräftaPinkod(tillfälligAnvändare);                                                 //if the balance of the chosen user account is more than the inputUttag, the mehod for confirm your pincode will be executed.

                        valtKonto.Saldo -= inputUttag;                                                      //the withdrawal will be made from the chosen account. 

                        Console.WriteLine("Uttag lyckades");
                        Console.WriteLine($"Nytt lado för {valtKonto.Kontonamn} är {valtKonto.Saldo}kr.");
                        Console.WriteLine();
                        Console.WriteLine("Tryck på enter för att komma tillbaka till huvudmenyn");
                        Console.ReadKey();
                        Console.Clear();
                        taUtPengar = false;

                    } else
                    {
                        Console.WriteLine("För lite pengar på kontot");
                        Console.WriteLine();
                        Console.WriteLine("Tryck på enter för att komma tillbaka till huvudmenyn");
                        Console.ReadKey();
                        taUtPengar = false;
                        Console.Clear();
                        
                        
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, ange en giltlig siffra");


                }

            }




        }

        static void ÖverföringMellanKonton(Användare tillfälligAnvändare)      //created a new method för transfer between accounts. Copied much of the code from "Insättning" and 
        {                                                                       //"Uttag"

            Console.WriteLine("=======Uttag=======");
            Console.WriteLine();
            Console.WriteLine("Från vilket konto vill du föra över pengar?");


            VisaKonton(tillfälligAnvändare);                                    //Show the menu of bankaccounts.

            int inputFrånKonto = 0;

            bool inputBool = true;
            while (inputBool)                                                   //A while-loop that runs until the user inserts a valid int as a choice for the menu.
            {
                try
                {
                    inputFrånKonto = Convert.ToInt32(Console.ReadLine());
                    if (inputFrånKonto > tillfälligAnvändare.AnvändarkontonList.Count || inputFrånKonto == 0)           //controlling so the number inserted is not bigger than the number of accounts. Also checks so the users input isn't zero.
                    {
                        Console.WriteLine("Konto hittades inte. Vänligen ange ett giltigt alternativ");
                        continue;
                    }

                    inputBool = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");
                                      


                }
            }
            var valtKontoUttag = tillfälligAnvändare.AnvändarkontonList[inputFrånKonto - 1];

            Console.WriteLine("Hur mycket pengar vill du föra över?");

            decimal överföringSumma = KollaDecimalInput();                              //delcaring a new decimal and run in through the KollaDecimalInput-method. 

            if (överföringSumma < valtKontoUttag.Saldo)                                 //controlling so the balance of the account is greater than the amount the user wants to withdraw from the account. 
            {
                valtKontoUttag.Saldo -= överföringSumma;                                //Subtracting the wished withdraw from the accunt.

            } else
            {
                Console.WriteLine("För lite pengar på kontot");                         //If the account dosen't have enough balance, the method will be closed and the user will return to the menu.
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Till vilket konto vill du föra över?");

            VisaKonton(tillfälligAnvändare);

            int inputFrånKonto2 = 0;

            bool inputBool2 = true;
            while (inputBool2)                                                              //creating a new while-loop so the user can chose wich account the money should be deposited on.
            {
 
                try
                {
                    inputFrånKonto2 = Convert.ToInt32(Console.ReadLine());
                    if (inputFrånKonto2 > tillfälligAnvändare.AnvändarkontonList.Count || inputFrånKonto2 == 0)
                    {
                        Console.WriteLine("Konton hittades inte, vänigen ange ett giltigt alternativ");
                        continue;
                    }  
                    
                    inputBool2 = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning, försök igen");



                }
            }
            var valtkontoInsättning = tillfälligAnvändare.AnvändarkontonList[inputFrånKonto2 - 1];

            valtkontoInsättning.Saldo += överföringSumma;                                                                  //And the last thing in this method the amount is added to the bankaccount that the user has chosen.

            Console.WriteLine($"Nytt saldo : {valtKontoUttag.Kontonamn}     {valtKontoUttag.Saldo}");
            Console.WriteLine($"Nytt saldo : {valtkontoInsättning.Kontonamn}     {valtkontoInsättning.Saldo}");
            Console.WriteLine();
            Console.WriteLine("Tryck på enter för att komma tillbaka till huvudmenyn");
            Console.ReadLine();
            Console.Clear();


        }



        static void Main(string[] args)
        {
            Användare användare1 = new Användare("Olof", "Sandberg", "olsa", 1111);                 //created 5 new users with new bankaccounts.
            användare1.AnvändarkontonList.Add(new Konton("Privatkonto", 1234m));                    //created new accounts for each user and added them right away to their uniqe Användarkonton-list. I'll explain the details in the 
                                                                                                    //code beneath.

            Användare användare2 = new Användare("Nina", "Lindberg Nilsson", "nili", 2222);         //so in this example I created a new user called användare2. She is created from the class Användare and the values inserted is 
                                                                                                    //Förnamn, Efternamn, Användarnamn and Pinkod...


            användare2.AnvändarkontonList.Add(new Konton("Privatkonto", 449m));                     //... And here I created two new bankaccounts for Nina. First I called Ninas uniqe AnvändarekontonList by writing
                                                                                                    //användare2(which is Nina) before calling the list. Then added a new instance from the class Konton, which contains two variables - 
                                                                                                    //one string called 'kontonamn' and one decimal called 'saldo'. So the 'kontonamn' and 'saldo' for this new object is 
                                                                                                    // 'Privatkonto' and '449'. 


            användare2.AnvändarkontonList.Add(new Konton("Sparkonto", 245670.45m));

            Användare användare3 = new Användare("Anna", "Svensson", "ansv", 3333);
            användare3.AnvändarkontonList.Add(new Konton("Privatkonto", 1233m));
            användare3.AnvändarkontonList.Add(new Konton("Sparkonto", 240955m));                      //Proceeded to add new objects (new bankaccount) for each user (användare).
            användare3.AnvändarkontonList.Add(new Konton("Pensionskonto", 191000m));

            Användare användare4 = new Användare("Lena", "Bengtsson", "lebe", 4444);
            användare4.AnvändarkontonList.Add(new Konton("Privatkonto", 12944.49m));
            användare4.AnvändarkontonList.Add(new Konton("Sparkonto", 7599m));
            användare4.AnvändarkontonList.Add(new Konton("Pensionskonto", 22800m));
            användare4.AnvändarkontonList.Add(new Konton("Nöjeskonto", 7800m));

            Användare användare5 = new Användare("Johan", "Johansson", "jojo", 5555);
            användare5.AnvändarkontonList.Add(new Konton("Privatkonto", 89.44m));
            användare5.AnvändarkontonList.Add(new Konton("Sparkonto", 822440m));
            användare5.AnvändarkontonList.Add(new Konton("Pensionskonto", 141299m));
            användare5.AnvändarkontonList.Add(new Konton("Nöjeskonto", 420m));
            användare5.AnvändarkontonList.Add(new Konton("Resekonto", 6700m));

            Dictionary<string, Användare> kundregisterDictionary = new Dictionary<string, Användare>();             //created a new dictionary for my users with string as a Key and Användare as Value.
                                                                                                                    //The key means that If i want to retrieve something in my dictionary, I have to call a string.
                                                                                                                    //And the things I call is the variables in my Användare-class.
            kundregisterDictionary.Add(användare1.Användarnamn, användare1);                                        
            kundregisterDictionary.Add(användare2.Användarnamn, användare2);
            kundregisterDictionary.Add(användare3.Användarnamn, användare3);
            kundregisterDictionary.Add(användare4.Användarnamn, användare4);                                        //I added the users to the dictionary, with the string 'Användarnamn' as a key.
            kundregisterDictionary.Add(användare5.Användarnamn, användare5);                                        //So easily explaned - I add the user (in this case användare5) and then defines the key
                                                                                                                    //which I want to be Användarnamn. And last get the instances for for the specific user behind the 
                                                                                                                    //comma, which in this case of course is the properties of användare5.


            bool körProgram = true;
            while (körProgram)
            {
                var tillfälligAnvändare = LoggaIn(kundregisterDictionary);                          //created 2 while-loops and 2 bools. One loop to run the program and one for when you're logged in.
                bool inloggad = true;

                while (inloggad)
                {


                    Meny(tillfälligAnvändare.Förnamn);

                    char val = Console.ReadKey().KeyChar;
                    Console.Clear();

                    switch (val)
                    {
                        case '1':
                            KontonOchSaldo(tillfälligAnvändare);
                            break;
                        case '2':
                            ÖverföringMellanKonton(tillfälligAnvändare);                            //A switch-case to call the different methods.
                            break;
                        case '3':
                            Insättning(tillfälligAnvändare);
                            break;
                        case '4':
                            Uttag(tillfälligAnvändare);
                            break;
                        case '5':
                            Console.WriteLine("Tack för ditt besök, du loggas nu ut");
                            Console.ReadKey();                                                     //If the user chose "Logga ut" the inloggad-bool will be set to false, and you come back to the login menu.
                            Console.Clear();
                            inloggad = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltligt val, försök igen");
                            Console.ReadKey();

                            break;
                    }

                }



            }






        }



    }
}
