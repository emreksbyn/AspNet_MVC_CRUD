using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

// DTO : DataTransferObject 
// Kullanıcının View Page aracılığıyla bize gönderdiği data' yı Controller' a taşımak için kullanacağız. Datalara göre özellikler tanımlıyoruz. Hataları önlemek için kısıtlamalar yapabiliyoruz.
namespace AspNet_MVC_CRUD.Models.DataTransferObjects
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz!")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olabilir.")]
        public string Description { get; set; }
    }
}