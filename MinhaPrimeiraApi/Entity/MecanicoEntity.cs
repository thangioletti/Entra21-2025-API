namespace MinhaPrimeiraApi.Entity
{
    public class MecanicoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public MecanicoEntity(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
