using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebThoiTrang.Models.EF
{
    [Table("tb_Order")]
    public class Order: CommonAbstract
    {
        public Order()
        {
            this.OrderDetail = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage ="Ten khach hang khong duoc de trong")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage ="So dien thoai khong de trong")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Dia chi khong duoc de trong")]
        public string Address { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int TypePayment { get; set; }
        public string CustomerId { get; set; }
        public int status { get; set; }
        public virtual ICollection<OrderDetail>  OrderDetail { get; set; }
    }
}