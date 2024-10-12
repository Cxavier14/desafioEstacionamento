using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;
using ParkingControl.Infra.Data.IRepositories;

namespace ParkingControl.Application.Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VeiculoDTO>> BuscarTodos()
        {
            try
            {
                var result = await _repository.BuscarTodos();
                return result.Select(v => new VeiculoDTO
                {
                    id = v.Id,
                    placa = v.Placa,
                    dataHoraEntrada = v.DataHoraEntrada,
                    dataHoraSaida = v.DataHoraSaida
                })
                    .OrderByDescending(v => v.dataHoraEntrada)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao carregar a tela principal. {ex.Message}");
            }
        }

        public async Task<int> Salvar(VeiculoDTO veiculo)
        {
            try
            {
                return await _repository.Salvar(veiculo.mapToEntity());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar adicionar novo registro! {ex.Message}");
            }
        }

        public async Task<int> Editar(VeiculoDTO veiculo)
        {
            try
            {
                return await _repository.Editar(veiculo.mapToEntity());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado ao tentar editar este registro! {ex.Message}");
            }
        }

        public async Task<List<VeiculoDTO>> BuscarPorPlaca(string placa)
        {
            try
            {
                var listDto = new List<VeiculoDTO>();
                var list = await _repository.BuscarPorPlaca(placa);

                foreach (var item in list)
                {
                    var dto = new VeiculoDTO
                    {
                        id = item.Id,
                        placa = item.Placa,
                        dataHoraEntrada = item.DataHoraEntrada,
                        dataHoraSaida = item.DataHoraSaida,
                    };
                    listDto.Add(dto);
                }

                return listDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar buscar a placa. {ex.Message}");
            }
        }

        public async Task<int> Deletar(VeiculoDTO veiculo)
        {
            try
            {
                return await _repository.Deletar(veiculo.mapToEntity());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar deletar este registro! {ex.Message}");
            }
        }

        public async Task<VeiculoDTO> BuscarPeloId(int id)
        {
            try
            {
                var entity = new VeiculoDTO();
                return entity.mapToDTO(await _repository.BuscarPeloId(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado! {ex.Message}");
            }
        }

        public TimeSpan RetornarDuracao(DateTime horaEntrada, DateTime horaSaida)
        {
            TimeSpan ts = horaSaida.Subtract(horaEntrada);
            return ts;
        }

        public int CalcularTempoCobradoEmHoras(DateTime horaEntrada, DateTime horaSaida)
        {
            int totalHoras = horaSaida.Hour - horaEntrada.Hour;
            var tempoPermanencia = RetornarDuracao(horaEntrada, horaSaida);
            TimeSpan tolerancia = new(totalHoras, 10, 0);

            if (tempoPermanencia.TotalMinutes > 0 && tempoPermanencia.TotalMinutes <= 30)
            {
                totalHoras = 0;
                return totalHoras;
            }
            else if (tempoPermanencia <= tolerancia)
            {
                return totalHoras;
            }
            else
            {
                return totalHoras + 1;
            }
        }

        public double CalcularValorPagar(DateTime horaEntrada, DateTime horaSaida, double tarifa)
        {
            TimeSpan tolerancia = new(1, 10, 0);
            var tempoPermanencia = RetornarDuracao(horaEntrada, horaSaida);
            var tempoHoras = CalcularTempoCobradoEmHoras(horaEntrada, horaSaida);
            
            if (tempoHoras.Equals(0))
            {
                return tarifa / 2;
            }
            else if (tempoPermanencia <= tolerancia)
            {
                return tarifa + (tempoHoras / 2);
            }
            else
            {
                return tarifa + tempoHoras - 1;
            }
        }
    }
}
