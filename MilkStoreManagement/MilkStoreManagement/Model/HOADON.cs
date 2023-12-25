//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilkStoreManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            this.CTHDs = new HashSet<CTHD>();
        }

        public int SOHD { get; set; }
        public DateTime NGHD { get; set; }
        public string MAKH { get; set; }
        public string MANV { get; set; }
        public decimal TRIGIA { get; set; }
        public decimal KHUYENMAI { get; set; }
        public decimal THANHTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public string AVA
        {
            get
            {
                if (string.IsNullOrEmpty(NHANVIEN.AVA))
                {
                    return Const._localLink + @"Resource\Ava\Ava_Default.jpg";
                }
                else if (NHANVIEN.AVA.Contains(Const._localLink))
                {
                    return NHANVIEN.AVA;
                }
                else
                {
                    return Const._localLink + NHANVIEN.AVA;
                }
            }
            set { NHANVIEN.AVA = value; }
        }
    }
}
