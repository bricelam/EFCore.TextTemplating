namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Album")]
    public partial class TableAlbum
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        public int ArtistId { get; set; }

        public virtual TableArtist Artist { get; set; }

        public virtual ICollection<TableTrack> Track { get; } = new HashSet<TableTrack>();

    }
}
