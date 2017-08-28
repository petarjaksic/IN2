namespace IN2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class POLOZENI_ISPITI
    {
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int PredmetID { get; set; }
        [Required]
        [Range(6, 10)]
        public int Ocena { get; set; }

        public PREDMET PREDMET { get; set; }

        public STUDENT STUDENT { get; set; }
    }
}
