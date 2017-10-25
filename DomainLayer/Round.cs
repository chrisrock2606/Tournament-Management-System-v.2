namespace DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.ROUND")]
    public partial class ROUND : IID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROUND()
        {
            MATCHes = new HashSet<MATCH>();
            TEAMs = new HashSet<TEAM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoundID_PK { get; set; }

        [Required]
        [StringLength(30)]
        public string RoundName { get; set; }

        [StringLength(30)]
        public string RoundType { get; set; }

        public int LeagueID_FK { get; set; }

        public virtual LEAGUE LEAGUE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATCH> MATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEAM> TEAMs { get; set; }

        public int ID
        {
            get
            {
                return RoundID_PK;
            }

            set
            {
                RoundID_PK = ID;
            }
        }
    }
}
