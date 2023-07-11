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
                throw new Exception($"Ocorreu um erro inesperado! {ex.Message}");
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

        public TimeSpan CalculaDuracao(DateTime horaEntrada, DateTime horaSaida)
        {
            TimeSpan ts = horaSaida.Subtract(horaEntrada);
            return ts;
        }

        public int CalculaTempoCobradoEmHoras(DateTime horaEntrada, DateTime horaSaida)
        {
            int ts = horaSaida.Hour - horaEntrada.Hour;
            var temp = horaSaida.TimeOfDay.Subtract(horaEntrada.TimeOfDay);
            TimeSpan tolerancia = new(ts, 10, 0);

            if (temp.TotalMinutes > 0 && temp.TotalMinutes <= 30)
            {
                ts = 0;
                return ts;
            }
            else if (temp <= tolerancia)
            {
                return ts;
            }
            else
            {
                return ts + 1;
            }
        }

        public double CalculaValorPagar(DateTime horaEntrada, DateTime horaSaida, double preco)
        {
            TimeSpan tolerancia = new(1, 10, 0);
            var tempoPermanencia = horaSaida.TimeOfDay.Subtract(horaEntrada.TimeOfDay);
            var tempoHoras = CalculaTempoCobradoEmHoras(horaEntrada, horaSaida);
            
            if (tempoHoras.Equals(0))
            {
                return preco / 2;
            }
            else if (tempoPermanencia <= tolerancia)
            {
                return preco + (tempoHoras / 2);
            }
            else
            {
                return preco + tempoHoras - 1;
            }
        }
    }
}
