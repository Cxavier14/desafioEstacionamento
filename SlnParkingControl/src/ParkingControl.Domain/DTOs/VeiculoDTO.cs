using ParkingControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ParkingControl.Domain.DTOs
{
    public class VeiculoDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O valor digitado não é uma placa válida!")]
        public string placa { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data e hora da entrada")]
        public DateTime dataHoraEntrada { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data e hora de saída")]
        public DateTime dataHoraSaida { get; set; }
        
        public VeiculoDTO mapToDTO(Veiculo veiculo)
        {
            return new VeiculoDTO
            {
                id = veiculo.Id,
                placa = veiculo.Placa,
                dataHoraEntrada = veiculo.DataHoraEntrada,
                dataHoraSaida = veiculo.DataHoraSaida
            };
        }

        public Veiculo mapToEntity()
        {
            return new Veiculo
            {
                Id = id,
                Placa = placa,
                DataHoraEntrada = dataHoraEntrada,
                DataHoraSaida = dataHoraSaida
            };
        }
    }
}
