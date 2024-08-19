﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebThoiTrang.Models.EF
{
    [Table("tb_Adv")]
    public class Adv: CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(500)]
        public string Image { get; set; }
        public int Type { get; set; }
        public int ViewCount { get; set; }
        [StringLength(500)]
        public string Link { get; set; }
    }
}