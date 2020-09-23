namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Genre")]
    public partial class TableGenre
    {
        [Key]
        public int GenreId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<TableTrack> Track { get; } = new HashSet<TableTrack>();

    }
}
