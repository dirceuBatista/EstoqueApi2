using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.ViewModel;

public class RegisterViewModel
{
    [Required(ErrorMessage = "o nome e requerido")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "o email e requerido")]
    [EmailAddress(ErrorMessage = "email invalido")]
    public string Email { get; set; }
}