namespace DRRCore.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public bool IsWarning { get; set; }=false;
        public string Message { get; set; } = string.Empty;
    }
}
