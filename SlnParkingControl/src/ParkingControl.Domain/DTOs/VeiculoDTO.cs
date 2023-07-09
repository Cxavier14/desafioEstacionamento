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

        [StringLength(7, MinimumLength = 7, ErrorMessage = "O valor digitado não é uma placa válida!")]
        [Display(Name = "Placa")]
        public string placa { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data e hora da entrada")]
        public DateTime dataHoraEntrada { get; set; }

        [Display(Name = "Data e hora de saída")]
        public DateTime dataHoraSaida { get; set; }

        [Display(Name = "Duração")]
        public virtual TimeSpan? duracao { get; set; }

        [Display(Name = "Tempo cobrado(em horas)")]
        public virtual int? tempoCobrado { get; set; }

        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public virtual double tarifa { get; private set; } 

        [Display(Name = "Valor a pagar")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public virtual double? valorPagar { get; set; }

        public VeiculoDTO()
        {
            this.tarifa = 2.00;
        }

        public VeiculoDTO(int id, string placa, DateTime dataHoraEntrada)
        {
            this.id = id;
            this.placa = placa;
            this.dataHoraEntrada = dataHoraEntrada;
            this.tarifa = 2.00;
        }

        public VeiculoDTO(int id, string placa, DateTime dataHoraEntrada, DateTime dataHoraSaida, TimeSpan? duracao, int? tempoCobrado, double? valorPagar)
        {
            this.id = id;
            this.placa = placa;
            this.dataHoraEntrada = dataHoraEntrada;
            this.dataHoraSaida = dataHoraSaida;
            this.tarifa = 2.00;
            this.duracao = duracao;
            this.tempoCobrado = tempoCobrado;
            this.valorPagar = valorPagar;
        }

        public VeiculoDTO mapToDTO(Veiculo veiculo)
        {
            return new VeiculoDTO
            {
                id = veiculo.Id,
                placa = veiculo.Placa,
                dataHoraEntrada = veiculo.DataHoraEntrada,
                dataHoraSaida = veiculo.DataHoraSaida,
            };
        }

        public Veiculo mapToEntity()
        {
            return new Veiculo
            {
                Id = id,
                Placa = placa.ToUpper(),
                DataHoraEntrada = dataHoraEntrada,
                DataHoraSaida = dataHoraSaida
            };
        }
    }
}
