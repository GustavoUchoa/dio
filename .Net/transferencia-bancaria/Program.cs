using System;
using transferencia_bancaria.Models;
using transferencia_bancaria.Enum;

namespace transferencia_bancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta conta = new Conta(TipoConta.PessoaFisica, "Gustavo", 1000, 100);
            Console.WriteLine(conta.ToString());
        }
    }
}
