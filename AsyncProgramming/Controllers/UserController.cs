using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncProgramming.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient();
            var message = await client.GetStringAsync("https://randomuser.me/api/");
            return message;
        }
    }
}
