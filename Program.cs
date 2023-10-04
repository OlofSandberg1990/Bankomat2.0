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
            public List <Konton> AnvändarkontonList = new List <Konton> ();              //Aslso declared a new list so the Users kan havev uniqe accounts


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


                Console.WriteLine("Ange användarnamn");
                string inputAnvändarnamn = Console.ReadLine();

                if (tillfälligtDictionary.ContainsKey(inputAnvändarnamn))                               //if the dictionary has a key that contains a valid username, it gets
                {                                                                                       //stored in the temporary variable "tillfälligtAnvändarnamn"
                    var tillfälligtAnvändarnamn = tillfälligtDictionary[inputAnvändarnamn];
                    int antalFösök = 0;
                    while (true)
                    {

                        Console.WriteLine("Ange din 4-siffriga pinkod");
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


        static void Main(string[] args)
        {
            Användare användare1 = new Användare("Olof", "Sandberg", "olsa", 1111);                 //created 5 new users with new bankaccounts.
            användare1.AnvändarkontonList.Add(new Konton("Privatkonto", 1234m));                    //created new accounts for each user and added them right away to their uniqe Användarkonton-list.


            Användare användare2 = new Användare("Nina", "Lindberg Nilsson", "nili", 2222);
            användare2.AnvändarkontonList.Add(new Konton("Privatkonto", 449m));
            användare2.AnvändarkontonList.Add(new Konton("Sparkonto", 245670.45m));

            Användare användare3 = new Användare("Anna", "Svensson", "ansv", 3333);
            användare3.AnvändarkontonList.Add(new Konton("Privatkonto", 1233m));
            användare3.AnvändarkontonList.Add(new Konton("Sparkonto", 240955m));
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

            Dictionary<string, Användare> kundregisterDictionary = new Dictionary<string, Användare>();             //created a new dictionary for my users with string as a key-type and 
            kundregisterDictionary.Add(användare1.Användarnamn, användare1);                                        //Användare is the data type for the values in my dictionary.
            kundregisterDictionary.Add(användare2.Användarnamn, användare2);
            kundregisterDictionary.Add(användare3.Användarnamn, användare3);
            kundregisterDictionary.Add(användare4.Användarnamn, användare4);                                        //I added the users to the dictionary, with "användarnamn" as a key for
            kundregisterDictionary.Add(användare5.Användarnamn, användare5);                                        //accessing the properties for the uniqe användare (in this case användare4).

            var tillfälligAnvändare = LoggaIn(kundregisterDictionary);

        }

       

    }
}