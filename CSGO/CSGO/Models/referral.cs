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
    
    public partial class referral
    {
        public string referral1 { get; set; }
        public int count { get; set; }
        public int fk_user { get; set; }
        public int fk_giveaway { get; set; }
    
        public virtual giveaway giveaway { get; set; }
        public virtual user user { get; set; }

		public string referralLink
		{
			get
			{
				return "Users/Referral/" + referral1;
			}
		}
	}
}
