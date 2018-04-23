using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sender.API.Models
{
    public class Visitor
    {
        public string UUID { get; set; }
        public bool IsStudent { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Timestamp { get; set; }
    }
}
