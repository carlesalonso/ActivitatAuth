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
                        string nomUsuari;
                        string passUsuari = null;
                        Console.Write("Entra nom d'usuari: ");
                        nomUsuari = Utils.EntraUsuari();

                        Console.Write("Entra la passphrasse: ");
                        passUsuari = Criptografia.EntraPassword();
                        Console.WriteLine();
                        if (Criptografia.ComprovaUsuari(nomUsuari, passUsuari))

                            Console.WriteLine("Benvingut {0} ", nomUsuari);
                        else
                        {
                            Console.WriteLine("Usuari o validació incorrecta!");
                        }

                        Console.ReadKey();
                        passUsuari = null;
                        break;




                    // Donar d'alta usuari
                    // Es demana nom d'usuari (es comprova validesa)
                    // Es demana el password es comprova si té criteris mínims
                    // Si passa criteri es demana per tornarsegon cop per tornarassegurar
                    // Finalment s'afegeix l'usuari/password al fitxer
                    case '2':
                        Console.Write("Entra nom usuari: ");
                        nomUsuari = Utils.EntraUsuari();
                        if (string.IsNullOrEmpty(nomUsuari))
                        {

                            Console.WriteLine("No té format vàlid de nom d'usuari (prem una tecla per tornar menu)");
                            Console.WriteLine("El nom només pot contenir lletres, nombres i - o _ i ha de tenir almenys 4 caràcters");
                            Console.ReadKey();
                            break;
                        }

                        try
                        {
                            string tmp = Utils.LlegirUsuari(nomUsuari);
                            if (!string.IsNullOrEmpty(tmp))
                            {
                                Console.WriteLine("L'usuari ja existeix(prem una tecla per tornar menu)");
                                Console.ReadKey();
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("No es pot llegir el fitxer d'usuaris (prem una tecla per tornar menu)");
                            Console.ReadKey();
                            exit = true;
                            break;
                        }


                        //passUsuari = Criptografia.EntraPassword();
                        passUsuari = null;
                        do
                        {
                            Console.Write("Entra la passphrasse (mínim 6 caràcters): ");
                            passUsuari = Criptografia.EntraPassword();
                            Console.WriteLine();
                        } while (passUsuari.Length < 6);


                        Console.Write("Torna a entrar el password: ");

                        if (!passUsuari.Equals(Criptografia.EntraPassword()))
                        {

                            Console.WriteLine("\n Els passwords no coincideixen (prem una tecla per tornar menu)");
                            passUsuari = null;
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine();
                        bool fet = Criptografia.AltaUsuari(nomUsuari, passUsuari);
                        Console.WriteLine((fet ? "Usuari donat d'alta" : "No s'ha pogut donar d'alta a l'usuari"));
                        Console.WriteLine("(prem una tecla per tornar menu)");
                        Console.ReadKey();
                        passUsuari = null;
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
