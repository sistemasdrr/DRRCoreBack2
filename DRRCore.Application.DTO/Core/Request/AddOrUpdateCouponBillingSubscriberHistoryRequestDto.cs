namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateCouponBillingSubscriberHistoryRequestDto
    {
        public int Id { get; set; }

        public int? IdCouponBilling { get; set; }

        public int? IdEmployee { get; set; }

        public string? PurchaseDate { get; set; }

        public decimal? CouponAmount { get; set; }

        public decimal? CouponUnitPrice { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
