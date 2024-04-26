namespace DRRCore.Application.DTO.Email
{
    public class EmailDataDTO
    {
        public string EmailKey { get; set; }=string.Empty;
        public string User { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string DisplayName { get; set; }= string.Empty;
        public string Domain { get; set; } = string.Empty;      
        public List<string> To { get; set; } = new List<string>();
        public List<string> CC { get; set; } = new List<string>();
        public List<string> CCO { get; set; } = new List<string>();
        public string Subject { get; set; } = string.Empty;
        public string BodyHTML { get; set; } = string.Empty;
        public bool IsBodyHTML { get;set; }
        public List<string> Parameters { get; set; } = new List<string>();
        public List<List<string>> Table { get; set; }= new List<List<string>>();
        public List<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool BeAuthenticated { get; set; } = false;

    }
    public class AttachmentDto
    {
        public string FileName { get; set;}=string.Empty;
        public string Content { get; set;} = string.Empty;
        public string Path { get; set;}=string.Empty;   
    }
}
