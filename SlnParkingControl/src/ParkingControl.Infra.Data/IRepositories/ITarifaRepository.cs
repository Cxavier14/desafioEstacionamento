using ParkingControl.Domain.Entities;

namespace ParkingControl.Infra.Data.IRepositories
{
    public interface ITarifaRepository
    {
        Tarifa BuscarTarifa(DateTime dataEntrada);        
    }
}
