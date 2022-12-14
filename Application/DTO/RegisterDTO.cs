﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class RegisterDTO
    {
        public string? UserName { get; set; }
        
        public string? FullName { get; set; }
        
        public string? Password { get; set; }
    }
}
