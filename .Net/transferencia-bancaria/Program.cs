using transferencia_bancaria.Views;

namespace transferencia_bancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Transferencia transferencia = new Transferencia();
            
            transferencia.Menu();
            transferencia.ExecutarOpcao();
        }        
    }
}