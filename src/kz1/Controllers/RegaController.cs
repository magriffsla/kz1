using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Identity;
using kz1.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace kz1.Controllers
{
    [Route("api/[controller]")]
    public class RegaController : Controller
    {
        private UserManager<ApplicationUser> um;
        private SignInManager<ApplicationUser> sm;
        public RegaController(
            UserManager<ApplicationUser> usermanager,
            SignInManager<ApplicationUser> signinmanager

            )
        {
            um = usermanager;
            sm = signinmanager;

        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Redirect("~/jjjj");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(RegaVM model)
        {
            var rurl = "~/regaerror.html";
            if (ModelState.IsValid)
            {
                //
                var user = new ApplicationUser {
                    UserName=model.username,
                    Email=model.email
                };
                var result = await um.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    await sm.SignInAsync(user, model.remember);
                    rurl = "~/";
                }
                //
            }
            return Redirect(rurl);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
