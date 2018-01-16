namespace TestDriveStandard.Models
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public string PrecoFormatado => string.Format("R$ {0}", Preco);
    }

    public class VeiculoJson
    {
        public string nome { get; set; }
        public decimal preco { get; set; }
    }
}