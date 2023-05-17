using System.ComponentModel.DataAnnotations;

namespace BackContoso.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username é obriggatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obriggatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}