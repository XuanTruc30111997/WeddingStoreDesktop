//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingStoreDesktop.Models.SystemModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGia
    {
        public string MaDG { get; set; }
        public string MaKH { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> CommentDate { get; set; }
        public Nullable<int> SaoDanhGia { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}
