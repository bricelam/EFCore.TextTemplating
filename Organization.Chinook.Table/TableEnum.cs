namespace Organization.Chinook.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Enum")]
    public partial class TableEnum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Attribute { get; set; }

        public int? Type { get; set; }

        public int? Type2 { get; set; }

        public int? Type3 { get; set; }

        [Column(TypeName = "ntext")]
        public string Introduce { get; set; }

    }
}
