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
namespace Sintaxis_1
{
    public class lenguaje : Sintaxis
    {

        //Programa	-> 	Librerias? Variables? Main
        public void Programa()
        {
            Librerias();
            Variables();
            Main();
        }

        //Librerias	->	#include<identificador(.h)?> Librerias?
        private void Librerias()
        {
            if (getContenido() == "#")
            {
                match("#");
                match("include");
                match("<");
                match(tipos.identificador);
                if (getContenido() == ".")
                {
                    match(".");
                    match("h");
                }
                match(">");
                Librerias();
            }
        }

        // Variables -> tipo_dato Lista_identificadores ; Variables?
        private void Variables(){
            if(getClasificacion() == tipos.tipo_datos){
                match(tipos.tipo_datos);
                Lista_identificadores();
                match(tipos.fin_sentencia);
                Variables();
            }
        }

        // Lista_identificadores -> identificador (,Lista_identificadores)? 
        private void Lista_identificadores(){
            match(tipos.identificador);
            if(getContenido() == ","){
                match(",");
                Lista_identificadores();
            }
        }

        /*
        Main		->	void main() 
			{
				numero;
			}
        */
        private void Main()
        {
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