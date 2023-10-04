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
        }
    }
}