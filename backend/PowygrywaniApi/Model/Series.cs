using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowygrywaniApi.Model.Templates;

namespace PowygrywaniApi.Model
{
    public class Series : BaseModelTemplate
    {
        public string Description { get; set; }
        public List<Game>? Games { get; set; }

    }
}
