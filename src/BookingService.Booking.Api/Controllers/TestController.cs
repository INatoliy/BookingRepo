using Microsoft.AspNetCore.Mvc;

namespace BookingService.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Тестовый ответ от API");
        }
    }
}


// https://localhost:57954/swagger/v1/swagger.json