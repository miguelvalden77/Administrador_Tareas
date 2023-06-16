using System.ComponentModel.DataAnnotations;

namespace Administrador_Tareas.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Paso> Pasos { get; set; }
        public List<ArchivoAdjunto> archivoAdjuntos { get; set; }
    }
}
