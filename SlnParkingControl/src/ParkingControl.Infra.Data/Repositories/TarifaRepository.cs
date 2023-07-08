using Microsoft.EntityFrameworkCore;
using ParkingControl.Domain.Entities;
using ParkingControl.Infra.Data.Context;
using ParkingControl.Infra.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Infra.Data.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly MySQLContext _context;

        public TarifaRepository(MySQLContext context)
        {
            _context = context;
        }

        public Tarifa BuscarTarifa()
        {
            return _context.Tarifas
                .OrderBy(t => t.DataVigencia)
                .LastOrDefault();            
        }
    }
}
