using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Service;
using System;
using System.Threading.Tasks;

namespace MyFirstWebApiSite.middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IratingService _ratingService;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IratingService ratingService)
        {
            Rating rating = new()
            {
                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path= httpContext.Request.Path,
                Referer=httpContext.Request.Headers.Referer,
                UserAgent=httpContext.Request.Headers.UserAgent,
                RecordDate = DateTime.Now,

           
            //USER_AGENT - מכיל את שם הדפדפן, גירסתו, מערכת ההפעלה ושפתה
            };
           
            ratingService.addRating(rating);
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
