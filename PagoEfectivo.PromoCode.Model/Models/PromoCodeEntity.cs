namespace PagoEfectivo.PromoCode.Model.Models
{
    public class PromoCodeEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
    }
}
