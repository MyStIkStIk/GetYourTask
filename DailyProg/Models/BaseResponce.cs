using Microsoft.SqlServer.Server;

namespace DailyProg.Models
{
    public enum StatusCode
    {
        OK = 200, Error = 500
    }
    public class BaseResponce<T>
    {
        public T Data { get; set; }
        public StatusCode Status { get; set; }
        public string Message { get; set; }
    }
}
