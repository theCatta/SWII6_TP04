namespace tpSw04.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public int Ano { get; set; }
    }
}
