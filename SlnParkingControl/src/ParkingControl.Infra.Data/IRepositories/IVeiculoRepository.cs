using ParkingControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Infra.Data.IRepositories
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> BuscarTodos();
        Task<List<Veiculo>> BuscarPorPlaca(string placa);
        Task<Veiculo> BuscarPeloId(int id);
        Task<int> Salvar(Veiculo veiculo);
        Task<int> Editar(Veiculo veiculo);
        Task<int> Deletar(Veiculo veiculo);
    }
}
