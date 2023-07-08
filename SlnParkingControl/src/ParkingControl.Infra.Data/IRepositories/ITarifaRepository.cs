using ParkingControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Infra.Data.IRepositories
{
    public interface ITarifaRepository
    {
        Tarifa BuscarTarifa();        
    }
}
