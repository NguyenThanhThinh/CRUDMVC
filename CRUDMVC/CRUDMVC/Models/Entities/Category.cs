using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDMVC.Models.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        [DisplayName("Tên loại")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        public string Name { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "{0} là bắt buộc")]
        public string Description { get; set; }
    }
}