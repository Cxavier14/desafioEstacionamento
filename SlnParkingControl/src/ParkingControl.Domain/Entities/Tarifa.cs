namespace ParkingControl.Domain.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }
        public double Preco { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
    }
}
