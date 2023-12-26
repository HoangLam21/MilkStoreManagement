using Microsoft.Win32;
using MilkStoreManagement.Model;
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

using MilkStoreManagement.View;

namespace MilkStoreManagement.ViewModel
{
    public class UpdateStaffViewModel : BaseViewModel
    {
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }

        public ICommand AddNVCommand { get; set; }
        public ICommand UpdateImage { get; set; }
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand GetName { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand UpdateNV { get; set; }

        private string MaNV1;
        public UpdateStaffViewModel()
        {
            UpdateImage = new RelayCommand<ImageBrush>((p) => true, (p) => _UpdateImage(p));
            Closewd = new RelayCommand<UpdateStaffView>((p) => true, (p) => Close(p));
            GetName = new RelayCommand<UpdateStaffView>((p) => true, (p) => _GetName(p));
            Minimizewd = new RelayCommand<UpdateStaffView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<UpdateStaffView>((p) => true, (p) => moveWindow(p));
            UpdateNV = new RelayCommand<UpdateStaffView>((p) => true, (p) => _UpdateNV(p));
            Loadwd = new RelayCommand<UpdateStaffView>((p) => true, (p) => _Loadwd(p));
        }
        void _UpdateImage(ImageBrush p)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                Ava = open.FileName;
                p.ImageSource = new BitmapImage(new Uri(Ava));
            }
           
        }

        void _GetName(UpdateStaffView p)
        {
            MaNV1 = p.MaNv.Text;
        }
        void _UpdateNV(UpdateStaffView NV)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn cập nhật thông tin nhân viên ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (String.IsNullOrEmpty(NV.MaNv.Text) || String.IsNullOrEmpty(NV.TenNv.Text) || String.IsNullOrEmpty(NV.sdtNv.Text) || String.IsNullOrEmpty(NV.GioitinhNv.Text) || String.IsNullOrEmpty(NV.ChucvuNv.Text) || NV.NgaysinhNv.SelectedDate == null)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin !", "THÔNG BÁO");
                    return;
                }
                NHANVIEN temp = DataProvider.Ins.DB.NHANVIENs.Where(pa => pa.MANV == NV.MaNv.Text).FirstOrDefault();
                foreach (NHANVIEN temp5 in DataProvider.Ins.DB.NHANVIENs)
                {
                    if (temp5.EMAIL == NV.EmailNv.Text && temp5.MANV != temp.MANV)
                    {
                        MessageBox.Show("Email này đã được sử dụng !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Regex reg = new Regex(match);
                if (!reg.IsMatch(NV.EmailNv.Text))
                {
                    MessageBox.Show("Email không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string match1 = @"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$";
                Regex reg1 = new Regex(match1);
                if (!reg1.IsMatch(NV.sdtNv.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                temp.MANV = NV.MaNv.Text;
                temp.TENNV = NV.TenNv.Text;
                temp.SDT = NV.sdtNv.Text;
                temp.DIACHI = NV.diachiNv.Text;
                temp.GIOI = NV.GioitinhNv.Text;
                temp.EMAIL = NV.EmailNv.Text;
                temp.NGSINH = (DateTime)NV.NgaysinhNv.SelectedDate;
                temp.CHUCVU = NV.ChucvuNv.Text;
                temp.ID_QLY = NV.quanliNv.Text;
                temp.NGAYNGHIVIEC = null;
                temp.NGAYNGHI = int.TryParse(NV.NnNv.Text, out int ngayNghiInt) ? ngayNghiInt : 0;
                temp.LUONG = (decimal)Convert.ToDouble(NV.luongNV.Text);
                temp.NGVL = (DateTime)NV.NgayvlNv.SelectedDate;
                string rd = StringGenerator();
                if (Ava != null)
                {
                    if (temp.AVA != Ava)
                        temp.AVA = @"Resource\Ava\" + rd + (Ava.Contains(".jpg") ? ".jpg" : ".png").ToString();

                    DataProvider.Ins.DB.SaveChanges();
                    try
                    {
                        if (temp.AVA != Ava)
                            File.Copy(Ava, Const._localLink + @"Resource\Ava\" + rd + (Ava.Contains(".jpg") ? ".jpg" : ".png").ToString(), true);
                    }
                    catch { }
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBoxResult a = System.Windows.MessageBox.Show("Cập nhật nhân viên thành công !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.None);
                if(a==MessageBoxResult.OK)
                {
                    NV.Close();
                }    

            }
        }
        static string StringGenerator()
        {
            Random rd = new Random();
            int length = rd.Next(5, 20);
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
        void _Loadwd(UpdateStaffView parmater)
        {
            parmater.TenNv.IsEnabled = true;
            parmater.MaNv.IsEnabled = false;
            parmater.EmailNv.IsEnabled = true;
            parmater.GioitinhNv.IsEnabled = true;
            parmater.sdtNv.IsEnabled = true;
            parmater.ChucvuNv.IsEnabled = true;
            parmater.NgaysinhNv.IsEnabled = true;
            parmater.NgayvlNv.IsEnabled = true;
            parmater.luongNV.IsEnabled = true;
            parmater.quanliNv.IsEnabled = true;
            parmater.NnNv.IsEnabled = true;
        }

        void moveWindow(UpdateStaffView p)
        {
            p.DragMove();
        }
        void Close(UpdateStaffView p)
        {
            p.Close();

        }
        void Minimize(UpdateStaffView p)
        {
            p.WindowState = WindowState.Minimized;
        }
    }
}
