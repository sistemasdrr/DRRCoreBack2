namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCouponBillingSubscriberHistoryResponseDto
    {
        public int Id { get; set; }

        public int? IdCouponBilling { get; set; }

        public int? IdEmployee { get; set; }

        public string? PurchaseDate { get; set; }

        public string? CouponAmount { get; set; }

        public string? CouponUnitPrice { get; set; }

        public string? TotalPrice { get; set; }
    }
}
