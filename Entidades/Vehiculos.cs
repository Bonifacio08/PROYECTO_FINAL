using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Año { get; set; }
        public string NumeracionChasis { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }
    }
}
