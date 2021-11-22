using Newtonsoft.Json;

namespace BookMyShow.Models.Helper
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {

        }

        public ErrorDetails(int StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
