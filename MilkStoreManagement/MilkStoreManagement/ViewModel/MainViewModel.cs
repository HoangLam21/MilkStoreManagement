using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace MilkStoreManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand CloseLogin { get; set; }
        public ICommand MinimizeLogin { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand TenDangNhap_Loaded { get; set; }
        public ICommand Quyen_Loaded { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand GetIdTab { get; set; }
        public ICommand SwitchTab { get; set; }
        private NHANVIEN _User;
        public NHANVIEN User { get => _User; set { _User = value; OnPropertyChanged(); } }
        private Visibility _SetQuanLy;
        public Visibility SetQuanLy { get => _SetQuanLy; set { _SetQuanLy = value; OnPropertyChanged(); } }
        public string Name;
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }

        public ICommand Loadwd { get; set; }
        public MainViewModel()
        {
            Loadwd = new RelayCommand<MainWindow>((p) => true, (p) => _Loadwd(p));
            CloseLogin = new RelayCommand<MainWindow>((p) => true, (p) => Close());
            MinimizeLogin = new RelayCommand<MainWindow>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<MainWindow>((p) => true, (p) => moveWindow(p));
            GetIdTab = new RelayCommand<RadioButton>((p) => true, (p) => Name = p.Uid);
            SwitchTab = new RelayCommand<MainWindow>((p) => true, (p) => switchtab(p));
            TenDangNhap_Loaded = new RelayCommand<MainWindow>((p) => true, (p) => LoadTenND(p));
            Quyen_Loaded = new RelayCommand<MainWindow>((p) => true, (p) => LoadQuyen(p));
            LogOutCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) => LogOut(p));
        }
        public void Close()
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void Minimize(MainWindow p)
        {
            p.WindowState = WindowState.Minimized;
        }
        public void moveWindow(MainWindow p)
        {
            p.DragMove();
        }
        void _Loadwd(MainWindow p)
        {
            if (LoginViewModel.IsLogin)
            {
                string a = Const.TenDangNhap;
                User = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == a).FirstOrDefault();
                Const.NV = User;
                SetQuanLy = User.CHUCVU == "Quản lý" ? Visibility.Visible : Visibility.Collapsed;
                Const.Admin = User.CHUCVU == "Quản lý";
                Ava = User.AVA;
                LoadTenND(p);
            }
        }
        void LogOut(MainWindow p)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            p.Close();
        }
        public void LoadTenND(MainWindow p)
        {
            p.TenDangNhap.Text = string.Join(" ", User.TENNV.Split().Reverse().Take(2).Reverse());
        }
        public void LoadQuyen(MainWindow p)
        {
            p.Quyen.Text = User.CHUCVU == "Quản lý" ? "Quản lý" : "Nhân viên";
        }
        void switchtab(MainWindow p)
        {
            int index = int.Parse(Name);
            switch (index)
            {
                case 0:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new HomeView());
                        break;
                    }
                case 1:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new ProductsView());
                        break;
                    }
                case 2:
                    {
                        _Loadwd(p);
                        //p.Main.NavigationService.Navigate(new );
                        break;
                    }
                case 3:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new OrderView());
                        break;
                    }
                case 4:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new ScheduleView());
                        break;
                    }
                case 5:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new ImportView());
                        break;
                    }
                case 6:
                    {
                        _Loadwd(p);
                        //p.Main.NavigationService.Navigate(new );
                        break;
                    }
                case 7:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new StaffView());
                        break;
                    }
                case 8:
                    {
                        _Loadwd(p);
                        p.Main.NavigationService.Navigate(new SettingView());
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
