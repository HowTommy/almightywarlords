namespace AW.Web.Controllers.Models
{
    using AW.Core.Models;
    using AW.Resources;
    using System.ComponentModel.DataAnnotations;

    public class AccountLogInModel
    {
        [Required(ErrorMessageResourceName = "Error_EnterValidEmail", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(StringMaxLengths.EMAIL, ErrorMessageResourceName = "Error_EnterValidEmail", ErrorMessageResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName = "Error_InvalidEmail", ErrorMessageResourceType = typeof(Resource), ErrorMessage = null)]
        public string Email { get; set; }
        
        [Required(ErrorMessageResourceName = "Error_EnterValidPassword", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(StringMaxLengths.PASSWORD, MinimumLength = StringMinLengths.PASSWORD, ErrorMessageResourceName = "Error_InvalidLengthPassword", ErrorMessageResourceType = typeof(Resource))]
        public string Password { get; set; }
    }
}
