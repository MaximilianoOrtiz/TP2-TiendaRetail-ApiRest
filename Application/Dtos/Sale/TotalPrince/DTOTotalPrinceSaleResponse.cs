namespace Aplication.Dtos.Sale.TotalPrince
{
    public class DTOTotalPrinceSaleResponse
    {
        public decimal TotalPay { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDiscount { get; set; }

        public override string ToString()
        {
            return $"\nSubtotal: ------------------------------------ {SubTotal:C}" +
                   $"\nDescuento Total: ----------------------------- {TotalDiscount:C}" +
                   $"\nTotal a Pagar (con IVA incluido): ------------ {TotalPay:C}";
        }
    }
}
