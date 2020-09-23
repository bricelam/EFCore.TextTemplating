namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Playlist")]
    public partial class TablePlaylist
    {
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        public virtual ICollection<TablePlaylistTrack> PlaylistTrack { get; } = new HashSet<TablePlaylistTrack>();

    }
}
