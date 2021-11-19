using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowygrywaniApi.Model
{
    public class Comment : ModelTemplate
    {
        public string Content { get; set; }
        public int Game_id { get; set; }
        public int User_id { get; set; }
    }
}
