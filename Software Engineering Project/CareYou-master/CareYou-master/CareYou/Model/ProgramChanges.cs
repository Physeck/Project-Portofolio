//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareYou.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProgramChanges
    {
        public int ChangesID { get; set; }
        public int ProgramID { get; set; }
        public string ChangesDesc { get; set; }
        public int ChangesTarget { get; set; }
        public string ChangesImage { get; set; }
        public System.DateTime ChangesEndDate { get; set; }
        public bool isApproved { get; set; }
        public System.DateTime DateSubmitted { get; set; }
        public Nullable<int> AdminID { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Program Program { get; set; }
    }
}
