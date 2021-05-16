﻿using Microsoft.AspNetCore.Http;
using MISA.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MISA.AMIS.WebAPIs.Middleware
{
    /// <summary>
    /// Handling exception
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(
                    new ServiceResult
                    {
                        Messenger = "Có lỗi xảy ra vui lòng liên hệ MISA",
                        MISACode = Core.Enum.MISACode.Exception,
                        Data = new
                        {
                            devMsg = ex.Message,
                            cusMsg = "Có lỗi xảy ra vui lòng liên hệ MISA"
                        }
                    }
                );
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
