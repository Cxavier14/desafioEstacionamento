using ParkingControl.Domain.DTOs;

namespace ParkingControl.Application.Service.IServices
{
    public interface ITarifaService
    {
        Task<List<TarifaDTO>> BuscarTodas();
        TarifaDTO BuscarTarifaPorData(DateTime dataEntrada);
        Task<int> Salvar(TarifaDTO tarifaDTO);
        Task<int> Editar(TarifaDTO tarifaDTO);
        Task<int> Deletar(TarifaDTO tarifaDTO);
    }
}
