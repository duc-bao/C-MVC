﻿using System.ComponentModel.DataAnnotations;

namespace BanSachMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Dislay Order")]
        [Range(1,100,
            ErrorMessage ="Value for {0} must be between {1} and {2}.")]
        public int DisplayOrder { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
