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
        Task<List<VeiculoDTO>> BuscarTodos();
        Task<List<VeiculoDTO>> BuscarPorPlaca(string placa);
        Task<VeiculoDTO> BuscarPeloId(int id);
        Task<int> Salvar(VeiculoDTO veiculo);
        Task<int> Editar(VeiculoDTO veiculo);
        Task<int> Deletar(VeiculoDTO veiculo);
        TimeSpan CalculaDuracao(DateTime horaEntrada, DateTime horaSaida);
        int CalculaTempoCobradoEmHoras(DateTime horaEntrada, DateTime horaSaida);
        double CalculaValorPagar(DateTime horaEntrada, DateTime horaSaida, double preco);
    }
}
