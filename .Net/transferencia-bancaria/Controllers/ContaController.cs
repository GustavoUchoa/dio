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

        public Conta Adicionar(TipoConta tipoConta, string nome, double saldo, double credito)        
        {
            Conta novaConta = new Conta();

            novaConta.Adicionar(tipoConta, nome, saldo, credito);
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
    }
}