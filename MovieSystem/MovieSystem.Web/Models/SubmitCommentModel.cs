﻿using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopSystem.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        [MinLength(6)]
        public string Comment { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}