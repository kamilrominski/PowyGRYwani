using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowygrywaniApi.Model.Templates;

namespace PowygrywaniApi.Model
{
    public class Game : BaseModelTemplate
    {
        public string? Description { get; set; }
        public int? Studio_id { get; set; }
        public int? Series_id { get; set; }
    }
}
