using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPlanillasAlumnos.Models
{
    public class TrayectoriaEscolar
    {

        [Key]
        public int TrayectoriaEscolarID { get; set; }

        [Display(Name = "Descripcion de trayectoria")]
        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        public string TrayectoriaEscolarDescripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime TrayectoriasFecha { get; set; }

        public int PacienteID { get; set; }
        public virtual Paciente Paciente { get; set; }

        public int EscuelaID { get; set; }
        public virtual Escuela Escuelas { get; set; }

        public bool Eliminado { get; set; }
    }

    public class ListadoTrayectoriaEscolar
    {
        public int TrayectoriaEscolarID { get; set; }
        public string TrayectoriaEscolarDescripcion { get; set; }
        public string TrayectoriasFechaString { get; set; }
        public ListadoEscuela Escuela { get; set; }
        public ListadoPacientes Paciente { get; set; }
    }

}