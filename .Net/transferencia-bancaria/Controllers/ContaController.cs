using System.Collections.Generic;
using transferencia_bancaria.Models;
using transferencia_bancaria.Enum;

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
    }
}