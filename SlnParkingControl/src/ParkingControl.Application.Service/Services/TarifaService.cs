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

        public TarifaDTO BuscarTarifa(DateTime dataEntrada)
        {
            try
            {
                var dto = new TarifaDTO();
                return dto.mapToDTO(_repository.BuscarTarifa(dataEntrada));
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao buscar a tarifa. {ex.Message}");
            }
        }
    }
}
