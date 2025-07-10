namespace MinhaPrimeiraApi.DTO
{
    public class OSInsertDTO
    {
        public string Descricao { get; set; }
        public DateTime DataOrdem { get; set; }
        public decimal Valor { get; set; }
        public int ClienteId { get; set; }

        public IEnumerable<OSInsertPecaDTO> Pecas { get; set; }
    }
}
