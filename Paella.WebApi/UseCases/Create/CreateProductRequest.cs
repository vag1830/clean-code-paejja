﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Paella.WebApi.UseCases.Create
{
    public class CreateProductRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}