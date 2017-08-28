namespace IN2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PREDMET")]
    public partial class PREDMET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PREDMET()
        {
            POLOZENI_ISPITI = new HashSet<POLOZENI_ISPITI>();
        }

        public int PredmetID { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<POLOZENI_ISPITI> POLOZENI_ISPITI { get; set; }
    }
}
