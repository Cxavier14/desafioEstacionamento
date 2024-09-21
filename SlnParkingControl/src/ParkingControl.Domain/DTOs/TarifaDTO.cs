using ParkingControl.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingControl.Domain.DTOs
{
    public class TarifaDTO
    {
        public int id { get; set; }

        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double preco { get; set; }

        [Display(Name = "Data inicial da vigência")]
        public DateTime dataInicioVigencia { get; set; }

        [Display(Name = "Data fim da vigência")]
        public DateTime? dataFimVigencia { get; set; }



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
                Id= id,
                Preco = preco,
                DataInicioVigencia = dataInicioVigencia,
                DataFimVigencia = dataFimVigencia
            };
        }
    }
}
