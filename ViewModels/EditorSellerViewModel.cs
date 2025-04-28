using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.ViewModel;

public class EditorSellerViewModel
{
    [Required(ErrorMessage = "o nome e requerido")]
    public string Name { get; set; }
    [Required(ErrorMessage = "o email e requerido")]
    public string  Email { get; set; }
    [Required (ErrorMessage = "o slug e requerido")]
    public string Slug { get; set; }
    
}