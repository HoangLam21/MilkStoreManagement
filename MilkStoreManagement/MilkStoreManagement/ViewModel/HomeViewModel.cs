using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MilkStoreManagement.ViewModel
{
    public class Result
    {
        private string _Time;
        public string Time { get => _Time; set { _Time = value; } }
        private int _SP;
        public int SP { get => _SP; set { _SP = value; } }
        public Result(string t = "", int sp = 0)
        {
            Time = t; SP = sp;
        }
    }
    public class HomeViewModel : BaseViewModel
    {
        private string _DoanhThu;
        public string DoanhThu { get => _DoanhThu; set { _DoanhThu = value; OnPropertyChanged(); } }
        public string MaSanPham { get; set; }
        public int SL { get; set; }
        public DateTime Ngay { get; set; }
        public ICommand LoadDT { get; set; }
        public ICommand LoadDon { get; set; }
        public ICommand LoadChart { get; set; }
        public ICommand LoadSP { get; set; }
        public ICommand TenDangNhap_Loaded { get; set; }
        private NHANVIEN _User;
        public NHANVIEN User { get => _User; set { _User = value; OnPropertyChanged(); } }
        private ObservableCollection<NHANVIEN> _listNV;
        public ObservableCollection<NHANVIEN> listNV { get => _listNV; set { _listNV = value; OnPropertyChanged(); } }
        private ObservableCollection<KHACHHANG> _listKH;
        public ObservableCollection<KHACHHANG> listKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        private ObservableCollection<SANPHAM> _listSP;
        public ObservableCollection<SANPHAM> listSP { get => _listSP; set { _listSP = value; OnPropertyChanged(); } }
        public ICommand LoadNV { get; set; }

        public ICommand LoadKH { get; set; }
        public ICommand LoadListSP { get; set; }
        public List<Result> Data { get; set; }
        public HomeViewModel()
        {
            LoadDT = new RelayCommand<HomeView>((p) => true, (p) => _LoadDT(p));
            LoadDon = new RelayCommand<HomeView>((p) => true, (p) => _LoadDon(p));
            LoadSP = new RelayCommand<HomeView>((p) => true, (p) => _LoadSP(p));
            LoadChart = new RelayCommand<HomeView>((p) => true, (p) => LineChart(p));
            LoadNV = new RelayCommand<HomeView>((p) => true, (p) => _LoadNV(p));
            LoadKH = new RelayCommand<HomeView>((p) => true, (p) => _LoadKH(p));
            LoadListSP = new RelayCommand<HomeView>((p) => true, (p) => _LoadListSP(p));
            TenDangNhap_Loaded = new RelayCommand<HomeView>((p) => true, (p) => LoadTenND(p));
        }
        void _LoadSP(HomeView p)
        {
            int count = DataProvider.Ins.DB.SANPHAMs.Count();
            p.SoSanPham.Text = count.ToString() + " sản phẩm";
        }
        public void _LoadDon(HomeView p)
        {
            int count = DataProvider.Ins.DB.HOADONs.Where(x => x.NGHD.Day == DateTime.Now.Day && x.NGHD.Month == DateTime.Now.Month && x.NGHD.Year == DateTime.Now.Year).Count();
            p.SoDonHang.Text = count.ToString();
        }
        public void _LoadDT(HomeView p)
        {
            decimal total = 0;
            if (DataProvider.Ins.DB.HOADONs.Where(x => x.NGHD.Day == DateTime.Now.Day && x.NGHD.Month == DateTime.Now.Month && x.NGHD.Year == DateTime.Now.Year).Select(x => x.TRIGIA).Count() != 0)
            {
                total = DataProvider.Ins.DB.HOADONs.Where(x => x.NGHD.Day == DateTime.Now.Day && x.NGHD.Month == DateTime.Now.Month && x.NGHD.Year == DateTime.Now.Year).Select(x => x.TRIGIA).Sum();
                DoanhThu = total.ToString("#,### VNĐ");
            }
            else DoanhThu = "0 VNĐ";
            p.DoanhThu.Text = DoanhThu;
        }
        public void LineChart(HomeView p)
        {
            var query = from a in DataProvider.Ins.DB.CTHDs
                        join b in DataProvider.Ins.DB.HOADONs on a.SOHD equals b.SOHD
                        where a.SOHD == b.SOHD
                        select new HomeViewModel()
                        {
                            SL = a.SLMUA,
                            Ngay = b.NGHD,
                            MaSanPham = a.MASP
                        };

            Data = new List<Result>();

            DateTime currentDate = DateTime.Now.Date;
            DateTime startOfWeek = currentDate.AddDays(DayOfWeek.Monday - currentDate.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            string[] dayLabels = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            for (int i = 0; i < 7; i++)
            {
                DateTime date = startOfWeek.AddDays(i);
                int value = 0;

                int year = date.Year;
                int month = date.Month;
                int day = date.Day;

                if (query.Where(x => x.Ngay.Year == year && x.Ngay.Month == month && x.Ngay.Day == day).Select(x => x.SL).Count() > 0)
                {
                    value = query.Where(x => x.Ngay.Year == year && x.Ngay.Month == month && x.Ngay.Day == day).Select(x => x.SL).Sum();
                }

                Result result = new Result(dayLabels[i], value);
                Data.Add(result);
            }
            p.Chart.ItemsSource = Data;
        }
        void _LoadNV(HomeView p)
        {
            var query = (from nv in DataProvider.Ins.DB.NHANVIENs
                         join hd in DataProvider.Ins.DB.HOADONs on nv.MANV equals hd.MANV
                         group hd by new { nv.MANV, nv.TENNV } into g
                         orderby g.Count() descending
                         select new
                         {
                             MANV = g.Key.MANV,
                             TENNV = g.Key.TENNV,
                             SoDon = g.Count()
                         }).Take(3);

            var topEmployees = query.ToList();

            var listNV = new ObservableCollection<object>(topEmployees.Select(e => new
            {
                MANV = e.MANV,
                TENNV = getName(e.TENNV),
                SoDon = e.SoDon
            }));

            p.ListViewNV.ItemsSource = listNV;
        }
        void _LoadListSP(HomeView p)
        {
            var query = (from sp in DataProvider.Ins.DB.SANPHAMs
                         join cthd in DataProvider.Ins.DB.CTHDs on sp.MASP equals cthd.MASP
                         group cthd by new { sp.MASP, sp.TENSP } into g
                         orderby g.Sum(cthd => cthd.SLMUA) descending
                         select new
                         {
                             MASP = g.Key.MASP,
                             TENSP = g.Key.TENSP,
                             SL = g.Sum(cthd => cthd.SLMUA)
                         }).Take(10);
            var topSP = query.ToList();

            var listSP = new ObservableCollection<object>(topSP.Select(e => new
            {
                MASP = e.MASP,
                TENSP = e.TENSP,
                SL = e.SL
            }));

            p.ListViewSP.ItemsSource = listSP;
        }
        void _LoadKH(HomeView p)
        {
            var query = (from kh in DataProvider.Ins.DB.KHACHHANGs
                         orderby kh.DOANHSO descending
                         select new
                         {
                             MAKH = kh.MAKH,
                             TENKH = kh.TENKH,
                             DOANHSO = kh.DOANHSO
                         }).Take(3);

            var topCustomers = query.ToList();

            var listKH = new ObservableCollection<object>(topCustomers.Select(e => new
            {
                MAKH = e.MAKH,
                TENKH = getName(e.TENKH),
                DoanhSoKH = e.DOANHSO.ToString("#,###")
            })); ;

            p.ListViewKH.ItemsSource = listKH;
        }
        string getName(string fullName)
        {
            string[] words = fullName.Split(' ');
            return words[words.Length - 2] + " " + words[words.Length - 1];
        }
        public void LoadTenND(HomeView p)
        {
            string a = Const.TenDangNhap;
            User = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == a).FirstOrDefault();

            p.TenNV.Text = "Hello, " + User.TENNV.Split(' ')[User.TENNV.Split(' ').Length - 1];
        }
    }
}
