﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiDay5Lab.DTOs.DepartmentDtos
{
    public class PostDepartmentDto
    {
        [JsonIgnore]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Must Enter Name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
