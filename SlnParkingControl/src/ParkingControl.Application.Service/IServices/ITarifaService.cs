using ParkingControl.Domain.DTOs;
using ParkingControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Application.Service.IServices
{
    public interface ITarifaService
    {
        IEnumerable<TarifaDTO> BuscarTodos();
    }
}
