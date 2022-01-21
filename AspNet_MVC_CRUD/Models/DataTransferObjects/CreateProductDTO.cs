using AspNet_MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_MVC_CRUD.Models.DataTransferObjects
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Adı Boş Bırakılamaz !")]
        [MinLength(3, ErrorMessage = "En az 3 Karakter Olmalı !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama Boş Bırakılamaz !")]
        [MinLength(3, ErrorMessage = "En az 3 Karakter Olmalı !")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ücreti Boş Bırakılamaz !")]
        [DataType(DataType.Currency, ErrorMessage = "Para Birimi Girilebilir !")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Stok Boş Bırakılamaz !")]
        public short UnitInStock { get; set; }

        [Required(ErrorMessage = "Kategori Seçmelisiniz !")]
        public int CategoryId { get; set; }

        // Create Form sayfası açılırken dolu açılacak. Buradaki DTO çift yönlü çalışacak. Kullanıcıya giderkern aşağıdaki property' e ihtiyacım var.
        public List<Category> Categories { get; set; }
    }
}