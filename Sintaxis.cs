using System;

namespace Sintaxis_1{
    public class Sintaxis : Lexico{
        public Sintaxis(){
            NextToken();
        }

        public void match(String espera){
            if(espera == getContenido()){
                NextToken();
            }
            else{
                Console.WriteLine("Error de sintaxis: Se espera un " +espera );
                log.WriteLine("Error de sintaxis: Se espera un " +espera );
            }
        }

        public void match(tipos espera){
            if(espera == getClasificacion()){
                NextToken();
            }
            else{
                Console.WriteLine("Error de sintaxis: Se espera un " +espera +".");
                log.WriteLine("Error de sintaxis: Se espera un " +espera +".");
            }
        }
    }
}