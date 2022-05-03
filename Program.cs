using System;

namespace Sintaxis_1{
    public class Program{

        static void Main(string[] args){

            lenguaje a = new lenguaje();

            a.Programa();
            /*while(!a.FinArchivo()){
                a.NextToken();
            }*/
            a.Cerrar();
        }
    }
}