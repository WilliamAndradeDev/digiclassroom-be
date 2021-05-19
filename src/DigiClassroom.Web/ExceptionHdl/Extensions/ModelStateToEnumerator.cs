using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace DigiClassroom.Web.ExceptionHdl.Extensions
{
    public static class ModelStateToEnumerator
    {
        public static IEnumerable<string> GetErrorsEnumerated(this ModelStateDictionary modelState)
        => modelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage);
    }
}
