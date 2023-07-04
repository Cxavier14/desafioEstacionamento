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
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O valor digitado não é uma placa válida!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data e hora da entrada")]
        public DateTime DataHoraEntrada { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória!")]
        [Display(Name = "Data e hora de saída")]
        public DateTime DataHoraSaida { get; set; }
    }
}
