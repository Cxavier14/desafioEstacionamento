using ParkingControl.Domain.Entities;
using ParkingControl.Infra.Data.Context;
using ParkingControl.Infra.Data.IRepositories;

namespace ParkingControl.Infra.Data.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly MySQLContext _context;

        public TarifaRepository(MySQLContext context)
        {
            _context = context;
        }

        public Tarifa BuscarTarifa(DateTime dataEntrada)
        {
            var resultado = _context.Tarifas.Where(t => t.DataInicioVigencia <= dataEntrada && (!t.DataFimVigencia.HasValue || t.DataFimVigencia >= dataEntrada)).FirstOrDefault();

            return resultado != null ? resultado : new Tarifa();
        }
    }
}
