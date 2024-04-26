using DRRCore.Application.DTO.Core.Request;
using Microsoft.AspNetCore.Http;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyImageResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? Img1 { get; set; }

        public string? ImgDesc1 { get; set; }

        public string? ImgDescEng1 { get; set; }

        public bool? ImgPrint1 { get; set; }

        public string? Img2 { get; set; }

        public string? ImgDesc2 { get; set; }

        public string? ImgDescEng2 { get; set; }

        public bool? ImgPrint2 { get; set; }

        public string? Img3 { get; set; }

        public string? ImgDesc3 { get; set; }

        public string? ImgDescEng3 { get; set; }

        public bool? ImgPrint3 { get; set; }

        public string? Img4 { get; set; }

        public string? ImgDesc4 { get; set; }

        public string? ImgDescEng4 { get; set; }

        public bool? ImgPrint4 { get; set; }

    }
}
