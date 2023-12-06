using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Globalization;
using static OpenTK.Graphics.OpenGL.GL;
using OpenTK.Graphics.ES11;

namespace MilkStoreManagement.ViewModel
{
    public class DetailProductViewModel : BaseViewModel
    {
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand UpdateProduct { get; set; }
        public ICommand GetName { get; set; }
        private string TenSP1;
        public ICommand Loadwd { get; set; }
        public ICommand DeleteProduct { get; set; }
        private bool _SetQuanLy;
        public bool SetQuanLy { get => _SetQuanLy; set { _SetQuanLy = value; OnPropertyChanged(); } }
        public DetailProductViewModel()
        {
            Closewd = new RelayCommand<DetailProduct>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<DetailProduct>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<DetailProduct>((p) => true, (p) => moveWindow(p));
            GetName = new RelayCommand<DetailProduct>((p) => true, (p) => _GetName(p));
            UpdateProduct = new RelayCommand<DetailProduct>((p) => true, (p) => _UpdateProduct(p));
            Loadwd = new RelayCommand<DetailProduct>((p) => true, (p) => _Loadwd(p));
            DeleteProduct = new RelayCommand<DetailProduct>((p) => true, (p) => _DeleteProduct(p));

        }
        void _Loadwd(DetailProduct parmater)
        {
            if (Const.Admin)
            {
                parmater.TenSP.IsEnabled = true;
                parmater.Info.IsEnabled = true;

                parmater.btncapnhat.Visibility = Visibility.Visible;
                parmater.btnxoa.Visibility = Visibility.Visible;
                SetQuanLy = true;
            }
            else
            {
                parmater.TenSP.IsEnabled = false;
                parmater.Info.Height = 300;
                parmater.MASP.IsEnabled = false;
                parmater.GiaSP.IsEnabled = false;
                parmater.NSX.IsEnabled = false;
                parmater.HSD.IsEnabled = false;
                parmater.XUATXU.IsEnabled = false;
                parmater.KLG.IsEnabled = false;
                parmater.DVT.IsEnabled = false;
                parmater.MALSP.IsEnabled = false;
                parmater.MOTA.IsEnabled = false;
                parmater.MANCC.IsEnabled = false;

                parmater.btncapnhat.Visibility = Visibility.Collapsed;
                parmater.btnxoa.Visibility = Visibility.Collapsed;
                SetQuanLy = false;

            }
        }
        void _DeleteProduct(DetailProduct parameter)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa sản phẩm ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (SANPHAM a in DataProvider.Ins.DB.SANPHAMs.Where(pa => (pa.TENSP == TenSP1 && pa.SL >= 0)))
                {
                    a.SL = -1;
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa sản phẩm thành công !", "THÔNG BÁO");

                parameter.Close();
            }
        }
        void moveWindow(DetailProduct p)
        {
            p.DragMove();
        }
        void Close(DetailProduct p)
        {
            p.Close();

        }
        void Minimize(DetailProduct p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _GetName(DetailProduct p)
        {
            TenSP1 = p.TenSP.Text;
        }
        void _UpdateProduct(DetailProduct p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn cập nhật sản phẩm ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(p.TenSP.Text) || string.IsNullOrEmpty(p.MASP.Text) || string.IsNullOrEmpty(p.XUATXU.Text) || string.IsNullOrEmpty(p.MOTA.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO");
                }
                else
                {
                    foreach (SANPHAM a in DataProvider.Ins.DB.SANPHAMs.Where(pa => (pa.TENSP == TenSP1 && pa.SL >= 0)))
                    {
                        a.TENSP = p.TenSP.Text;
                        a.MOTA = p.MOTA.Text;
                        a.MASP = p.MASP.Text;
                        a.XUATXU = p.XUATXU.Text;
                        //a.SL = int.Parse(p.SLSP.Text);

                        string giaSPString = new string(p.GiaSP.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());
                        decimal giaSP = Convert.ToDecimal(giaSPString);
                        a.GIABAN = giaSP;

                        if (DateTime.TryParse(p.NSX.Text, out DateTime nsxDate))
                        {
                            a.NSX = nsxDate;
                        }
                        else
                        {
                            MessageBox.Show("Định dạng ngày NSX không hợp lệ. Vui lòng nhập một ngày hợp lệ.");
                        }

                        if (DateTime.TryParse(p.HSD.Text, out DateTime hsdDate))
                        {
                            a.HSD = hsdDate;
                        }
                        else
                        {
                            MessageBox.Show("Định dạng ngày HSD không hợp lệ. Vui lòng nhập một ngày hợp lệ.");
                        }


                        a.KLG = int.Parse(p.KLG.Text);
                        a.DVT = p.DVT.Text;
                        a.MALOAISP = p.MALSP.Text;
                        a.MANCC = p.MANCC.Text;
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật sản phẩm thành công !", "THÔNG BÁO", MessageBoxButton.OK);
                }
            }
        }
    }
}
