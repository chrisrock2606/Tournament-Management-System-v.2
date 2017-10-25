namespace DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.TEAM")]
    public partial class TEAM : IID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEAM()
        {
            MATCHes = new HashSet<MATCH>();
            PLAYERs = new HashSet<PLAYER>();
            ROUNDs = new HashSet<ROUND>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamID_PK { get; set; }

        [Required]
        [StringLength(30)]
        public string TeamName { get; set; }

        public int LeagueID_FK { get; set; }

        public int LeaguePoint { get; set; }

        public virtual LEAGUE LEAGUE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATCH> MATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAYER> PLAYERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUND> ROUNDs { get; set; }

        public int ID
        {
            get
            {
                return TeamID_PK;
            }

            set
            {
                TeamID_PK = ID;
            }
        }
    }
}
