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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.HOADONs = new HashSet<HOADON>();
            this.LICHLAMVIECs = new HashSet<LICHLAMVIEC>();
            this.PHIEUNHAPs = new HashSet<PHIEUNHAP>();
        }
    
        public string MANV { get; set; }
        public string TENNV { get; set; }
        public string GIOI { get; set; }
        public DateTime NGSINH { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }
        public DateTime NGVL { get; set; }
        public decimal LUONG { get; set; }
        public int NGAYNGHI { get; set; }
        public string CHUCVU { get; set; }
        public string ID_QLY { get; set; }
        public string PASS { get; set; }
        private string _AVA;
        public string AVA
        {
            get
            {
                if (string.IsNullOrEmpty(_AVA))
                {
                    return Const._localLink + @"Resource\Ava\Ava_Default.jpg";
                }
                else if (_AVA.Contains(Const._localLink))
                {
                    return _AVA;
                }
                else
                {
                    return Const._localLink + _AVA;
                }
            }
            set { _AVA = value; }
        }
        public string EMAIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHLAMVIEC> LICHLAMVIECs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
    }
}
