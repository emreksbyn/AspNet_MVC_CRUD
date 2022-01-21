using AspNet_MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_MVC_CRUD.Models.DataTransferObjects
{
    public class UpdateProductDTO
    {        
        public int Id { get; set; }
     
        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz !")]
        [MinLength(3,ErrorMessage ="Min 3 Karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz !")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz !")]
        [DataType(DataType.Currency,ErrorMessage ="Para Birimi Girilmelidir.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz !")]
        public short UnitInStock { get; set; }

        [Required(ErrorMessage ="Kategori Seçmelisin")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}