//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSGO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public match()
        {
            this.bettings = new HashSet<betting>();
            this.teams = new HashSet<team>();
            this.tournaments = new HashSet<tournament>();
            this.places = new HashSet<place>();
        }
    
        public int id { get; set; }
        public System.DateTime start_time { get; set; }
        public string map { get; set; }
        public string result { get; set; }
        public bool is_broadcasted { get; set; }
        public bool is_registration_open { get; set; }
        public Nullable<int> fk_first_team { get; set; }
        public Nullable<int> fk_second_team { get; set; }
        public Nullable<int> fk_tournament { get; set; }
        public Nullable<int> fk_place { get; set; }
        public Nullable<int> fk_betting { get; set; }
        public Nullable<int> fk_ticket { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<betting> bettings { get; set; }
        public virtual betting betting { get; set; }
        public virtual tournament tournament { get; set; }
        public virtual ticket ticket { get; set; }
        public virtual place place { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<team> teams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tournament> tournaments { get; set; }
        public virtual ticket ticket1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<place> places { get; set; }
        public virtual team team { get; set; }
        public virtual team team1 { get; set; }
    }
}
