namespace transferencia_bancaria.Models
{
    public class ContaPessoaFisica : Conta
    {
        public int Cpf { get; set; }

        public override void Adicionar(int cpf, string nome, double saldo, double credito)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public override string ToString()
        {
            string retorno = string.Empty;

            retorno += $"Pessoa Física - "; 
            retorno += $"Cpf: { this.Cpf } | "; 
            retorno += $"Nome: { this.Nome } | "; 
            retorno += $"Saldo: { this.Saldo } | "; 
            retorno += $"Crédito: { this.Credito } | "; 

            return retorno;
        }
    }
}