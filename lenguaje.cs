using System;

//  Requerimiento 1: Grabar la fecha y hora en el log.
/*
Programa	-> 	Librerias Main
Librerias	->	#include<identificador.h>
Main		->	void main() 
			{
				numero;
			}
*/
namespace Sintaxis_1{
    public class lenguaje : Sintaxis{

        //Programa	-> 	Librerias Main
        public void Programa(){
            Librerias();
            Main();
        }

        //Librerias	->	#include<identificador.h>
        private void Librerias(){
            match("#");
            match("include");
            match("<");
            match(tipos.identificador);
            match(".");
            match("h");
            match(">");
        }

        /*
        Main		->	void main() 
			{
				numero;
			}
        */
        private void Main(){
            match("void");
            match("main");
            match("(");
            match(")");
            match("{");
            match(tipos.numero);
            match(tipos.fin_sentencia);
            match("}");
        }
    }
}