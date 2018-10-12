using System;

namespace ActivitatAuth
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Utils.IniFile();
            bool exit = false;
            ConsoleKeyInfo option;
            Console.Clear();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("************** AUTENTICACIO ********************");
                Console.WriteLine();
                Console.WriteLine("1............. VALIDAR-SE");
                Console.WriteLine("2............. REGISTRAR-SE");
                Console.WriteLine("0............. EXIT");
                Console.WriteLine("**************************************************");
                do
                {
                    // El ReadKey(true) és perquè no s'escrigui per tornarpantalla
                    option = Console.ReadKey(true);
                } while (option.KeyChar < '0' || option.KeyChar > '2');
                Console.Clear();
                switch (option.KeyChar)
                {
                    // Validar usuari
                    // Es demana usuari i password i es comprova
                    // si el vàlid es mostra el missatge de benvinguda
                    // cas contrari es mostra un avís
                    case '1':

                        break;




                    // Donar d'alta usuari
                    // Es demana nom d'usuari (es comprova validesa)
                    // Es demana el password es comprova si té criteris mínims
                    // Si passa criteri es demana per tornarsegon cop per tornarassegurar
                    // Finalment s'afegeix l'usuari/password al fitxer
                    case '2':

                        break;


                    // Sortim del programa   
                    case '0':
                        exit = true;
                        break;
                }

            }
        }
    }
}
