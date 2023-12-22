using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using Syncfusion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MilkStoreManagement.ViewModel
{
    public class AddImportViewModel : BaseViewModel
    {
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand Search { get; set; }
        public ICommand AddSP { get; set; }
        public ICommand ChooseCTPN { get; set; }
        public decimal THANHTIEN = 0;
        public ICommand Delete { get; set; }
        public ICommand AddCTPN { get; set; }

        public AddImportViewModel()
        {
            Closewd = new RelayCommand<AddImportView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<AddImportView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<AddImportView>((p) => true, (p) => moveWindow(p));
            Loadwd = new RelayCommand<AddImportView>((p) => true, (p) => _Loadwd(p));
            Search = new RelayCommand<AddImportView>((p) => true, (p) => _Search(p));
            AddSP = new RelayCommand<AddImportView>((p) => true, (p) => _AddSP(p));
            ChooseCTPN = new RelayCommand<AddImportView>((p) => true, (p) => _ChooseCTPN(p));
            Delete = new RelayCommand<AddImportView>((p) => true, (p) => _Delete(p));
            AddCTPN = new RelayCommand<AddImportView>((p) => true, (p) => _AddCTPN(p));
        }
        void moveWindow(AddImportView p)
        {
            p.DragMove();
        }
        void Close(AddImportView p)
        {
            p.Close();
        }
        void Minimize(AddImportView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void LoadListSP(AddImportView p)
        {
            var query = (from sp in DataProvider.Ins.DB.SANPHAMs
                         where sp.SL >= 0
                         orderby sp.MASP
                         select new
                         {
                             MASP = sp.MASP,
                             TENSP = sp.TENSP,
                             MANCC = sp.MANCC,
                             SL = sp.SL,
                             GIABAN = sp.GIABAN
                         });
            var list = query.ToList();
            var listSPNHAP = new ObservableCollection<object>(list.Select(e => new
            {
                MASP = e.MASP,
                TENSP = e.TENSP,
                MANCC = e.MANCC,
                SL = e.SL,
                GIABAN = e.GIABAN
            }));
            p.ListViewSP.ItemsSource = listSPNHAP;
        }
        void _Loadwd(AddImportView p)
        {
            LoadListSP(p);
            p.MANV.Text = Const.NV.MANV.ToString();
            p.NGAYNHAP.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        void _Search(AddImportView p)
        {
            if (p.txbSearch.Text != "")
            {
                var query = (from sp in DataProvider.Ins.DB.SANPHAMs
                             where sp.SL >= 0
                             orderby sp.MASP
                             select new
                             {
                                 MASP = sp.MASP,
                                 TENSP = sp.TENSP,
                                 MANCC = sp.MANCC,
                                 SL = sp.SL,
                                 GIABAN = sp.GIABAN
                             });
                var list = query.ToList().Where(e => e.TENSP.ToLower().Contains(p.txbSearch.Text.ToLower())).ToList();
                var listSP = new ObservableCollection<object>(list.Select(e => new
                {
                    MASP = e.MASP,
                    TENSP = e.TENSP,
                    MANCC = e.MANCC,
                    SL = e.SL,
                    GIABAN = e.GIABAN
                }));
                p.ListViewSP.ItemsSource = listSP;
            }
            else
            {
                var query = (from sp in DataProvider.Ins.DB.SANPHAMs
                             where sp.SL >= 0
                             orderby sp.MASP
                             select new
                             {
                                 MASP = sp.MASP,
                                 TENSP = sp.TENSP,
                                 MANCC = sp.MANCC,
                                 SL = sp.SL,
                                 GIABAN = sp.GIABAN
                             });
                var list = query.ToList();
                var listSP = new ObservableCollection<object>(list.Select(e => new
                {
                    MASP = e.MASP,
                    TENSP = e.TENSP,
                    MANCC = e.MANCC,
                    SL = e.SL,
                    GIABAN = e.GIABAN
                }));
                p.ListViewSP.ItemsSource = listSP;
            }
        }
        void _AddSP(AddImportView p)
        {
            AddProductView addProductView = new AddProductView();
            addProductView.ShowDialog();
        }
        public class CTSP
        {
            public string MASP { get; set; }
            public string TENSP { get; set; }
            public string MANCC { get; set; }
            public string SLNHAP { get; set; }
            public string GIANHAP { get; set; }
        }
        public ObservableCollection<CTSP> listSPNHAP = new ObservableCollection<CTSP>();

        void _ChooseCTPN(AddImportView p)
        {
            if (p.ListViewSP.SelectedItem != null)
            {
                var selectedItem = (dynamic)p.ListViewSP.SelectedItem;
                string masp = selectedItem.MASP;
                decimal gianhap = Convert.ToDecimal(p.GiaNhap.Text);
                if (gianhap <= 0)
                {
                    System.Windows.MessageBox.Show("Giá nhập không hợp lệ  !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (p.SLNHAP.Text == "")
                {
                    System.Windows.MessageBox.Show("Chưa nhập số lượng !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (p.GiaNhap.Text == "")
                {
                    System.Windows.MessageBox.Show("Chưa nhập giá nhập !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (int.Parse(p.SLNHAP.Text) < 1)
                {
                    System.Windows.MessageBox.Show("Số lượng nhập tối thiểu là 1 sản phẩm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var query = (from sp in DataProvider.Ins.DB.SANPHAMs
                             where sp.SL >= 0 && sp.MASP == masp
                             orderby sp.MASP
                             select new
                             {
                                 MASP = sp.MASP,
                                 TENSP = sp.TENSP,
                                 MANCC = sp.MANCC
                             });
                var list = query.ToList();
                foreach (var e in list)
                {
                    listSPNHAP.Add(new CTSP
                    {
                        MASP = e.MASP,
                        TENSP = e.TENSP,
                        MANCC = e.MANCC,
                        SLNHAP = p.SLNHAP.Text,
                        GIANHAP = string.Format("{0:#,###} VNĐ", (gianhap))
                    });
                    THANHTIEN += int.Parse(p.SLNHAP.Text) * gianhap;
                    p.THANHTIEN.Text = string.Format("{0:#,###} VNĐ", (THANHTIEN));
                }
                p.ListCTPN.ItemsSource = listSPNHAP;
            }
            else
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        void _Delete(AddImportView p)
        {
            if (p.ListCTPN.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sản phẩm.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                var selectItem = (dynamic)p.ListCTPN.SelectedItem;
                THANHTIEN -= int.Parse(selectItem.SLNHAP) * decimal.Parse(selectItem.GIANHAP.Replace(" VNĐ", "").Replace(",", ""));
                listSPNHAP.Remove(selectItem);
                if (listSPNHAP.Count == 0)
                {
                    p.THANHTIEN.Text = "0 VNĐ";
                }
                else
                {
                    p.THANHTIEN.Text = string.Format("{0:#,###} VNĐ", (THANHTIEN));
                }
            }
        }
        void _AddCTPN(AddImportView p)
        {
            if (string.IsNullOrEmpty(p.MAPNHAP.Text) || string.IsNullOrEmpty(p.MAPNHAP.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn thêm phiếu nhập mới ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (h == MessageBoxResult.Yes)
                {
                    if (DataProvider.Ins.DB.PHIEUNHAPs.Where(e => e.MAPNHAP == p.MAPNHAP.Text).Count() > 0)
                    {
                        MessageBox.Show("Mã phiếu nhập đã tồn tại.", "Thông Báo");
                    }
                    else
                    {
                        PHIEUNHAP temp = new PHIEUNHAP()
                        {
                            MAPNHAP = p.MAPNHAP.Text.Trim(),
                            MANV = Const.NV.MANV,
                            NGAYNHAP = DateTime.Now,
                            CTPNs = new ObservableCollection<CTPN>(),
                        };
                        foreach (CTSP ct in listSPNHAP)
                        {
                            CTPN ctpn = new CTPN()
                            {
                                MASP = ct.MASP,
                                SLNHAP = int.Parse(ct.SLNHAP),
                                GIANHAP = decimal.Parse(ct.GIANHAP.Replace(" VNĐ", "").Replace(",", "")),
                            };
                            temp.CTPNs.Add(ctpn);
                            SANPHAM sp = DataProvider.Ins.DB.SANPHAMs.FirstOrDefault(s => s.MASP == ct.MASP);
                            if (sp != null)
                            {
                                sp.SL += int.Parse(ct.SLNHAP);
                            }
                        }
                        DataProvider.Ins.DB.PHIEUNHAPs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thêm phiếu nhập thành công !", "THÔNG BÁO");
                        p.MAPNHAP.Clear();
                        p.SLNHAP.Clear();
                        p.GiaNhap.Clear();
                        p.ListCTPN.SelectedItem = null;
                        p.ListViewSP.SelectedItem = null;
                        p.THANHTIEN.Clear();
                        listSPNHAP.Clear();
                        p.Close();
                    }
                }
            }
        }

    }

}
