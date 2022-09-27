using ConsumeJWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumeJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        // POST api/<GetUserController>
        [HttpPost("getToken")]
        public async Task<IActionResult> ValidateUser([FromBody] TokenParams paramList)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent param = new StringContent(JsonConvert.SerializeObject(paramList), Encoding.UTF8,
                        "application/json");
                    using (var response =
                           await httpClient.PostAsync(
                               "https://hsstest.hssonline.gov.za/hsswebapi2/api/HSSOnline/BPGetPhaseDetail", param))
                    {
                        string responseApi = await response.Content.ReadAsStringAsync();
                        if (responseApi.Contains("The token is invalid or expired!"))
                        {
                            string msg = "Incorrect UserId or Password";
                            return Redirect("~/Home/Index");
                        }
                      
                       
                        HttpContext.Session.SetString("JWToken", responseApi);
                    }
                }

                return Redirect("~/Dashboard/Index");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
