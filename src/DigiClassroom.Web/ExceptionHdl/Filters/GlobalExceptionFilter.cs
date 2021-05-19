using DigiClassroom.Web.ExceptionHdl.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DigiClassroom.Web.ExceptionHdl.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            ErrorResponse error = new ErrorResponse(context.Exception.Message);
            context.Result = new JsonResult(error) { StatusCode = 500 };
            return Task.CompletedTask;
        }
    }
}
