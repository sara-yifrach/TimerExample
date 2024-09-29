using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace TimerExample.Controllers
{
    [Route("timer")]
    public class TimerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTimer()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");

            var responseStream = Response.Body;

            while (true)
            {
                var data = Encoding.UTF8.GetBytes($"data: {DateTime.Now.ToString("HH:mm:ss")}\n\n");
                await responseStream.WriteAsync(data);
                await responseStream.FlushAsync();
                await Task.Delay(1000);
            }
        }
    }
}
