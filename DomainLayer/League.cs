namespace DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.LEAGUE")]
    public partial class LEAGUE : IID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEAGUE()
        {
            ROUNDs1 = new HashSet<ROUND>();
            TEAMs = new HashSet<TEAM>();
            
        }

        private void NextID()
        {
            
        }

        TEAM t = new TEAM { };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LeagueID_PK { get; set; }

        [Required]
        [StringLength(30)]
        public string LeagueName { get; set; }

        [StringLength(30)]
        public string Reward { get; set; }

        public int Rounds { get; set; }

        [Required]
        [StringLength(30)]
        public string GameName { get; set; }

        [Required]
        [StringLength(10)]
        public string LeagueStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUND> ROUNDs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEAM> TEAMs { get; set; }

        public bool TeamStatus { get; set; }

        public int ID
        {
            get
            {
                return LeagueID_PK;
            }

            set
            {
                LeagueID_PK = ID;
            }
        }
    }
}
