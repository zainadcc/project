using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Web.Http;
using Zainab_Baloch_cultural_.Data;
using Zainab_Baloch_cultural_.Model;

namespace Zainab_Baloch_cultural_.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class Signin : ControllerBase
    {
        

        

        [Microsoft.AspNetCore.Mvc.HttpGet("Sign In/{Email}/{Password}")]
        public string SignIn(string Email, string Password)
        {
            return "Here your Email Address " + Email + " and that's your pass " + Password;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("SaveInfo")]
        public string SaveSignIn(SignIn sign)
        {

            return "My name is " + sign.Email + " and i am from " + sign.Password;
        }
        

        }

    }

