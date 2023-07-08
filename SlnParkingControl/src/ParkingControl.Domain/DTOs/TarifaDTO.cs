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
    public class TarifaDTO
    {
        public int id { get; set; }

        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double preco { get; set; }

        [Display(Name = "Data de vigência")]
        public DateTime dataVigencia { get; set; }

        public TarifaDTO mapToDTO(Tarifa tarifa)
        {
            return new TarifaDTO
            {
                id = tarifa.Id,
                preco = tarifa.Preco,
                dataVigencia = tarifa.DataVigencia
            };
        }

        public Tarifa mapToEntity()
        {
            return new Tarifa
            {
                Id= id,
                Preco = preco,
                DataVigencia = dataVigencia
            };
        }
    }
}
