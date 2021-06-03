using System;
using System.Collections.Generic;

#nullable disable

namespace UsedCars.Core.Entities
{
    public partial class KeyboardProgram
    {
        public int Id { get; set; }
        public int? SongId { get; set; }
        public string KorgProgram { get; set; }
        public string NordProgram { get; set; }

        public virtual Song Song { get; set; }
    }
}
