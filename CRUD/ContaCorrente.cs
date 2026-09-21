namespace CRUD
{
    public class ContaCorrente
    {
        public int Numero { get; set; }
        public string Titular { get; set; }
        public string TipoConta { get; set; }
        public decimal Saldo { get; set; }

        public ContaCorrente(int numero, string titular, string tipoConta, decimal saldo)
        {
            Numero = numero;
            Titular = titular;
            TipoConta = tipoConta;
            Saldo = saldo;
        }
    }
}