using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Domain.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }
        public double Preco { get; set; }
        public DateTime DataVigencia { get; set; }
    }
}
