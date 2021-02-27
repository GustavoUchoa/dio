using System;
using transferencia_bancaria.Enum;

namespace transferencia_bancaria.Models
{
    public abstract class Conta
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

        public virtual void Adicionar(int tipoConta, string nome, double saldo, double credito)
        {

        }

        public bool Sacar(Conta conta, double valorSaque)
        {
            if (SaldoSuficiente(conta, valorSaque))
            {
                this.Saldo -= valorSaque;
                return true;
            }
            else
                return false;
        }

        public Conta Depositar(Conta conta, double valorDeposito)
        {
            conta.Saldo += valorDeposito;
            return conta;
        }

        public bool Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(this, valorTransferencia))
            {
                Depositar(contaDestino, valorTransferencia);
                return true;
            }
            else
                return false;
        }

        private bool SaldoSuficiente(Conta conta, double valorSaque)
        {
            if (conta.Saldo - valorSaque < (conta.Credito * -1))
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