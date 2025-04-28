using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.ViewModel;

public class EditorCustumerViewModel
{
    [Required(ErrorMessage = "o nome e requerido")]
    public string Name { get; set; }
    [Required(ErrorMessage = "o email e requerido")]
    public string Email { get; set; }
    public int ZipCode { get; set; }
}