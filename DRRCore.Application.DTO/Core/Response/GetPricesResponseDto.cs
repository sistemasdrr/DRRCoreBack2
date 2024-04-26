namespace DRRCore.Application.DTO.Core.Response
{
    public class GetPricesResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Days { get; set; }
    }
}
