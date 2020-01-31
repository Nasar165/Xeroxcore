using System.ComponentModel.DataAnnotations;
using api.Security.AuthTemplate.Interface;
using Components.Security;

namespace api.Security.AuthTemplate
{
    public sealed class UserAccount : DataExtension, IUserAccount
    {
        [Required]
        [StringLength(11, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }      
        public void EncryptInfo()
        {
            Password = AesEncrypter._instance.EncryptData(Password);
            Username = AesEncrypter._instance.EncryptData(Username);
        } 
    }
}