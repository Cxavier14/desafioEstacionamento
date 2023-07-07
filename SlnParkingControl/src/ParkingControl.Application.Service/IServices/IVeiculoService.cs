using ParkingControl.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Application.Service.IServices
{
    public interface IVeiculoService
    {
        IEnumerable<VeiculoDTO> BuscarTodos();
        Task<List<VeiculoDTO>> BuscarPorPlaca(string placa);
        Task<VeiculoDTO> BuscarPeloId(int id);
        Task<int> Salvar(VeiculoDTO veiculo);
        Task<int> Editar(VeiculoDTO veiculo);
        Task<int> Deletar(VeiculoDTO veiculo);
    }
}
