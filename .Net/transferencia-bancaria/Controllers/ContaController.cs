using System.Collections.Generic;
using transferencia_bancaria.Enum;
using transferencia_bancaria.Models;

namespace transferencia_bancaria.Controllers
{
    public class ContaController
    {
        public ContaController()
        {

        }

        static List<Conta> listContas = new List<Conta>();

        public List<Conta> Listar()
        {
            return listContas;
        }

        public Conta Adicionar(TipoConta tipoConta, int CpfOuCnpj, string nome, double saldo, double credito)
        {
            Conta novaConta;

            if (tipoConta.Equals(TipoConta.PessoaFisica))
                novaConta = new ContaPessoaFisica();
            else
                novaConta = new ContaPessoaJuridica();

            novaConta.Adicionar(CpfOuCnpj, nome, saldo, credito);
            listContas.Add(novaConta);
            return novaConta;
        }

        public Conta Sacar(int indiceConta, double valorSaque)
        {
            Conta conta = listContas[indiceConta];

            if (conta.Sacar(conta, valorSaque))
                return conta;
            else
                return null;
        }

        public Conta Depositar(int indiceConta, double valorDeposito)
        {
            Conta conta = listContas[indiceConta];
            return conta.Depositar(conta, valorDeposito);
        }

        public Conta Transferir(int indiceContaOrigem, double valorDeposito, int indiceContaDestino)
        {
            Conta contaOrigem = listContas[indiceContaOrigem];
            Conta contaDestino = listContas[indiceContaDestino];

            if (contaOrigem.Transferir(valorDeposito, contaDestino))
                return contaOrigem;
            else
                return null;
        }
    }
}