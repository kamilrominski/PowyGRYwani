using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowygrywaniApi.Model.Templates;

namespace PowygrywaniApi.Model
{
    public class Rating : ModelIdTemplate
    {
        public int Rate { get; set; }
        public int User_id { get; set; }
        public int Game_id { get; set; }
    }
}
