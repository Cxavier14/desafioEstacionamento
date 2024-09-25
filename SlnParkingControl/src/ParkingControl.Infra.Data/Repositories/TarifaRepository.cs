using Microsoft.EntityFrameworkCore;
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

        public Tarifa BuscarTarifaPorData(DateTime dataEntrada)
        {
            var resultado = _context.Tarifas.Where(t => t.DataInicioVigencia <= dataEntrada && (!t.DataFimVigencia.HasValue || t.DataFimVigencia >= dataEntrada)).FirstOrDefault();

            return resultado != null ? resultado : new Tarifa();
        }

        public async Task<List<Tarifa>> BuscarTodas()
        {
            var result = _context.Tarifas;
            return await result.ToListAsync();
        }

        public async Task<int> Deletar(Tarifa tarifa)
        {
            _context.Tarifas.Remove(tarifa);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Editar(Tarifa tarifa)
        {
            _context.Tarifas.Update(tarifa);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Salvar(Tarifa tarifa)
        {
            _context.Tarifas.Add(tarifa);
            return await _context.SaveChangesAsync();
        }
    }
}
