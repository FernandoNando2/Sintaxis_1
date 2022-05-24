using System;

namespace Sintaxis_1{
    public class Sintaxis : Lexico{
        public Sintaxis(){
            NextToken();
        }

        public Sintaxis(String ruta) : base(ruta) {
            NextToken();
        }

        public void match(String espera){
            if(espera == getContenido())
                NextToken();
            else
                // Requerimiento 9: Agregar el numero de linea en el error.
                throw new Error("Error de sintaxis linea " +linea +": Se espera un " +espera +".", log);
        }

        public void match(tipos espera){
            if(espera == getClasificacion())
                NextToken();
            else
                // Requerimiento 9: Agregar el numero de linea en el error.
                throw new Error("Error de sintaxis linea " +linea +": Se espera un " +espera +".", log);
        }
    }
}