using System;

namespace Sintaxis_1{
    public class Program{

        static void Main(string[] args){

            Sintaxis a = new Sintaxis();

            a.match("using");
            a.match(Token.tipos.identificador);
            a.match(";");
            /*while(!a.FinArchivo()){
                a.NextToken();
            }*/
            a.Cerrar();
        }
    }
}