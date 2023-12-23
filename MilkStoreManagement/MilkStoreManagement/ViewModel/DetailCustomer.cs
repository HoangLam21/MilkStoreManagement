using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MilkStoreManagement.ViewModel
{
    public class DetailCustomer : BaseViewModel
    {
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        private string MaKH;
        public ICommand GetMAKH { get; set; }
        public ICommand Update { get; set; }
        public DetailCustomer()
        {
            Closewd = new RelayCommand<DetailCustomerView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<DetailCustomerView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<DetailCustomerView>((p) => true, (p) => moveWindow(p));
            GetMAKH = new RelayCommand<DetailCustomerView>((p) => true, (p) => _GetMAKH(p));
            Update = new RelayCommand<DetailCustomerView>((p) => true, (p) => _Update(p));
        }
        void moveWindow(DetailCustomerView p)
        {
            p.DragMove();
        }
        void Close(DetailCustomerView p)
        {
            p.Close();
        }
        void Minimize(DetailCustomerView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _GetMAKH(DetailCustomerView paramater)
        {
            MaKH = paramater.MAKH.Text;
        }
        void _Update(DetailCustomerView p)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn cập nhật thông tin ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(p.TenKH.Text) || string.IsNullOrEmpty(p.SDT.Text) || string.IsNullOrEmpty(p.NGSINH.Text) || string.IsNullOrEmpty(p.DOANHSO.Text) || string.IsNullOrEmpty(p.GHICHU.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var temp = DataProvider.Ins.DB.KHACHHANGs.Where(pa => pa.MAKH == MaKH);
                    foreach (KHACHHANG a in temp)
                    {
                        a.TENKH = p.TenKH.Text;
                        a.NGSINH = DateTime.Parse(p.NGSINH.Text);
                        a.SDT = p.SDT.Text.ToString();
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin thành công !", "THÔNG BÁO");
                }
            }
        }
    }
}
