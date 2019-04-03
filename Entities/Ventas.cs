using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public decimal TotalAPagar { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Devuelta { get; set; }

        public virtual List<VentasDetalle> Detalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            TotalAPagar = 0;
            Efectivo = 0;
            Devuelta = 0;
            Fecha = DateTime.Now;
            Detalle = new List<VentasDetalle>();
        }
    }
}
