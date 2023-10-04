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
            public double Saldo;    

            public Konton(string kontonamn, double saldo)
                {
                    Kontonamn = kontonamn;                                          //A constructor for the variables above.
                Saldo = saldo;
                }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}