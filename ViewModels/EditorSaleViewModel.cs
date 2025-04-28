using System.ComponentModel.DataAnnotations;
using EstoqueApi.Models;

namespace EstoqueApi.ViewModel;



    public class EditorSaleViewModel
    {
        [Required(ErrorMessage = "a descrição e requerida")]
        public string Description { get; set; }
        public DateTime DateSale { get; set; }
        [Required(ErrorMessage = "o vendedor e requerido")]
        public int SellerId { get; set; }
        [Required(ErrorMessage = "o tenis e requerido")]
        public int TennisId { get; set; }
    }

