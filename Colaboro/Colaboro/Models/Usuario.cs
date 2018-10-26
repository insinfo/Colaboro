using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Colaboro.Models
{
    public class Usuario
    {
        [PrimaryKey] 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
    }
}
