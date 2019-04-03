using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public decimal TotalVendido { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Email = string.Empty;
            Contraseña = string.Empty;
            TotalVendido = 0;
        }

        public Usuarios(int usuarioId, DateTime fecha, string nombres, string email, string contraseña, decimal totalVendido)
        {
            UsuarioId = usuarioId;
            Fecha = fecha;
            Nombres = nombres;
            Email = email;
            Contraseña = contraseña;
            TotalVendido = totalVendido;
        }
    }
}
