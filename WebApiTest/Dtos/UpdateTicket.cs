﻿using System.ComponentModel.DataAnnotations;
using WebApiTest.Entities;

namespace WebApiTest.Dtos
{
    public record UpdateTicket
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; init; }

        [Required]
        [MaxLength(200)]
        public string Message { get; init; }

        public Status status { get; init; }
       
    }
}
