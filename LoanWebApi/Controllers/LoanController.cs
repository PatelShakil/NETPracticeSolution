using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        [HttpGet("interest-rate/{gender}")]
        public async Task<IActionResult> GetInterestRate(string gender)
        {
            if(gender == "Female")
            {
                return Ok(9);
            }else{
                return Ok(10);
            }
        }

        [HttpGet("interest-amount/{pa}/{noy}/{ir}")]
        public async Task<IActionResult> GetInterestAmount(double pa,double noy,double ir)
        {
            var ia = (pa * noy * ir) / 100;
            return Ok(ia);
        }
    }
}
