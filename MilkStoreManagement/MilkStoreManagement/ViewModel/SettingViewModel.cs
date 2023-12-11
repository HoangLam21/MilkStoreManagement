using Microsoft.Win32;
using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.IO;

namespace MilkStoreManagement.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _DoB;
        public string DoB { get => _DoB; set { _DoB = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private int _Gioi;
        public int Gioi { get => _Gioi; set { _Gioi = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
        private string _TenTK;
        public string TenTK { get => _TenTK; set { _TenTK = value; OnPropertyChanged(); } }
        private NHANVIEN _User;
        public NHANVIEN User { get => _User; set { _User = value; OnPropertyChanged(); } }
        public ICommand Loadwd { get; set; }
        public ICommand UpdateInfo { get; set; }
        public ICommand AddImage { get; set; }
        public ICommand ChangePass { get; set; }
        public SettingViewModel()
        {
            Loadwd = new RelayCommand<SettingView>((p) => true, (p) => _Loadwd(p));
            AddImage = new RelayCommand<ImageBrush>((p) => true, (p) => _AddImage(p));
            UpdateInfo = new RelayCommand<SettingView>((p) => true, (p) => _UdpateInfo(p));
            ChangePass = new RelayCommand<SettingView>((p) => true, (p) => _ChangePass());
        }
        void _ChangePass()
        {
            ChangePassword changePass = new ChangePassword();
            changePass.ShowDialog();
        }
        void _Loadwd(SettingView p)
        {
            if (LoginViewModel.IsLogin)
            {
                string a = Const.TenDangNhap;
                User = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == a).FirstOrDefault();
                Ava = User.AVA;
                Name = User.TENNV;
                DoB = User.NGSINH.ToString();
                DiaChi = User.DIACHI;
                Gioi = (User.GIOI == "NAM") ? 0 : 1;
                SDT = User.SDT;
                TenTK = User.MANV;
                Email = User.EMAIL;
            }
        }
        void _AddImage(ImageBrush p)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                Ava = open.FileName;
            }
            p.ImageSource = new BitmapImage(new Uri(Ava));
        }
        void _UdpateInfo(SettingView p)
        {
            foreach (NHANVIEN temp1 in DataProvider.Ins.DB.NHANVIENs)
            {
                if (temp1.EMAIL == p.MailBox.Text && p.MailBox.Text != Const.NV.EMAIL)
                {
                    MessageBox.Show("Email này đã được đăng ký !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex regex = new Regex(match);
            if (!regex.IsMatch(p.MailBox.Text))
            {
                MessageBox.Show("Email không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var temp = DataProvider.Ins.DB.NHANVIENs.Where(pa => pa.MANV == TenTK).FirstOrDefault();
            temp.TENNV = p.NameBox.Text;
            temp.SDT = p.SDTBox.Text;
            temp.DIACHI = p.AddressBox.Text;
            temp.GIOI = p.GTBox.Text;
            temp.NGSINH = (DateTime)p.DateBox.SelectedDate;
            temp.EMAIL = p.MailBox.Text;
            string rd = GenerateRandomString();
            if (User.AVA != Ava)
                temp.AVA = @"Resource\Ava\" + temp.MANV + (Ava.Contains(".jpg") ? ".jpg" : ".png").ToString();
            DataProvider.Ins.DB.SaveChanges();
            try
            {
                if (User.AVA != Ava)
                    File.Copy(Ava, Const._localLink + @"Resource\Ava\" + temp.MANV + (Ava.Contains(".jpg") ? ".jpg" : ".png").ToString(), true);
            }
            catch { }
            MessageBox.Show("Cập nhật thành công!", "Thông báo");
        }
        static string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = random.Next(5, 24);
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }
    }
}
