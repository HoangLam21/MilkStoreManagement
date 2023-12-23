using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xamarin.Forms.Platform.WPF.Helpers;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace MilkStoreManagement.ViewModel
{

    public class RevenueViewModel : BaseViewModel
    {
        public class SP
        {
            public SP(string _masp, string _tensp, int _soluong, string _giaban, string _tongthu)
            {
                masp = _masp;
                tensp = _tensp;
                soluong = _soluong;
                giaban = _giaban;
                tongthu = _tongthu;
            }
            public string masp { get; set; }
            public string tensp { get; set; }
            public int soluong { get; set; }
            public string giaban { get; set; }
            public string tongthu { get; set; }
        }
        public class THONGTINNHAP
        {
            public THONGTINNHAP(string _masp, string _tensp, int _soluong, string _gianhap, string _tong)
            {
                masp = _masp;
                tensp = _tensp;
                soluong = _soluong;
                gianhap = _gianhap;
                tong = _tong;
            }

            public string masp { get; set; }
            public string tensp { get; set; }
            public int soluong { get; set; }
            public string gianhap { get; set; }
            public string tong { get; set; }
        }


        public ICommand LoadThu { get; set; }
        public ICommand LoadChi { get; set; }
        public ICommand LoadLoiNhuan { get; set; }
        public ICommand LoadThuList { get; set; }
        public ICommand LoadChiList { get; set; }
        public ICommand ComboboxYearChanged { get; set; }
        public ICommand ComboboxQuyChanged { get; set; }
        public ICommand Print { get; set; }
        private decimal? THU;
        private decimal? CHI;
        public ICommand SelectionChangedCommand { get; set; }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<string, string> YFormatter { get; set; }
        public List<long> ValuesOut { get; set; }
        public RevenueViewModel()
        {

            LoadThu = new RelayCommand<RevenueView>((p) => true, (p) => _LoadThu(p));
            LoadChi = new RelayCommand<RevenueView>((p) => true, (p) => _LoadChi(p));
            LoadLoiNhuan = new RelayCommand<RevenueView>((p) => true, (p) => _LoadLoiNhuan(p));
            LoadThuList = new RelayCommand<RevenueView>((p) => true, (p) => _LoadThuList(p));
            LoadChiList = new RelayCommand<RevenueView>((p) => true, (p) => _LoadNhapList(p));
            SelectionChangedCommand = new RelayCommand<RevenueView>((p) => true, (p) => OnSelectionChanged(p));
            LoadChart();
            Color lineColor = (Color)ColorConverter.ConvertFromString("#FFCA08");
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<long>(ValuesOut),
                    Stroke = new SolidColorBrush(lineColor),
                    Title = "Doanh Thu"
                }
            };
            Print = new RelayCommand<RevenueView>((p) => true, (p) => _Print(p));

        }
        public void OnSelectionChanged(RevenueView p)
        {
            ReloadDataForSelection(p);

        }

        public int GetComboboxQuyMaHoa(RevenueView p)
        {

            if (p.TheoQuyItem0.IsSelected) { return 2; }
            if (p.TheoQuyItem1.IsSelected) { return 5; }
            if (p.TheoQuyItem2.IsSelected) { return 8; }
            if (p.TheoQuyItem3.IsSelected) { return 11; }
            return 0;
        }
        public bool CheckQuy(int Month, int Quy)
        {
            if ((Month == 1 || Month == 2 || Month == 3) && (Quy == 1))
            {
                return true;
            }
            else if ((Month == 4 || Month == 5 || Month == 6) && (Quy == 2))
            {
                return true;
            }
            else if ((Month == 7 || Month == 8 || Month == 9) && (Quy == 3))
            {
                return true;
            }
            else if ((Month == 10 || Month == 11 || Month == 12) && (Quy == 4))
            {
                return true;
            }
            else { return false; }

        }
        public List<int> _GetYearFromDB()
        {
            List<int> years = new List<int>();
            var query = from HD in DataProvider.Ins.DB.HOADONs
                        orderby HD.NGHD.Year descending
                        select new
                        {
                            year = HD.NGHD.Year
                        };
            var _years = query.Select(x => x.year).Distinct();
            foreach (var y in _years.ToList())
            {
                years.Add(int.Parse(y.ToString()));

            }
            years.Reverse();
            return years;
        }
        public void _SetYearCombobox(RevenueView p)
        {
            p.TheoNam.ItemsSource = _GetYearFromDB();

        }

        public void _LoadThu(RevenueView p)
        {
            _SetYearCombobox(p);
            if (p.TheoNam.SelectedItem != null && p.TheoQuy.SelectedItem != null)
            {
                int year = int.Parse(p.TheoNam.SelectedItem.ToString()); //GetComboboxYear(p);
                int quy = GetComboboxQuyMaHoa(p);
                decimal? Thu;
                try
                {
                    Thu = DataProvider.Ins.DB.HOADONs.Where(x => x.NGHD.Year == year && Math.Abs(x.NGHD.Month - quy) <= 1).Select(x => x.TRIGIA).Sum();
                    p.ThucThu.Text = String.Format("{0:0,0}", Thu) + "VND";
                }
                catch
                {
                    Thu = 0;
                    p.ThucThu.Text = "0VND";
                }

                THU = Thu;
            }

        }
        public void _LoadChi(RevenueView p)
        {
            if (p.TheoNam.SelectedItem != null)
            {
                int year = int.Parse(p.TheoNam.SelectedItem.ToString());//GetComboboxYear(p);
                int quy = GetComboboxQuyMaHoa(p);
                var query = from CTN in DataProvider.Ins.DB.CTPNs
                            join SP in DataProvider.Ins.DB.SANPHAMs on CTN.MASP equals SP.MASP
                            join PN in DataProvider.Ins.DB.PHIEUNHAPs on CTN.MAPNHAP equals PN.MAPNHAP
                            where SP.MASP == CTN.MASP && CTN.MAPNHAP == PN.MAPNHAP
                            select new
                            {
                                tonggia = SP.GIABAN * CTN.SLNHAP,
                                ng = PN.NGAYNHAP

                            };
                decimal? Chi;
                try
                {
                    Chi = query.Where(x => x.ng.Year == year && Math.Abs(x.ng.Month - quy) <= 1).Select(x => x.tonggia).Sum();
                    p.ThucChi.Text = String.Format("{0:0,0}", Chi) + "VND";
                }
                catch
                {
                    Chi = 0;
                    p.ThucChi.Text = "0VND";
                }

                CHI = Chi;
            }

        }

        public void _LoadLoiNhuan(RevenueView p)
        {
            if (p.TheoNam.SelectedItem != null)
            {
                if (THU - CHI <= 0)
                {
                    p.LoiNhuan.Text = 0 + "VND";
                }
                else
                {
                    p.LoiNhuan.Text = String.Format("{0:0,0}", THU - CHI) + "VND";
                }
            }


        }

        public void _LoadThuList(RevenueView p)
        {
            if (p.TheoNam.SelectedItem != null)
            {
                p.listThu.ItemsSource = _SelectDataForThu(p);
            }
        }
        public void _LoadNhapList(RevenueView p)
        {
            if (p.TheoNam.SelectedItem != null)
            {
                p.listChi.ItemsSource = _SelectDataForNhap(p);
            }
        }
        public List<SP> _SelectDataForThu(RevenueView p)
        {
            int year = int.Parse(p.TheoNam.SelectedItem.ToString());
            int quy = GetComboboxQuyMaHoa(p);
            var query = from CT in DataProvider.Ins.DB.CTHDs
                        join SP in DataProvider.Ins.DB.SANPHAMs on CT.MASP equals SP.MASP
                        join HD in DataProvider.Ins.DB.HOADONs on CT.SOHD equals HD.SOHD
                        where (HD.NGHD.Year == year && Math.Abs(HD.NGHD.Month - quy) <= 1)
                        group CT by new { CT.MASP, SP.TENSP, SP.GIABAN } into g
                        select new
                        {
                            masp = g.Key.MASP,
                            tensp = g.Key.TENSP,
                            soluong = g.Count(),
                            giaban = g.Key.GIABAN,
                            tongthu = g.Count() * g.Key.GIABAN
                        };
            List<SP> sps = new List<SP>();
            foreach (var field in query.ToList())
            {
                sps.Add(new SP(field.masp, field.tensp, field.soluong, String.Format("{0:0,0}", field.giaban), String.Format("{0:0,0}", field.tongthu)));
            }

            return sps;
        }
        public List<THONGTINNHAP> _SelectDataForNhap(RevenueView p)
        {
            int year = int.Parse(p.TheoNam.SelectedItem.ToString());
            int quy = GetComboboxQuyMaHoa(p);
            var query = from CTN in DataProvider.Ins.DB.CTPNs
                        join SP in DataProvider.Ins.DB.SANPHAMs on CTN.MASP equals SP.MASP
                        join PN in DataProvider.Ins.DB.PHIEUNHAPs on CTN.MAPNHAP equals PN.MAPNHAP
                        where (PN.NGAYNHAP.Year == year && Math.Abs(PN.NGAYNHAP.Month - quy) <= 1)
                        select new
                        {
                            masp = CTN.MASP,
                            tensp = SP.TENSP,
                            soluongnhap = CTN.SLNHAP,
                            gianhap = CTN.GIANHAP,
                            tong = CTN.SLNHAP * CTN.GIANHAP
                        };
            List<THONGTINNHAP> sps = new List<THONGTINNHAP>();
            foreach (var field in query.ToList())
            {
                sps.Add(new THONGTINNHAP(field.masp, field.tensp, field.soluongnhap, String.Format("{0:0,0}", field.gianhap), String.Format("{0:0,0}", field.tong)));
            }

            return sps;
        }
        public void LoadChart()
        {
            List<int> years = _GetYearFromDB();
            Labels = new List<string>();
            ValuesOut = new List<long>();
            int i = 0;
            foreach (int y in years)
            {
                decimal? Thu;
                try
                {
                    Thu = DataProvider.Ins.DB.HOADONs.Where(x => x.NGHD.Year == y).Select(x => x.TRIGIA).Sum();
                }
                catch
                {
                    Thu = 0;
                }
                var query = from CTN in DataProvider.Ins.DB.CTPNs
                            join SP in DataProvider.Ins.DB.SANPHAMs on CTN.MASP equals SP.MASP
                            join PN in DataProvider.Ins.DB.PHIEUNHAPs on CTN.MAPNHAP equals PN.MAPNHAP
                            where SP.MASP == CTN.MASP && CTN.MAPNHAP == PN.MAPNHAP
                            select new
                            {
                                tonggia = SP.GIABAN * CTN.SLNHAP,
                                ng = PN.NGAYNHAP

                            };
                decimal? Chi;
                try
                {

                    Chi = query.Where(x => x.ng.Year == y).Select(x => x.tonggia).Sum();
                }
                catch
                {
                    Chi = 0;
                }
                ValuesOut.Add(long.Parse(String.Format("{0:0}", Thu - Chi)));
                i++;
                Labels.Add(y.ToString());
            }


        }
        public void ReloadDataForSelection(RevenueView p)
        {
            _LoadThu(p);
            _LoadChi(p);
            _LoadLoiNhuan(p);
            _LoadThuList(p);
            _LoadNhapList(p);
        }

        public void _Print(RevenueView p)
        {
            PrintRevenueReport printRevenueReport = new PrintRevenueReport();
            printRevenueReport.NGIn.Text = "Ngày giờ in: " + DateTime.Now.ToString();
            printRevenueReport.NGThongKe.Text = "Thời gian thống kê :" + p.TheoQuy.SelectedItem.ToString().Split(' ')[1] + " " + p.TheoQuy.SelectedItem.ToString().Split(' ')[2] + " " + p.TheoNam.SelectedItem.ToString();
            printRevenueReport.TongThu.Text = "Tổng thu: " + p.ThucThu.Text;
            printRevenueReport.TongChi.Text = "Tổng chi: " + p.ThucChi.Text;
            printRevenueReport.DoanhThu.Text = "Lợi nhuận: " + p.LoiNhuan.Text;
            if (p.TheoNam.SelectedItem != null)
            {
                printRevenueReport.listThu.ItemsSource = _SelectDataForThu(p);
            }
            if (p.TheoNam.SelectedItem != null)
            {
                printRevenueReport.listChi.ItemsSource = _SelectDataForNhap(p);
            }
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(printRevenueReport.RevenueViewReport, "Report");
            }
        }
    }
}
