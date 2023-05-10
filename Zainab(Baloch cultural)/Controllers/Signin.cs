using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly AppDBContext _dbcontext;

        public Signin(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IEnumerable<SignIn>> GetLogin()
        {
            return await _dbcontext.signIns.ToListAsync();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Get([Microsoft.AspNetCore.Mvc.FromBody] SignIn request)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists in the database
                if (await _dbcontext.signIns.AnyAsync(u => u.Email == request.Email))
                {
                    // User already exists
                    return Conflict();
                }

                // Create a new user in the database
                var log = new SignIn
                {
                    Email = request.Email,
                    Password = request.Password,

                };
                _dbcontext.signIns.Add(log);

                await _dbcontext.SaveChangesAsync();

                // Return a 201 Created status code
                return Created(new Uri(Request.GetEncodedUrl()), log);
            }

            // Bad request - invalid input data
            return BadRequest(ModelState);
        }





        //[Microsoft.AspNetCore.Mvc.HttpGet("Sign In/{Email}/{Password}")]
        //public string SignIn(string Email, string Password)
        //{
        //    return "Here your Email Address " + Email + " and that's your pass " + Password;
        //}

        //[Microsoft.AspNetCore.Mvc.HttpPost("SaveInfo")]
        //public string SaveSignIn(SignIn sign)
        //{

        //    return "My name is " + sign.Email + " and i am from " + sign.Password;
        //}



    }

}

