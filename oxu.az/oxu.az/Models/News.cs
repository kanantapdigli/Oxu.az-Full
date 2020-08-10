using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oxu.az.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name ="Başlıq")]
        [Required(ErrorMessage ="Başlıq daxil edilməyib")]
        [StringLength(100,ErrorMessage ="Başlığın maksimal ölçüsü 100 xarakterdir.")]
        public string Title { get; set; }

        [Display(Name = "Kategoriya")]
        [Required(ErrorMessage = "Kategoriya daxil edilməyib")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [StringLength(100)]
        [Display(Name = "Şəkil")]
        public string FileName { get; set; }

        [NotMapped]
        [Display(Name = "Şəkil")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Mətn daxil edilməyib")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mətn")]
        [MinLength(30,ErrorMessage ="Mətn ən az 30 xarakter saxlamalıdır.")]
        public string Content { get; set; }

        [Display(Name = "Bəyənilib")]
        public int Like { get; set; }

        [Display(Name = "Bəyənilməyib")]
        public int Unlike { get; set; }

        [Display(Name = "Baxış Sayısı")]
        public int View { get; set; }

        [Required]
        [Display(Name = "Yaradılma tarixi")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "Əsas Xəbər")]
        public bool isMain { get; set; }
    }
}
