using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.ViewModel;

public class LoginViewModel
{ 
    [Required(ErrorMessage = "o email e requerido")] 
    
    public string Email { get; set; }
    [Required(ErrorMessage = " a senha e requerida")]
    public string Password { get; set; }
}