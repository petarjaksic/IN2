namespace IN2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT()
        {
            POLOZENI_ISPITI = new HashSet<POLOZENI_ISPITI>();
        }

        public int StudentID { get; set; }

        [Required]
        [StringLength(255)]
        public string ImePrezime { get; set; }

        public ICollection<POLOZENI_ISPITI> POLOZENI_ISPITI { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<POLOZENI_ISPITI> POLOZENI_ISPITI { get; set; }
    }
}
