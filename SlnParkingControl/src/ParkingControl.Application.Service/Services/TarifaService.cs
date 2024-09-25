using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;
using ParkingControl.Infra.Data.IRepositories;

namespace ParkingControl.Application.Service.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _repository;

        public TarifaService(ITarifaRepository repository)
        {
            _repository = repository;
        }

        public TarifaDTO BuscarTarifaPorData(DateTime dataEntrada)
        {
            try
            {
                var dto = new TarifaDTO();
                return dto.mapToDTO(_repository.BuscarTarifaPorData(dataEntrada));
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar a tarifa. {ex.Message}");
            }
        }

        public async Task<List<TarifaDTO>> BuscarTodas()
        {
            try
            {
                var result = await _repository.BuscarTodas();
                return result.Select(dto => new TarifaDTO
                {
                    id = dto.Id,
                    dataInicioVigencia = dto.DataInicioVigencia,
                    dataFimVigencia = dto.DataFimVigencia,
                    preco = dto.Preco,
                })
                    .OrderByDescending(x => x.dataInicioVigencia)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao trazer os registro do banco de dados! {ex.Message}");
            }
        }

        public async Task<int> Deletar(TarifaDTO tarifaDTO)
        {
            try
            {
                return await _repository.Deletar(tarifaDTO.mapToEntity());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar deletar o registro! {ex.Message}");
            }
        }

        public async Task<int> Editar(TarifaDTO tarifaDTO)
        {
            try
            {
                return await _repository.Editar(tarifaDTO.mapToEntity());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar editar o registro! {ex.Message}");
            }
        }

        public async Task<int> Salvar(TarifaDTO tarifaDTO)
        {
            try
            {
                return await _repository.Salvar(tarifaDTO.mapToEntity());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar adicionar novo registro! {ex.Message}");
            }
        }
    }
}
