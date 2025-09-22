namespace RSWLogistics.ResponseVM
{
    public class ResponseVm
    {
        public int ResponseCode { get; set; }
        public string ErrorMessage { get; set; } = "";
        public string ResponseMessage { get; set; } = "";
        public dynamic Data { get; set; } = "";  // Use dynamic or object based on your need
    }
}
