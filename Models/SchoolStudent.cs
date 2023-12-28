using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SummitSchool.Models
{
    public class SchoolStudent : IdentityUser
    {


        [Required]
        public string ChildName { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        public string MotherName { get; set; }

        [Required]
        public string ChildGuardian { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string HomeAddress { get; set; }



        [Required]
        public string Gender { get; set; }
        [Required]
        public string LanguageToLearn { get; set; }
        [Required]
        public string LvlAtLanguage { get; set; }

        [Required]
        public bool CanSpeakTheLanguage { get; set; }
        [Required]
        public bool DidStudyLanguageToLearnBefore { get; set; }

        [Required]
        public string DateOfBirth { get; set; }


    }


}
