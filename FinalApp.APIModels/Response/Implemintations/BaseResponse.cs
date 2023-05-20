using FinalApp.ApiModels.Response.Interfaces;
using Newtonsoft.Json;

namespace FinalApp.ApiModels.Response.Implemintations
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
