using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebThoiTrang.Models.EF
{
    [Table("tb_Review")]
    public class Review
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string content { get; set; }
        public int Rate { get; set; }
        public DateTime createdDate { get; set; }
        public string avatar { get; set; }
        public bool IsActive { get; set; }

        public virtual Product Product { get; set; }
    }
}