# ActivitatAut

Quan cal guardar les contrasenyes dels usuaris, necessitem un mecanisme que asseguri aquesta informació. Com hem vist a teoria, la forma més habitual és guardar un hash del password de manera que no sigui possible fer una recuperació del password. 
En aquesta activitat caldrà fer una aplicació en C# que realitzi el procés d’autenticació d’un sistema, per això tindrà les següents funcionalitats:
* Alta usuari: demanarà un nom d’usuari i un password (cal comprovar inicialment si el nom d’usuari ja existeix). Pel format utilitzat per defecte, no hauríem de permetre noms d’usuari amb espais.

* Autenticar: un cop demanat usuari/password comprovarà si l’autenticació és correcta, mostrant un missatge afirmatiu o negatiu. Si l’usuari introduït no existeix ha de treure un missatge d’error d’autenticació incorrecta. segons sigui el cas. 

* Mostrarà un menú inicial on ens deixarà triar quina opció volem fer (alta o autenticació).

* A la solució mínima, les dades dels usuaris es guardaran a un arxiu de text on cada línia correspondrà a un usuari i que haurà de seguir el format CSV: nom_usuari salt hash (separats amb comes).

## Orientacions

Per realitzar el procés de hash del password, usarem un salt aleatori, tot i que es poden usar directament les funcions de hash ja estudiades (MD5, SHA1, ...) usarem la funció HMACSHA que ofereix el RFC2898. El salt el crearem aleatòriament (per això caldrà guardar-lo després). Tot i que també seria vàlid utilitzar SHA256 o SHA512 sempre i quan useu salt. El fet que s’utilitzi aquesta implementació, a part de per la senzillesa, és que permet realitzar la funció múltiples vegades, el que fa que sigui “lenta” i per tant, dificulti l’atac per força bruta.

Per crear una salt aleatòria, per exemple, de 16 bytes podem utilitzar el següent codi:

```
byte [] salt;
new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
```

Per obtenir el hash a partir del password i de la salt (en aquest cas, volem un hash de 32 bytes -> 256 bits) obtingut amb 1000 iteracions (les iteracions dificulten els atacs de força bruta):

`
var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
byte[] hash = pbkdf2.GetBytes(32);
`

Un cop tenim els dos arrays de bytes, elss convertirem a string amb Convert.ToBase64String.

Per comprovar el password, haureu de fer els mateixos passos, però simplement, llegint el salt i convertint-lo posteriorment a bytes. Per obtenir la salt emmagatzemada, passem l’string a byte[] i amb Array.Copy ens quedem amb els primers 16 bytes.

Un cop obtingeu el hash, el compareu amb el que heu llegit del fitxer (de nou, cal o passar el primer a string o el segon a byte[]).

Per llegir un arxiu de text línia a línia podeu agafar com a base el següent exemple de MDSN: 

```
using (StreamReader lector = new StreamReader(Authentication.fitxerUsuaris))
			{
				while (lector.Peek() > -1)
				{
					string linia = lector.ReadLine();
				
					if (!String.IsNullOrEmpty(linia)) Console.WriteLine(linia);
            
					
				}

			}
```

El using permet definir l'àmbit d'ús de l'objecte creat i per tant, un cop utilitzat es fa automàticament l'alliberament del recurs.

Per escriure una línia en un fitxer, es fa de forma similar:

```
using (StreamWriter w = File.AppendText(fitxer))

{
		
    w.WriteLine(linia);
	
}
 
````

La pràctica cal implementar-la amb la captura d'errors (try/catch) i lliurant la solució bàsica té una qualificació màxima de 6 punts.
 
 ## Millores
 
 * Evitar que es pugui crear un usuari si el nom d’usuari ja existeix (1 punt)
 
 * Obligar a que el password tingui un nivell de complexitat: majúscules, minúscules i dígits (1 punt) 
 
 * Introduir una nova opció que permeti canviar el password de l'usuari.
 
 * Aplicació WPF o WinForms (2 punts)
 
 * Emmagatzemar les dades a una BD enlloc d’un arxiu de text. Podeu utilitzar qualsevol solució de SGBD però amb el SQLExpress o EntityFrameWork in memory ja en teniu prou. (3 punts)
 
