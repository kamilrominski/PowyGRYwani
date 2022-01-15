using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowygrywaniApi.Model.Templates;

namespace PowygrywaniApi.Model
{
    public class User : BaseModelTemplate
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
