using MilkStoreManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkStoreManagement.Model
{
    public class Const : BaseViewModel
    {
        public static string TenDangNhap { get; set; }
        public static bool Admin { get; set; }
        public static NHANVIEN NV { get; set; }
        public static string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
    }
}
