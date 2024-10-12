using ParkingControl.Domain.Entities;
using ParkingControl.Domain.ExceptionValidation;
using System.ComponentModel.DataAnnotations;

namespace ParkingControl.Domain.DTOs
{
    public class TarifaDTO : ValidationMessage
    {
        /// <summary>
        /// Identificador único do registro.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Preço da tarifa.
        /// </summary>
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double preco { get; set; }

        /// <summary>
        /// Data inicio da vigência.
        /// </summary>
        [Display(Name = "Data inicial da vigência")]
        public DateTime dataInicioVigencia { get; set; }

        /// <summary>
        /// Data fim da vigência.
        /// </summary>
        [Display(Name = "Data fim da vigência")]
        public DateTime? dataFimVigencia { get; set; }

        /// <summary>
        /// Ano de vigência da tarifa.
        /// </summary>
        [Display(Name = "Ano vigência")]
        public int AnoVigencia { get; set; }


        public TarifaDTO mapToDTO(Tarifa tarifa)
        {
            return new TarifaDTO
            {
                id = tarifa.Id,
                preco = tarifa.Preco,
                dataInicioVigencia = tarifa.DataInicioVigencia,
                dataFimVigencia = tarifa.DataFimVigencia
            };
        }

        public Tarifa mapToEntity()
        {
            return new Tarifa
            {
                Id = id,
                Preco = preco,
                DataInicioVigencia = dataInicioVigencia,
                DataFimVigencia = dataFimVigencia
            };
        }
    }
}
