using System;
using System.Collections.Generic;

#nullable disable

namespace UsedCars.Core.Entities
{
    public partial class Song
    {
        public Song()
        {
            KeyboardPrograms = new HashSet<KeyboardProgram>();
        }

        public int Id { get; set; }
        public int? SetlistOrder { get; set; }
        public string Title { get; set; }

        public virtual ICollection<KeyboardProgram> KeyboardPrograms { get; set; }
    }
}
