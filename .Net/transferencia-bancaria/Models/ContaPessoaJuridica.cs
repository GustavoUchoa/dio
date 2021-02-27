namespace transferencia_bancaria.Models
{
    public class ContaPessoaJuridica : Conta
    {
        public int Cnpj { get; set; }

        public override void Adicionar(int cnpj, string nome, double saldo, double credito)
        {
            this.Cnpj = cnpj;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public override string ToString()
        {
            string retorno = string.Empty;

            retorno += $"Pessoa Jurídica - "; 
            retorno += $"Cnpj: { this.Cnpj } | "; 
            retorno += $"Nome: { this.Nome } | "; 
            retorno += $"Saldo: { this.Saldo } | "; 
            retorno += $"Crédito: { this.Credito } | "; 

            return retorno;
        }
    }
}