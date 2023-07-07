using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;
using ParkingControl.Infra.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Application.Service.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _repository;

        public TarifaService(ITarifaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TarifaDTO> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos()
                    .Select(t => new TarifaDTO
                    {
                        id = t.Id,
                        preco = t.Preco,
                        dataVigencia = t.DataVigencia
                    });
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado! {ex.Message}");
            }
        }
    }
}
