using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.ViewModel;

public class EditorUserViewModel
{
    

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(5)]
    public string Name { get; set; }

    [Required(ErrorMessage = "o email é obrigatório")] 
    public string Email { get; set; }
    
    [Required(ErrorMessage = "o slug e obrigatorio")] 
    public string Slug { get; set; }

    
}

