using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DigiClassroom.Web.ExceptionHdl.ErrorModels
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<string> Detalhes { get; set; }

        public ErrorResponse(){}

        public ErrorResponse(string message,int statusCode = 500)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ErrorResponse( 
                        IEnumerable<string> detalhes,
                        string message = "Erro na validação dos dados passados.",
                        int statusCode= 400)
        {
            StatusCode = statusCode;
            Message = message;
            Detalhes = detalhes;
        }
    }
}
