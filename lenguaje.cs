using System;
/*
Requerimiento 1: Grabar la fecha y hora en el log. ya
Requerimiento 2: Programar la produccion For -> for(Asignacion; Condicion; Incremento) bloqueInstrucciones | Instruccion ya
Requerimiento 3: Programar la produccion Incremento -> identificador ++ | -- ya 
Requerimiento 4: Programar la produccion Switch -> switch(Expresion){listaDeCasos} ya
Requerimiento 5: Programar la produccion listaDeCasos -> case Expresion: listaInstruccionesCase (break;)? (listaDeCasos)? duda bloqueInstrucciones
Requerimiento 6: Incluir en el Switch un default optativo. ya
Requerimiento 7: Levantar una excepción cuando el archivo prueba.cpp no exista. ya
Requerimiento 8: Si el programa a compilar es suma.cpp, debera generar un suma.log ya
Requerimiento 9: Es necesario que el error lexico o sintactico indique el numero de linea en el que ocurrio. ya
*/
namespace Sintaxis_1
{
    public class Lenguaje : Sintaxis
    {
        public Lenguaje(){

        }

        public Lenguaje(String ruta) : base(ruta) {

        }

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

        //listainstruccionesCase -> instruccion listaInstruccionesCase?
        private void listaInstruccionesCase()
        {
            instruccion();
            if (getContenido() != "case" && getContenido() != "default" && getContenido() != "}" && getContenido() != "break")
                listaInstruccionesCase();
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
            else if (getContenido() == "for")
                For();
            else if (getContenido() == "switch")
                Switch();
            else
                Asignacion();
        }

        // Asignacion -> identificador = cadena | Expresion ;
        private void Asignacion(){
            match(tipos.identificador);
            match("=");
            if(getClasificacion() == tipos.cadena)
                match(tipos.cadena);
            else
                Expresion();
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

        // For -> for(Asignacion Condicion; Incremento) bloqueInstrucciones | Instruccion  
        private void For(){
            match("for");
            match("(");
            Asignacion();
            Condicion();
            match(";");
            Incremento();
            match(")");
            if(getContenido() == "{")
                bloqueInstrucciones();
            else
                instruccion();
        }

        // Incremento -> Identificador ++ | --
        private void Incremento(){
            match(tipos.identificador);
            if(getContenido() == "++")
                match("++");
            else
                match("--");
        }

        // Switch -> switch(Expresion){listaDeCasos}
        private void Switch(){
            match("switch");
            match("(");
            Expresion();
            match(")");
            match("{");
            listaDeCasos();
            if(getContenido() == "default"){
                match("default");
                match(":");
                listaInstruccionesCase();
                if(getContenido() == "break"){
                    match("break");
                    match(";");
                }
            }
            match("}");
        }

        // listaDeCasos -> case Expresion: listaInstruccionesCase (break;)? (listaDeCasos)?
        private void listaDeCasos(){
            match("case");
            Expresion();
            match(":");
            listaInstruccionesCase();
            if(getContenido() == "break") {
                match("break");
                match(tipos.fin_sentencia);
            }      
            if(getContenido() == "case")
                listaDeCasos();
        }

        //Condicion -> Expresion operador_relacional Expresion
        private void Condicion(){
            Expresion();
            match(tipos.operador_relacional);
            Expresion();
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
        
        // Expresion -> Termino MasTermino
        private void Expresion(){
            termino();
            masTermino();
        }
        
        // MasTermino -> (operador_termino Termino)?
        private void masTermino(){
            if(getClasificacion() == tipos.operador_termino){
                match(tipos.operador_termino);
                termino();
            }
        }
        
        // Termino -> Factor PorFactor
        private void termino(){
            factor();
            porFactor();
        }
        
        // PorFactor -> (operador_factor Factor)?
        private void porFactor(){
            if(getClasificacion() == tipos.operador_factor){
                match(tipos.operador_factor);
                factor();
            }
        }
        
        // Factor -> numero | identificador | (Expresion) 
        private void factor(){
            if(getClasificacion() == tipos.numero)
                match(tipos.numero);
            else if(getClasificacion() == tipos.identificador)
                match(tipos.identificador);
            else{
                match("(");
                Expresion();
                match(")");
            }
        }

    }
}