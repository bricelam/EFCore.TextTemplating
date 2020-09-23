namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlaylistTrack")]
    public partial class TablePlaylistTrack
    {
        [Key]
        public int PlaylistId { get; set; }

        [Key]
        public int TrackId { get; set; }

        public virtual TablePlaylist Playlist { get; set; }

        public virtual TableTrack Track { get; set; }

    }
}
