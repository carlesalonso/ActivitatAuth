# ActivitatAut

Quan cal guardar les contrasenyes dels usuaris, necessitem un mecanisme que asseguri aquesta informació. Com hem vist a teoria, la forma més habitual és guardar un hash del password de manera que no sigui possible fer una recuperació del password. 
En aquesta activitat caldrà fer una aplicació en C# que realitzi el procés d’autenticació d’un sistema, per això tindrà les següents funcionalitats:
* Alta usuari: demanarà un nom d’usuari i un password (cal comprovar inicialment si el nom d’usuari ja existeix). Pel format utilitzat per defecte, no hauríem de permetre noms d’usuari amb espais.

* Autenticar: un cop demanat usuari/password comprovarà si l’autenticació és correcta, mostrant un missatge afirmatiu o negatiu, •	Si l’usuari introduït no existeix ha de treure un missatge d’error d’autenticació incorrecta. segons sigui el cas. 

* Mostrarà un menú inicial on ens deixarà triar quina opció volem fer (alta o autenticació).

* A la solució mínima, les dades dels usuaris es guardaran a un arxiu de text on cada línia correspondrà a un usuari i que haurà de seguir el format CSV: nom_usuari salt hash (separats amb comes).

