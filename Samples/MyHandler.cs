﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Web.Framework;

namespace Samples
{
    public class MyHandler : HttpHandler
    {
        [HttpGet("/")]
        public Task Get(HttpContext context)
        {
            return context.Response.WriteAsync("Hello World");
        }

        [HttpGet("/blah")]
        public object Blah()
        {
            return new { name = "David Fowler" };
        }

        [HttpGet("/lag")]
        public async Task DoAsync(HttpContext context, [FromQuery]string q)
        {
            await Task.Delay(100);

            await context.Response.WriteAsync(q);
        }
        
        [HttpGet("/hey/david")]
        public string HelloDavid() => "Hello David!";

        [HttpGet("/hey/{name?}")]
        public async Task<string> GetAsync([FromRoute]string name)
        {
            await Task.Delay(500);

            return $"Hey {name ?? "David"}!";
        }

        [HttpGet("/hello")]
        public string Hello() => "Hello!";

        [HttpPost("/")]
        public Result Post([FromBody]JToken obj)
        {
            return Ok(obj);
        }

        [HttpGet("/auth")]
        [Authorize]
        public void Authed()
        {

        }
    }
}