using System.ComponentModel.DataAnnotations;

namespace EstoqueApi.ViewModel;

public class EditorTennisViewModel
{
    [Required(ErrorMessage = "o nome e requerido")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "a versão e requerida")]
    public string Version { get; set; }
    
    [Required(ErrorMessage = "o preço e requerido")]
    public int Price { get; set; }
}