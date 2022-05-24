using System;

namespace Sintaxis_1{
    public class Error : Exception{
        public Error(String mensaje, StreamWriter log) {
            Console.WriteLine(mensaje);
            log.WriteLine(mensaje);
        }
    }
}