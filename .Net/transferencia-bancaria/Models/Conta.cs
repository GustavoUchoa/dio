using System;
using transferencia_bancaria.Enum;

namespace transferencia_bancaria.Models
{
    public class Conta
    {        
        public TipoConta TipoConta { get; set; }

        public string Nome { get; set; }        
        
        public double Saldo { get; set; }
        
        public double Credito { get; set; }

        public Conta()
        {
            
        }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public void Adicionar(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public void Sacar(Conta conta, double valorSaque)
        {
            if (SaldoSuficiente(conta, valorSaque))
                Console.WriteLine($"Saldo atual da conta de { this.Nome } é { this.Saldo }");
            else
                Console.WriteLine("Saldo insuficiente!");
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta de { this.Nome } é { this.Saldo }");
        }

        public void Transferir(Conta contaOrigem, double valorTransferencia, Conta contaDestino)
        {
            if (SaldoSuficiente(contaOrigem, valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                Console.WriteLine($"Transferido { valorTransferencia } da conta { contaOrigem.Nome } para { contaDestino.Nome }");
            }
            else
                Console.WriteLine("Saldo insuficiente!");
        }

        private bool SaldoSuficiente(Conta conta, double valorSaque)
        {
            if (conta.Saldo - valorSaque < (conta.Credito *-1))
                return false;
            else
                return true;
        }

        public override string ToString()
        {
            string retorno = string.Empty;

            retorno += $"TipoConta: { this.TipoConta } | "; 
            retorno += $"Nome: { this.Nome } | "; 
            retorno += $"Saldo: { this.Saldo } | "; 
            retorno += $"Crédito: { this.Credito } | "; 

            return retorno;
        }        
    }
}