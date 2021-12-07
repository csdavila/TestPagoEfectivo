using System.ComponentModel.DataAnnotations;

namespace PagoEfectivo.PromoCode.Model.Requests
{
    public class GenerateRequest
    {
        [Required]
        [MaxLength(500, ErrorMessage = "El tamaño de Nombre no puede ser mayor a 500.")]
        public string fullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo Correo Electrónico no contiene un correo válido.")]
        [EmailAddress]
        public string email { get; set; }
    }
}
