﻿using System;
using System.Security.Cryptography;

namespace ActivitatAuth

{
    public static class Criptografia
    {

        // Mides de la sal i el hash
        // La sal en format Base64 té una mida de 24 caràcters
        private const int LongSalt = 16;
        private const int LongHash = 32;
        private const int LongSalB64 = 24;


        /// <summary>
        /// Comprova si un usuari/password és correcte
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>true si ha tingut èxit false cas contrari</returns>
        public static bool ComprovaUsuari(string user, string password)
        {
            try
            {


            }
            catch
            {
                return false;
            }


        }



        /// <summary>
        /// Cridem funció calcula el hash del password de l'usuari
        /// i cridem a la funció escriure fitxer
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>true si es realitza amb èxit false si error</returns>
        public static bool AltaUsuari(string user, string password)
        {
            try
            {
               

                return true;
            }
            catch
            {
                return false;

            }
        }


        /// <summary>
        /// Introducció per teclar del password de forma segura
        /// per pantalla es mostra un * per cada caràcter
        /// </summary>
        /// <returns>El password en un SecureString</returns>
        public static string EntraPassword()
        {
            string password = null;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    Console.Write("\b \b");

                }
            }
            while (key.Key != ConsoleKey.Enter);
            return password;

        }

        /// <summary>
        ///  Calcula salt aleatòria
        /// </summary>
        /// <returns>array de bytes corresponents a la salt</returns>
        private static byte[] CalculaSalAleatoria()
        {
            byte[] sal;
            new RNGCryptoServiceProvider().GetBytes(sal = new byte[LongSalt]);
            return sal;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="sal"></param>
        /// <returns></returns>
        private static string CalculaHash(string password, byte[] sal)
        {
            try
            {

                var pbkdf2 = new Rfc2898DeriveBytes(password, sal, 1000);
                byte[] hash = pbkdf2.GetBytes(LongHash);
                return Convert.ToBase64String(sal) + Convert.ToBase64String(hash);

            }
            catch
            {
                return null;
            }

        }

    }
}
