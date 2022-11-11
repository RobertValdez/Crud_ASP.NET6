using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.ViewModels
{
    public class ArticleViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int idBrand { get; set; }   
    }
}
