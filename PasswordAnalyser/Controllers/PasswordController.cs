using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordAnalyser.Models;

namespace PasswordAnalyser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string password)
        {
            Password pw = new Password(password);
            PasswordAnalyserResponse res = new PasswordAnalyserResponse(pw.Strength, pw.Breach);
            if (pw.Breach > 0)
            {
                res.Strength = "Unacceptable";
            }
            return Ok(res);
        }
    }
}