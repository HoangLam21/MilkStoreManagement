using MaterialDesignThemes.Wpf;
using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using OpenTK.Graphics.ES11;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace MilkStoreManagement.ViewModel
{
    class ImportViewModel : BaseViewModel
    {
        private ObservableCollection<PHIEUNHAP> _listPN;
        public ObservableCollection<PHIEUNHAP> listPN { get => _listPN; set { _listPN = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand LoadListPN { get; set; }
        public ICommand Print { get; set; }
        public ICommand AddPN { get; set; }
        public ICommand Search { get; set; }

        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }

        public ImportViewModel()
        {
            listTK = new ObservableCollection<string>() { "Mã PN", "Ngày" };
            listPN = new ObservableCollection<PHIEUNHAP>(DataProvider.Ins.DB.PHIEUNHAPs);
            LoadListPN = new RelayCommand<ImportView>((p) => true, (p) => _LoadListPN(p));
            Detail = new RelayCommand<ImportView>((p) => { return p.DatagridPN.SelectedItem == null ? false : true; }, (p) => _Detail(p));
            Print = new RelayCommand<ImportView>((p) => true, (p) => _Print(p));
            AddPN = new RelayCommand<ImportView>((p) => { return p == null ? false : true; }, (p) => _AddPN(p));
            Search = new RelayCommand<ImportView>((p) => true, (p) => _Search(p));

        }
        void _LoadListPN(ImportView p)
        {
            listTK = new ObservableCollection<string>() { "Mã PN", "Ngày" };
            var query = (from pn in DataProvider.Ins.DB.PHIEUNHAPs
                         join nv in DataProvider.Ins.DB.NHANVIENs on pn.MANV equals nv.MANV
                         orderby pn.MAPNHAP ascending
                         select new
                         {
                             MAPNHAP = pn.MAPNHAP,
                             TENNV = nv.TENNV,
                             MANV = pn.MANV,
                             NGAYNHAP = pn.NGAYNHAP,
                         });
            var list = query.ToList();
            var listPN = new ObservableCollection<object>(list.Select(e => new
            {
                MAPNHAP = e.MAPNHAP,
                MANV = e.MANV,
                TENNV = e.TENNV,
                NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
            }));
            p.DatagridPN.ItemsSource = listPN;
        }
        void _Detail(ImportView p)
        {
            if (p.DatagridPN.SelectedItem != null)
            {
                var selectedItem = (dynamic)p.DatagridPN.SelectedItem;
                p.MAPNHAP.Text = selectedItem.MAPNHAP;
                p.TENNV.Text = selectedItem.TENNV;
                p.NGAYNHAP.Text = selectedItem.NGAYNHAP.ToString();
            }
            var query = (from ctpn in DataProvider.Ins.DB.CTPNs
                         join sp in DataProvider.Ins.DB.SANPHAMs on ctpn.MASP equals sp.MASP
                         orderby sp.MASP
                         select new
                         {
                             MAPNHAP = ctpn.MAPNHAP,
                             MASP = sp.MASP,
                             TENSP = sp.TENSP,
                             MANCC = sp.MANCC,
                             SL = ctpn.SLNHAP,
                             GIANHAP = ctpn.GIANHAP
                         }).Where(e => e.MAPNHAP == p.MAPNHAP.Text);

            var list = query.ToList();
            var listSPNHAP = new ObservableCollection<object>(list.Select(e => new
            {
                MASP = e.MASP,
                TENSP = e.TENSP,
                MANCC = e.MANCC,
                SL = e.SL,
                GIANHAP = e.GIANHAP
            }));
            p.ListViewSP.ItemsSource = listSPNHAP;

            var query1 = (from ctpn in DataProvider.Ins.DB.CTPNs
                          group ctpn by ctpn.MAPNHAP into g
                          select new
                          {
                              MAPNHAP = g.Key,
                              THANHTIEN = g.Sum(ctpn => ctpn.SLNHAP * ctpn.GIANHAP)
                          }).Where(e => e.MAPNHAP == p.MAPNHAP.Text);
            foreach (var item in query1)
            {
                p.THANHTIEN.Text = string.Format("{0:0,0} VNĐ", item.THANHTIEN);
            }
        }
        void _Print(ImportView p)
        {
            PrintImport printImport = new PrintImport();
            if (p.DatagridPN.SelectedItem != null)
            {
                var selectedItem = (dynamic)p.DatagridPN.SelectedItem;
                printImport.MAPNHAP.Text = selectedItem.MAPNHAP;
                printImport.NGAYNHAP.Text = selectedItem.NGAYNHAP.ToString();
                printImport.TENNV.Text = selectedItem.TENNV;
            }
            var query = (from ctpn in DataProvider.Ins.DB.CTPNs
                         join sp in DataProvider.Ins.DB.SANPHAMs on ctpn.MASP equals sp.MASP
                         orderby sp.MASP
                         select new
                         {
                             MAPNHAP = ctpn.MAPNHAP,
                             MASP = sp.MASP,
                             TENSP = sp.TENSP,
                             MANCC = sp.MANCC,
                             SL = ctpn.SLNHAP,
                             GIANHAP = ctpn.GIANHAP
                         }).Where(e => e.MAPNHAP == p.MAPNHAP.Text);

            var list = query.ToList();
            var listSPNHAP = new ObservableCollection<object>(list.Select(e => new
            {
                MASP = e.MASP,
                TENSP = e.TENSP,
                MANCC = e.MANCC,
                SL = e.SL,
                GIANHAP = e.GIANHAP
            }));
            printImport.ListViewSP.ItemsSource = listSPNHAP;
            p.DatagridPN.SelectedItem = null;

            var query1 = (from ctpn in DataProvider.Ins.DB.CTPNs
                          group ctpn by ctpn.MAPNHAP into g
                          select new
                          {
                              MAPNHAP = g.Key,
                              THANHTIEN = g.Sum(ctpn => ctpn.SLNHAP * ctpn.GIANHAP)
                          }).Where(e => e.MAPNHAP == p.MAPNHAP.Text);
            foreach (var item in query1)
            {
                printImport.THANHTIEN.Text = string.Format("{0:0,0} VNĐ", item.THANHTIEN);
            }
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(printImport.PrintView, "IMPORT");
                }
            }
            finally
            {

            }
            MessageBox.Show("In Phiếu nhập thành công !", "THÔNG BÁO");
        }
        //void _Search(ImportView p)
        //{
        //    ObservableCollection<object> temp = new ObservableCollection<object>();
        //    var query = (from pn in DataProvider.Ins.DB.PHIEUNHAPs
        //                 join nv in DataProvider.Ins.DB.NHANVIENs on pn.MANV equals nv.MANV
        //                 orderby pn.MAPNHAP ascending
        //                 select new
        //                 {
        //                     MAPNHAP = pn.MAPNHAP,
        //                     TENNV = nv.TENNV,
        //                     MANV = pn.MANV,
        //                     NGAYNHAP = pn.NGAYNHAP,
        //                 });
        //    if (p.txbSearch.Text != "")
        //    {
        //        switch (listTK[p.cbxChon.SelectedIndex])
        //        {
        //            case "Mã PN":
        //                {
        //                    var list = query.ToList().Where(e => e.MAPNHAP.ToLower().Contains(p.txbSearch.Text.ToLower())).ToList();
        //                    temp = new ObservableCollection<object>(list.Select(e => new
        //                    {
        //                        MAPNHAP = e.MAPNHAP,
        //                        MANV = e.MANV,
        //                        TENNV = e.TENNV,
        //                        NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
        //                    }));
        //                    p.DatagridPN.ItemsSource = temp;    
        //                    break;
        //                }
        //            case "Tên NQL":
        //                {
        //                    var list = query.ToList().Where(e => e.TENNV.ToLower().Contains(p.txbSearch.Text.ToLower())).ToList();
        //                    temp = new ObservableCollection<object>(list.Select(e => new
        //                    {
        //                        MAPNHAP = e.MAPNHAP,
        //                        MANV = e.MANV,
        //                        TENNV = e.TENNV,
        //                        NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
        //                    }));
        //                    p.DatagridPN.ItemsSource = temp;
        //                    break;
        //                }
        //            case "Ngày":
        //                {
        //                    var list = query.ToList().Where(e => e.NGAYNHAP.ToString().Contains(p.txbSearch.Text.ToLower())).ToList();
        //                    temp = new ObservableCollection<object>(list.Select(e => new
        //                    {
        //                        MAPNHAP = e.MAPNHAP,
        //                        MANV = e.MANV,
        //                        TENNV = e.TENNV,
        //                        NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
        //                    }));
        //                    p.DatagridPN.ItemsSource = temp;
        //                    break;
        //                }
        //        }
        //    }
        //    else
        //    {
        //        _LoadListPN(p);
        //    }
        //}
        void _Search(ImportView p)
        {
            if (p.txbSearch.Text != "")
            {
                switch (p.cbxChon.SelectedItem.ToString())
                {
                    case "Mã PN":
                        {
                            var query = (from pn in DataProvider.Ins.DB.PHIEUNHAPs
                                         join nv in DataProvider.Ins.DB.NHANVIENs on pn.MANV equals nv.MANV
                                         orderby pn.MAPNHAP ascending
                                         select new
                                         {
                                             MAPNHAP = pn.MAPNHAP,
                                             TENNV = nv.TENNV,
                                             MANV = pn.MANV,
                                             NGAYNHAP = pn.NGAYNHAP,
                                         }).Where(e => e.MAPNHAP.ToLower().Contains(p.txbSearch.Text.ToLower()));
                            var list = query.ToList();
                            var listPN = new ObservableCollection<object>(list.Select(e => new
                            {
                                MAPNHAP = e.MAPNHAP,
                                MANV = e.MANV,
                                TENNV = e.TENNV,
                                NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
                            }));
                            p.DatagridPN.ItemsSource = listPN;
                            break;
                        }
                    case "Ngày":
                        {
                            string searchText = p.txbSearch.Text;
                            string[] dateComponents = searchText.Split('/');

                            int? day = null;
                            int? month = null;
                            int? year = null;

                            if (dateComponents.Length >= 1)
                            {
                                int parsedDay;
                                if (int.TryParse(dateComponents[0], out parsedDay))
                                {
                                    day = parsedDay;
                                }
                            }

                            if (dateComponents.Length >= 2)
                            {
                                int parsedMonth;
                                if (int.TryParse(dateComponents[1], out parsedMonth))
                                {
                                    month = parsedMonth;
                                }
                            }

                            if (dateComponents.Length >= 3)
                            {
                                int parsedYear;
                                if (int.TryParse(dateComponents[2], out parsedYear))
                                {
                                    year = parsedYear;
                                }
                            }

                            var query = (from pn in DataProvider.Ins.DB.PHIEUNHAPs
                                         join nv in DataProvider.Ins.DB.NHANVIENs on pn.MANV equals nv.MANV
                                         orderby pn.MAPNHAP ascending
                                         where (day == null || pn.NGAYNHAP.Day == day) &&
                                               (month == null || pn.NGAYNHAP.Month == month) &&
                                               (year == null || pn.NGAYNHAP.Year == year)
                                         select new
                                         {
                                             MAPNHAP = pn.MAPNHAP,
                                             TENNV = nv.TENNV,
                                             MANV = pn.MANV,
                                             NGAYNHAP = pn.NGAYNHAP,
                                         });

                            var list = query.ToList();
                            var listPN = new ObservableCollection<object>(list.Select(e => new
                            {
                                MAPNHAP = e.MAPNHAP,
                                MANV = e.MANV,
                                TENNV = e.TENNV,
                                NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
                            }));

                            p.DatagridPN.ItemsSource = listPN;
                            break;
                        }
                    default:
                        {
                            var query = (from pn in DataProvider.Ins.DB.PHIEUNHAPs
                                         join nv in DataProvider.Ins.DB.NHANVIENs on pn.MANV equals nv.MANV
                                         orderby pn.MAPNHAP ascending
                                         select new
                                         {
                                             MAPNHAP = pn.MAPNHAP,
                                             TENNV = nv.TENNV,
                                             MANV = pn.MANV,
                                             NGAYNHAP = pn.NGAYNHAP,
                                         }).Where(e => e.MAPNHAP.ToLower().Contains(p.txbSearch.Text.ToLower()));
                            var list = query.ToList();
                            var listPN = new ObservableCollection<object>(list.Select(e => new
                            {
                                MAPNHAP = e.MAPNHAP,
                                MANV = e.MANV,
                                TENNV = e.TENNV,
                                NGAYNHAP = e.NGAYNHAP.ToShortDateString(),
                            }));
                            p.DatagridPN.ItemsSource = listPN;
                            break;
                        }
                }
            }
            else
            {
                _LoadListPN(p);
            }
        }
        void _AddPN(ImportView p)
        {
            AddImportView addImport = new AddImportView();
            addImport.ShowDialog();
            _LoadListPN(p);
            _Search(p);
        }
    }
}
