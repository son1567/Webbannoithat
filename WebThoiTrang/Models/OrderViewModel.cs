using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebThoiTrang.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Ten khach hang khong duoc de trong")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "So dien thoai khong de trong")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Dia chi khong duoc de trong")]
        public string Address { get; set; }
        public string Email { get; set; }
        public string CustomerId { get; set; }
        public int TypePayment { get; set; }
    }
}