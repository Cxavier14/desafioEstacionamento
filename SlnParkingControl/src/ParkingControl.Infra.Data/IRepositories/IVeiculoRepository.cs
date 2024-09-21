using ParkingControl.Domain.Entities;

namespace ParkingControl.Infra.Data.IRepositories
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> BuscarTodos();
        Task<List<Veiculo>> BuscarPorPlaca(string placa);
        Task<Veiculo> BuscarPeloId(int id);
        Task<int> Salvar(Veiculo veiculo);
        Task<int> Editar(Veiculo veiculo);
        Task<int> Deletar(Veiculo veiculo);
    }
}
