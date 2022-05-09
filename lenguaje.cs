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
                listaIdentificadores();
                match(tipos.fin_sentencia);
                Variables();
            }
        }

        // Lista_identificadores -> identificador (,Lista_identificadores)? 
        private void listaIdentificadores(){
            match(tipos.identificador);
            if(getContenido() == ","){
                match(",");
                listaIdentificadores();
            }
        }

        // Bloque de instrucciones -> {Lista de instrucciones?}
        private void bloqueInstrucciones(){
            match("{");
            if(getContenido() != "}")
                listaInstrucciones();
            match("}");
        }

        //listainstrucciones -> instruccion listadeinstrucciones?
        private void listaInstrucciones()
        {
            instruccion();
            if (getContenido() != "}")
                listaInstrucciones();
        }

        // Instruccion -> Printf | Scanf | If | While | do while | Asignacion
        private void instruccion(){
            if(getContenido() == "printf")
                Printf();
            else if (getContenido() == "scanf")
                Scanf();
            else if (getContenido() == "if") 
                If();
            else if (getContenido() == "while")
                While();
            else if (getContenido() == "do")
                Do();
            else
                Asignacion();
        }

        // Asignacion -> identificador = cadena | numero | identificador ;
        private void Asignacion(){
            match(tipos.identificador);
            match("=");
            if(getClasificacion() == tipos.cadena)
                match(tipos.cadena);
            else if(getClasificacion() == tipos.numero)
                match(tipos.numero);
            else
                match(tipos.identificador);
            match(";");
        }

        // While -> while(Condicion) bloqueInstrucciones | instruccion
        private void While(){
            match("while");
            match("(");
            Condicion();
            match(")");
            if(getContenido() == "{")
                bloqueInstrucciones();
            else
                instruccion();
        }

        //Do -> do bloqueInstrucciones | instruccion while(Condicion);
        private void Do(){
            match("do");
            if(getContenido() == "{")
                bloqueInstrucciones();
            else
                instruccion();
            match("while");
            match("(");
            Condicion();
            match(")");
            match(";");
        }

        //Condicion -> numero operador_relacional numero
        private void Condicion(){
            match(tipos.numero);
            match(tipos.operador_relacional);
            match(tipos.numero);
        }

        // If -> if(Condicion) Bloque de instrucciones (Else bloqueInstrucciones)?
        private void If(){
            match("if");
            match("(");
            Condicion();
            match(")");
            if(getContenido() == "{")
                bloqueInstrucciones();
            else
                instruccion();
            if(getContenido() == "else"){
                match("else");
                if(getContenido() == "{")
                    bloqueInstrucciones();
                else
                    instruccion();
            }
        }

        // Printf -> printf(cadena);
        private void Printf(){
            match("printf");
            match("(");
            match(tipos.cadena);
            match(")");
            match(tipos.fin_sentencia);
        }

        // Scanf -> scanf(cadena);
        private void Scanf(){
            match("scanf");
            match("(");
            match(tipos.cadena);
            match(")");
            match(tipos.fin_sentencia);
        }

        // Main -> void main() Bloque de instrucciones
        private void Main()
        {
            match("void");
            match("main");
            match("(");
            match(")");
            bloqueInstrucciones();
        }
        
    }
}