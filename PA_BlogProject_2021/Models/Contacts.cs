//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PA_BlogProject_2021.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contacts
    {
        public int ContactId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string LinkedinURL { get; set; }
        public string GithubURL { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime RegisterDate { get; set; }
    }
}