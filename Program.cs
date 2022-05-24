using System;

namespace Sintaxis_1{
    public class Program{

        static void Main(string[] args){

            try{
                Lenguaje a = new Lenguaje("C:\\Users\\Fernando Hernandez\\Desktop\\ITQ\\4to Semestre\\Lenguajes y Autómatas 1\\Sintaxis 1\\examen.cpp");

                a.Programa();
                /*while(!a.FinArchivo()){
                    a.NextToken();
                }*/
                a.Cerrar();
            }
            catch(Exception e){
                Console.WriteLine("Fin de compilacion.");
            }
        }
    }
}