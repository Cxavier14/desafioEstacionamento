using Microsoft.EntityFrameworkCore;
using ParkingControl.Application.Service.IServices;
using ParkingControl.Domain.DTOs;
using ParkingControl.Domain.Entities;
using ParkingControl.Infra.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Application.Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<VeiculoDTO> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos()
                    .Select(v => new VeiculoDTO
                    {
                        id = v.Id,
                        placa = v.Placa,
                        dataHoraEntrada = v.DataHoraEntrada,
                        dataHoraSaida = v.DataHoraSaida,
                    });
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado! {ex.Message}");
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

        public async Task<List<VeiculoDTO>> BuscarPorPlaca(string placa)
        {
            try
            {
                List<VeiculoDTO> entity = new List<VeiculoDTO>();
                foreach (var item in entity)
                {
                    await _repository.BuscarPorPlaca(placa);
                    entity.Add(item);
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado! {ex.Message}");
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
    }
}
