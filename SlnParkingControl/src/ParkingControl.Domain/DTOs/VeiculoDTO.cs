using ParkingControl.Domain.Entities;
using ParkingControl.Domain.ExceptionValidation;
using System.ComponentModel.DataAnnotations;

namespace ParkingControl.Domain.DTOs
{
    public class VeiculoDTO : ValidationMessage
    {
        /// <summary>
        /// id - Identificador único do registro.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Placa do veículo / AAA1234 AAA1A23.
        /// </summary>
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O valor digitado não é uma placa válida!")]
        [Display(Name = "Placa")]
        public string placa { get; set; }

        /// <summary>
        /// Data e hora da entrada do veículo.
        /// </summary>
        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data e hora da entrada")]        
        public DateTime dataHoraEntrada { get; set; }

        /// <summary>
        /// Data e hora da saída do veículo.
        /// </summary>
        [Display(Name = "Data e hora de saída")]
        public DateTime? dataHoraSaida { get; set; }

        /// <summary>
        /// Duração da permanência do veículo no estacionamento.
        /// </summary>
        [Display(Name = "Duração")]
        public virtual TimeSpan? duracao { get; set; }

        /// <summary>
        /// Tempo (em horas) que será cobrado.
        /// </summary>
        [Display(Name = "Tempo cobrado(em horas)")]
        public virtual int? tempoCobrado { get; set; }

        /// <summary>
        /// Valor da tarifa vigente.
        /// </summary>
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public virtual double tarifa { get; set; }

        /// <summary>
        /// Valor a pagar.
        /// </summary>
        [Display(Name = "Valor a pagar")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public virtual double? valorPagar { get; set; }
        
        public VeiculoDTO()
        {            
        }

        public VeiculoDTO(int id, string placa, DateTime dataHoraEntrada)
        {
            this.id = id;
            this.placa = placa;
            this.dataHoraEntrada = dataHoraEntrada;            
        }

        public VeiculoDTO(int id, string placa, DateTime dataHoraEntrada, DateTime dataHoraSaida, TimeSpan? duracao, int? tempoCobrado, double? valorPagar)
        {
            this.id = id;
            this.placa = placa;
            this.dataHoraEntrada = dataHoraEntrada;
            this.dataHoraSaida = dataHoraSaida;
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
