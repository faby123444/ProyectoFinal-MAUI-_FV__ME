using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_MAUI__FV__ME
{
    
    public partial class Registro_F
    {
        public int Id { get; set; }
        public int Semestre { get; set; }
        public string Materia { get; set; }
        public string Profesor { get; set; }
        public int Calificacion { get; set; }
        public string Descripcion { get; set; }
        public string Cualidad { get; set; }
        public int Horario { get; set; }
    }
}
