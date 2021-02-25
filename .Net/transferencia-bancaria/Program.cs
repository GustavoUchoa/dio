using System;
using transferencia_bancaria.Models;

namespace transferencia_bancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();        

            Console.WriteLine(conta1.ToString());
        }
    }
}
