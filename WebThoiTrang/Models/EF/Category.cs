﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebThoiTrang.Models.EF
{
    [Table("tb_Category")]
    public class Category: CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // Id tự động tăng
        public int Id { get; set; }
        [Required(ErrorMessage="Tên danh mục không được để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        //[StringLength(150)]
        //public string TypeCode { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(150)]
        public string SeoDescription { get; set; }
        [StringLength(150)]
        public string SeoKeywords { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}