namespace Erste
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("erste.kurs")]
    public partial class kurs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kurs()
        {
            grupe = new HashSet<grupa>();
            polaznici_na_cekanju = new HashSet<polaznik_na_cekanju>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Nivo { get; set; }

        public int JezikId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumOd { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatumDo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupa> grupe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<polaznik_na_cekanju> polaznici_na_cekanju { get; set; }

        public virtual jezik jezik { get; set; }

        public override bool Equals(object obj)
        {
            var kurs = obj as kurs;
            return kurs != null &&
                   Id == kurs.Id;
        }
    }
}
