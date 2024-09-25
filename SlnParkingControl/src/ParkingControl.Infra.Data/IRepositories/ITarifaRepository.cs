using ParkingControl.Domain.Entities;

namespace ParkingControl.Infra.Data.IRepositories
{
    public interface ITarifaRepository
    {
        Task<List<Tarifa>> BuscarTodas();
        Tarifa BuscarTarifaPorData(DateTime dataEntrada);
        Task<int> Salvar(Tarifa tarifa);
        Task<int> Editar(Tarifa tarifa);
        Task<int> Deletar(Tarifa tarifa);
    }
}
