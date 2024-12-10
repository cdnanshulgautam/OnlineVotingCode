using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Application.ViewModels
{
    public class VoterViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Authorized")]
        public bool IsAuthorized { get; set; }
        [Display(Name = "Locked Out")]
        public bool IsLockout { get; set; }
    }
}
