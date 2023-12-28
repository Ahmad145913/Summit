using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using SummitSchool.Models;
using SummitSchool.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SummitSchool.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Child Name")]
            public string ChildName { get; set; }

            [Required]
            [Display(Name = "Father Name")]
            public string FatherName { get; set; }

            [Required]
            [Display(Name = "Mother Name")]
            public string MotherName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Child guardian")]
            public string ChildGuardian { get; set; }

            [Required]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            [Display(Name = "Child home address")]
            public string HomeAddress { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Text)]

            [Display(Name = "Gender")]
            public string Gender { get; set; }
            [Required]
            [DataType(DataType.Text)]

            [Display(Name = "Language to learn")]
            public string LanguageToLearn { get; set; }
            [Required]
            [DataType(DataType.Text)]

            [Display(Name = "Level at the language to learn")]
            public string LvlAtLanguage { get; set; }

            [Required]
            [DataType(DataType.Text)]

            [Display(Name = "can speak the language-to-learn")]
            public string CanSpeakTheLanguage { get; set; }
            [Required]
            [DataType(DataType.Text)]

            [Display(Name = "Did study the Language before")]
            public string DidStudyLanguageToLearnBefore { get; set; }

            [Required]
            [Display(Name = "Date Of Birth")]
            [DataType(DataType.Date)]
            public Date DateOfBirth { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }


        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            Debug.WriteLine(ModelState.IsValid);

            if (ModelState.IsValid)
            {
                var user = new SchoolStudent
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    // child Info
                    DateOfBirth = Input.DateOfBirth.ToString(),
                    ChildGuardian = Input.ChildGuardian,
                    LanguageToLearn = Input.LanguageToLearn,
                    LvlAtLanguage = Input.LvlAtLanguage,
                    City = Input.City,
                    Country = Input.Country,
                    HomeAddress = Input.HomeAddress,
                    Gender = Input.Gender,
                    DidStudyLanguageToLearnBefore = Input.DidStudyLanguageToLearnBefore.ToLower() == "yes",
                    ChildName = Input.ChildName,
                    FatherName = Input.FatherName,
                    MotherName = Input.MotherName,
                    CanSpeakTheLanguage = Input.CanSpeakTheLanguage.ToLower() == "yes"
                };
                //var user = new IdentityUser
                //{
                //    UserName = Input.Email,
                //    Email = Input.Email
                //};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, SD.Admin);

                    await _userManager.AddToRoleAsync(user, SD.User);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
