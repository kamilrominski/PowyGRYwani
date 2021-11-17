using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowygrywaniApi.Model
{
    public class Game
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Studio_id { get; set; }
        public int Series_id { get; set; }
    }
}
