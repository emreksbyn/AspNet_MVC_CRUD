using System.ComponentModel.DataAnnotations;

namespace AspNet_MVC_CRUD.Models.DataTransferObjects
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [MinLength(3, ErrorMessage = "Min 3 karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Boş Bırakılamaz")]
        [MinLength(3,ErrorMessage = "Min 3 karakter")]
        public string Description { get; set; }
    }
}