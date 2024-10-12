using ParkingControl.Domain.DTOs;

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
        TimeSpan RetornarDuracao(DateTime horaEntrada, DateTime horaSaida);
        int CalcularTempoCobradoEmHoras(DateTime horaEntrada, DateTime horaSaida);
        double CalcularValorPagar(DateTime horaEntrada, DateTime horaSaida, double tarifa);
    }
}
