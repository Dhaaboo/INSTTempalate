using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace INSTTemp.Data
{
    // Add profile data for application users by adding properties to the INSTTempUser class
    public class INSTTempUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public String FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public String lastName { get; set; }

    }
}
