using System.ComponentModel.DataAnnotations;

namespace LabReservasCampusTech.Models
{
    public class Reserva
    {
        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [Display(Name = "Nombre del profesor")]
        public string NombreProfesor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        [RegularExpression(@".+@campus\.edu$", ErrorMessage = "El correo debe pertenecer al dominio @campus.edu.")]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required(ErrorMessage = "El laboratorio es obligatorio.")]
        [Display(Name = "Laboratorio")]
        public string Laboratorio { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de la reserva es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de la reserva")]
        public DateTime FechaReserva { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de inicio")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de fin")]
        public TimeSpan HoraFin { get; set; }

        [Required(ErrorMessage = "El motivo es obligatorio.")]
        [MinLength(5, ErrorMessage = "El motivo debe tener al menos 5 caracteres.")]
        [MaxLength(200, ErrorMessage = "El motivo no puede tener más de 200 caracteres.")]
        [Display(Name = "Motivo / descripción de la reserva")]
        public string Motivo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código de reserva es obligatorio.")]
        [RegularExpression(@"^RES-\d{3}$", ErrorMessage = "El código debe tener el formato RES-###, por ejemplo RES-001.")]
        [Display(Name = "Código de reserva")]
        public string CodigoReserva { get; set; } = string.Empty;
    }
}
