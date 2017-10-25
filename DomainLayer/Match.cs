namespace DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.MATCH")]
    public partial class MATCH : IID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatchID_PK { get; set; }

        public int RoundID_FK { get; set; }

        public int Winner { get; set; }

        public virtual ROUND ROUND { get; set; }

        public virtual TEAM TEAM { get; set; }


        public int ID
        {
            get
            {
                return MatchID_PK;
            }

            set
            {
                MatchID_PK = ID;
            }
        }
    }
}
