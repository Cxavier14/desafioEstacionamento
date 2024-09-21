using ParkingControl.Domain.DTOs;

namespace ParkingControl.Application.Service.IServices
{
    public interface ITarifaService
    {
        TarifaDTO BuscarTarifa(DateTime dataEntrada);
    }
}
