using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity.Validation;

namespace MilkStoreManagement.ViewModel
{
    public class AddCsView : BaseViewModel
    {
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand AddCsCommand { get; set; }
        public ICommand Loadwd { get; set; }
        public AddCsView()
        {
            Closewd = new RelayCommand<AddCustomerView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<AddCustomerView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<AddCustomerView>((p) => true, (p) => moveWindow(p));
            AddCsCommand = new RelayCommand<AddCustomerView>((p) => true, (p) => _AddCsCommand(p));
            Loadwd = new RelayCommand<AddCustomerView>((p) => true, (p) => _Loadwd(p));
        }

        void _Loadwd(AddCustomerView parmater)
        {
            parmater.DOANHSO.Text = 0.ToString();
            parmater.GHICHU.Text = "USUAL";
        }

        void moveWindow(AddCustomerView p)
        {
            p.DragMove();
        }
        void Close(AddCustomerView p)
        {
            p.Close();
        }
        void Minimize(AddCustomerView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        bool check(string m)
        {
            foreach (KHACHHANG temp in DataProvider.Ins.DB.KHACHHANGs)
            {
                if (temp.MAKH == m)
                    return true;
            }
            return false;
        }
        string rdma()
        {
            string ma;
            do
            {
                Random rand = new Random();
                ma = "KH" + rand.Next(0, 99).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddCsCommand(AddCustomerView paramater)
        {

            if (string.IsNullOrEmpty(paramater.TenKH.Text) || string.IsNullOrEmpty(paramater.SDT.Text) || string.IsNullOrEmpty(paramater.NGSINH.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn thêm khách hàng?", "THÔNG BÁO", MessageBoxButton.YesNoCancel);
            if (h == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(paramater.MAKH.Text) || string.IsNullOrEmpty(paramater.TenKH.Text) || string.IsNullOrEmpty(paramater.SDT.Text) || string.IsNullOrEmpty(paramater.NGSINH.Text))
                {
                    MessageBox.Show("Thông tin chưa đầy đủ!", "THÔNG BÁO");
                }
                else
                {
                    if (DataProvider.Ins.DB.KHACHHANGs.Any(p => p.MAKH == paramater.MAKH.Text))
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại!", "THÔNG BÁO");
                    }
                    else
                    {
                        KHACHHANG temp = new KHACHHANG();
                        temp.MAKH = paramater.MAKH.Text.ToString();
                        temp.TENKH = paramater.TenKH.Text.ToString();

                        DateTime ngaySinh;
                        if (DateTime.TryParse(paramater.NGSINH.Text, out ngaySinh))
                        {
                            temp.NGSINH = ngaySinh;
                        }
                        else
                        {
                            MessageBox.Show("Ngày sinh không hợp lệ!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        temp.SDT = paramater.SDT.Text.ToString();
                        temp.DOANHSO = 0;
                        temp.GHICHU = "USUAl";


                        DataProvider.Ins.DB.KHACHHANGs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thêm khách hàng thành công.", "THÔNG BÁO");

                        // Thực hiện các thao tác sau khi thêm khách hàng thành công
                        paramater.MAKH.Text = rdma();
                        paramater.TenKH.Clear();
                        paramater.SDT.Clear();
                        paramater.NGSINH.Clear();
                        paramater.DOANHSO.Text = "0";
                        paramater.GHICHU.Text = "USUAL";
                    }
                }
            }
        }

    }
}
