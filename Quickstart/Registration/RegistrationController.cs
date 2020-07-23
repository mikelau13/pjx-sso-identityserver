using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServerAspNetIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerAspNetIdentity.Quickstart.Registration
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class RegistrationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IIdentityServerInteractionService _interaction;
        //private readonly IClientStore _clientStore;
        //private readonly IAuthenticationSchemeProvider _schemeProvider;
        //private readonly IEventService _events;

        public RegistrationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            //_interaction = interaction;
            //_clientStore = clientStore;
            //_schemeProvider = schemeProvider;
            //_events = events;
        }

        /// <summary>
        /// Allow users to register an new account.
        /// <br/>First to ensure the email address does not already exist.
        /// <br/>If succeed, this Api will send out an activation email to the users.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>200 if succeed; otherwise return a bad request with error message.</returns>
        /// <seealso cref="HttpPostAttribute"/>
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            //System.Diagnostics.Stopwatch swatch = new System.Diagnostics.Stopwatch(); swatch.Start();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null && !user.EmailConfirmed)
            {
                /*
                // there might be a special case where some users have problem with the activation code so they would re-register
                // for this reason, we better update the previous Activation Code
                user.ActivationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.UpdateAsync(user);
                */
                try
                {
                    // TODO: resend activation email
                    //await SendActivationMailAsync(user, model.ActivationUrl);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("Re-registration saved, however error when sending email.");
                }
            }
            else
            {
                // first time registration
                IdentityResult result;
                CreateAccount(_userManager, model.Email, model.Password, out user, out result);

                if (!result.Succeeded)
                {
                    // failed to create, could be due to user already exist, or other reasons.
                    return GetErrorResult(result);
                }

                // update activate code, code generated from using the user.Id so must first create user then update the record
                // user.ActivationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.UpdateAsync(user);

                try
                {
                    //await SendActivationMailAsync(user, model.ActivationUrl);

                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("New user have been saved successfully, however returned error when sending email.");
                }
            }
        }


        internal static void CreateAccount(UserManager<ApplicationUser> userManager
            , string email, string password
            , out ApplicationUser user, out IdentityResult result)
        {
            user = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                LockoutEnabled = false,
            };

            result = userManager.CreateAsync(user, password).Result;
        }


        private IActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return StatusCode(500);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
