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
    public class AddStaffViewModel:BaseViewModel
    {
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }
        private string _Name;
       
        public ICommand AddNVCommand { get; set; }
        public ICommand AddImage { get; set; }
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand Loadwd { get; set; }
        public AddStaffViewModel()
        {
            Closewd = new RelayCommand<AddStaffView>((p) => true, (p) => _Close(p));
            MoveWindow = new RelayCommand<AddStaffView>((p) => true, (p) => moveWindow(p));
            AddNVCommand = new RelayCommand<AddStaffView>((p) => true, (p) => _AddND(p));
            AddImage = new RelayCommand<ImageBrush>((p) => true, (p) => _AddImage(p));
            Minimizewd = new RelayCommand<AddStaffView>((p) => true, (p) => _Minimize(p));
            Loadwd = new RelayCommand<AddStaffView>((p) => true, (p) => _Loadwd(p));
        }
        void _Loadwd(AddStaffView p)
        {
            Ava = Const._localLink + "/Resource/ImageNV/imageava.png";
            p.NnNv.Text = "0";
            p.PassNV.Text = "123";
            p.quanliNv.Text = "NV001";
        }
        void moveWindow(AddStaffView p)
        {
            p.DragMove();
        }
        
        void _Close(AddStaffView p)
        {
            p.Close();
        }

        void _Minimize(AddStaffView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _AddImage(ImageBrush img)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                Ava = open.FileName; 
                img.ImageSource = new BitmapImage(new Uri(Ava));
            }
            
        }
        bool check(string m)
        {
            foreach (NHANVIEN temp in DataProvider.Ins.DB.NHANVIENs)
            {
                if (temp.MANV == m)
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
                ma = "NV" + rand.Next(0, 99).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddND(AddStaffView addNVView)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn thêm nhân viên ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                if (String.IsNullOrEmpty(addNVView.MaNv.Text) || String.IsNullOrEmpty(addNVView.TenNv.Text) || String.IsNullOrEmpty(addNVView.sdtNv.Text) || String.IsNullOrEmpty(addNVView.GioitinhNv.Text) || String.IsNullOrEmpty(addNVView.ChucvuNv.Text) || addNVView.NgaysinhNv.SelectedDate == null)
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin !", "THÔNG BÁO");
                    return;
                }
                NHANVIEN temp = new NHANVIEN();
                foreach (NHANVIEN a in DataProvider.Ins.DB.NHANVIENs)
                {
                    if (addNVView.MaNv.Text == a.MANV)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại !", "THÔNG BÁO");
                        return;
                    }
                }
                foreach (NHANVIEN temp5 in DataProvider.Ins.DB.NHANVIENs)
                {
                    if (temp5.EMAIL == addNVView.EmailNv.Text)
                    {
                        MessageBox.Show("Email này đã được sử dụng !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                Regex reg = new Regex(match);
                if (!reg.IsMatch(addNVView.EmailNv.Text))
                {
                    MessageBox.Show("Email không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string match1 = @"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$";
                Regex reg1 = new Regex(match1);
                if (!reg1.IsMatch(addNVView.sdtNv.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                temp.MANV = addNVView.MaNv.Text;
                temp.TENNV = addNVView.TenNv.Text;
                temp.SDT = addNVView.sdtNv.Text;
                temp.DIACHI = addNVView.diachiNv.Text;
                temp.GIOI = addNVView.GioitinhNv.Text;
                temp.EMAIL = addNVView.EmailNv.Text;
                temp.NGSINH = (DateTime)addNVView.NgaysinhNv.SelectedDate;
                temp.CHUCVU = addNVView.ChucvuNv.Text;
                temp.ID_QLY = addNVView.quanliNv.Text;
                temp.PASS = addNVView.PassNV.Text;
                temp.NGAYNGHIVIEC = null;
                temp.NGAYNGHI = int.TryParse(addNVView.NnNv.Text, out int ngayNghiInt) ? ngayNghiInt : 0;
                temp.LUONG = (decimal)Convert.ToDouble(addNVView.luongNV.Text);
                temp.NGVL = (DateTime)addNVView.NgayvlNv.SelectedDate;
                string rd = StringGenerator();
                if (Ava == "/Resource/ImageNV/imageava.png")
                    temp.AVA = "/Resource/ImageNV/imageava.png";
                else
                    temp.AVA = @"Resource\Ava\" + rd + ((Ava.Contains(".jpg")) ? ".jpg" : ".png").ToString();
                DataProvider.Ins.DB.NHANVIENs.Add(temp);
                try
                {
                    File.Copy(Ava, Const._localLink + @"Resource\Ava\" +rd + ((Ava.Contains(".jpg")) ? ".jpg" : ".png").ToString(), true);
                }
                catch { }
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Thêm nhân viên thành công !", "THÔNG BÁO");
                addNVView.TenNv.Clear();
                addNVView.GioitinhNv.SelectedItem = null;
                addNVView.GioitinhNv.Items.Refresh();
                addNVView.ChucvuNv.SelectedItem = null;
                addNVView.ChucvuNv.Items.Refresh();
                addNVView.NgaysinhNv.SelectedDate = null;
                addNVView.sdtNv.Clear();
                addNVView.diachiNv.Clear();
                addNVView.EmailNv.Clear();
                addNVView.luongNV.Clear();
                addNVView.NgayvlNv.SelectedDate = null;
                addNVView.quanliNv.Clear();
                Ava = Const._localLink + "/Resource/ImageNV/imageava.png";
                Uri fileUri = new Uri(Ava, UriKind.Relative);
                addNVView.HinhAnh1.ImageSource = new BitmapImage(fileUri);
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
    }
}
