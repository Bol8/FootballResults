//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDomain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partido
    {
        public int IdPartido { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int FTHG { get; set; }
        public int FTAG { get; set; }
        public System.DateTime Date { get; set; }
        public string FTR { get; set; }
        public string Liga { get; set; }
        public Nullable<int> LigaTemporada { get; set; }
    
        public virtual LigaTemporada LigaTemporada1 { get; set; }
    }
}
