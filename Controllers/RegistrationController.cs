using ASP_ForAndroid.Context;
using ASP_ForAndroid.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_ForAndroid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationContext _dbContext;
        public RegistrationController(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Autorisation")]
        public ActionResult ClientRegistration([FromBody] User newData)
        {
            try
            {
                if (_dbContext.Users.ToList().Any(e => e.Login == newData.Login))
                    return new JsonResult("This login exists!");
                else
                {
                    if (!string.IsNullOrEmpty(newData.Login) && !string.IsNullOrEmpty(newData.Password) && !string.IsNullOrEmpty(newData.Email))
                    {
                        _dbContext.Users.Add(newData);
                        _dbContext.SaveChanges();
                        return Ok("You have passed the registration verification!");
                    }
                    else
                        return BadRequest("You haven`t passed the registration verification!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("Verification")]
        public ActionResult ClientVerificaation([FromBody] User newData)
        {
            try
            {
                if (!string.IsNullOrEmpty(newData.Login) && !string.IsNullOrEmpty(newData.Password) && !string.IsNullOrEmpty(newData.Email))
                {
                    if (_dbContext.Users.ToList().Any(e => e.Login == newData.Login))
                        return Unauthorized("This login exists!");
                    return Ok("You have passed the registration verification!");
                }
                else
                    return Unauthorized("You haven`t passed the registration verification!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("GetUsers")]
        public JsonResult GetUsers()
        {
            return new JsonResult(_dbContext.Users.ToList());
        }
    }
}
