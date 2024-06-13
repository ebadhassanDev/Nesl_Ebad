using Microsoft.AspNetCore.Mvc.Filters;
using Nesl_assessment.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesl_assessment.ExceptionFilter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogService _logService;
        public ExceptionFilter(ILogService service) => this._logService = service;

        public void OnException(ExceptionContext context)
        {
            //if (context.ExceptionHandled)
            //{
            //    return;
            //}
            //this._logService.UnknownException()
        }
    }
}
