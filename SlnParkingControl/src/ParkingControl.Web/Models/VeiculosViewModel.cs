using ParkingControl.Domain.DTOs;

namespace ParkingControl.Web.Models
{
    public class VeiculosViewModel
    {
        public List<VeiculoDTO> Veiculos { get; set; }
        public List<TarifaDTO> Tarifas { get; set; }
    }
}
