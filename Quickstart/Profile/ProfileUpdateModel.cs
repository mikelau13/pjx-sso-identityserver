using System.ComponentModel.DataAnnotations;

namespace IdentityServerAspNetIdentity.Quickstart.Profile
{
    public class ProfileUpdateModel
    {
        [Required]
        public string DisplayName { get; set; }
    }
}
