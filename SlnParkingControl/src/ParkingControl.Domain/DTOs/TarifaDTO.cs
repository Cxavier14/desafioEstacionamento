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
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data de vigência")]
        public DateTime DataVigencia { get; set; }
    }
}
