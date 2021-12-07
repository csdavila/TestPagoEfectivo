using System.ComponentModel.DataAnnotations;

namespace PagoEfectivo.PromoCode.Model.Requests
{
    public class RedeemRequest
    {
        //[Required]
        //[DataType(DataType.EmailAddress, ErrorMessage = "El campo Correo Electrónico no contiene un correo válido.")]
        //[EmailAddress]
        //public string Email { get; set; }
        [Required]
        [MaxLength(36, ErrorMessage = "El tamaño del código no puede ser mayor a 36.")]
        public string code { get; set; }
    }
}
