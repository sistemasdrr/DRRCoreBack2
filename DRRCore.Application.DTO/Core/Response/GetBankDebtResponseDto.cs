namespace DRRCore.Application.DTO.Core.Response
{
    public class GetBankDebtResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string? BankName { get; set; }

        public string? Qualification { get; set; }

        public string? DebtDate { get; set; }

        public decimal? DebtNc { get; set; }

        public decimal? DebtFc { get; set; }

        public string? Memo { get; set; }

        public string? MemoEng { get; set; }
    }
}
