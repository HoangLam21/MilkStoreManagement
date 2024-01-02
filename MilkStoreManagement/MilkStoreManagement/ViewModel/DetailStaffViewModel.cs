using MilkStoreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MilkStoreManagement.View;
using System.Windows.Media.Imaging;

namespace MilkStoreManagement.ViewModel
{
    public class DetailStaffViewModel : BaseViewModel
    {
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }

        private string _linkimage;
        public string linkimage
        {
            get { return _linkimage; }
            set
            {
                if (_linkimage != value)
                {
                    _linkimage = value;
                    OnPropertyChanged(nameof(linkimage));
                }
            }
        }

        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand UpdateNhanVien { get; set; }
        public ICommand GetName { get; set; }
        private string TenSP1;
        private string _ava;
        public string AVA
        {
            get { return _ava; }
            set
            {
                _ava = value;
                OnPropertyChanged(nameof(AVA));
            }
        }

        public ICommand Loadwd { get; set; }
        public ICommand DeleteNhanVien { get; set; }
        public DetailStaffViewModel()
        {
            Closewd = new RelayCommand<DetailStaffView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<DetailStaffView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<DetailStaffView>((p) => true, (p) => moveWindow(p));
            GetName = new RelayCommand<DetailStaffView>((p) => true, (p) => _GetName(p));
            UpdateNhanVien = new RelayCommand<DetailStaffView>((p) => true, (p) => _UpdateNhanVien(p));
            Loadwd = new RelayCommand<DetailStaffView>((p) => true, (p) => _Loadwd(p));
            DeleteNhanVien = new RelayCommand<DetailStaffView>((p) => true, (p) => _DeleteNhanVien(p));
        }
        void _Loadwd(DetailStaffView parmater)
        {
            parmater.TenNV.IsEnabled = false;
            parmater.MaNV.IsEnabled = false;
            parmater.GtNV.IsEnabled = false;
            parmater.MailNV.IsEnabled = false;
            parmater.SdtNV.IsEnabled = false;
            parmater.CvNV.IsEnabled = false;
            parmater.NsNV.IsEnabled = false;
            parmater.NvlNV.IsEnabled = false;
            parmater.LuongNV.IsEnabled = false;
            parmater.QlcnNV.IsEnabled = false;
            parmater.NnNV.IsEnabled = false;
        }

        void moveWindow(DetailStaffView p)
        {
            p.DragMove();
        }
        void Close(DetailStaffView p)
        {
            p.Close();

        }
        void Minimize(DetailStaffView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _GetName(DetailStaffView p)
        {
            TenSP1 = p.MailNV.Text;
        }
        void _UpdateNhanVien(DetailStaffView paramater)
        {
            NHANVIEN selectedNhanVien = DataProvider.Ins.DB.NHANVIENs.SingleOrDefault(nv => nv.EMAIL == TenSP1);

            if (selectedNhanVien != null)
            {
                UpdateStaffView updateNV = new UpdateStaffView();
                updateNV.MaNv.Text = selectedNhanVien.MANV;
                updateNV.TenNv.Text = selectedNhanVien.TENNV;
                updateNV.EmailNv.Text = selectedNhanVien.EMAIL;
                if (selectedNhanVien.GIOI.Trim() == "Nữ")
                {
                    updateNV.GioitinhNv.SelectedIndex = 0;
                }
                else
                {
                    updateNV.GioitinhNv.SelectedIndex = 1;
                }
                updateNV.NgaysinhNv.Text = selectedNhanVien.NGSINH.ToString();
                updateNV.sdtNv.Text = selectedNhanVien.SDT;
                updateNV.diachiNv.Text = selectedNhanVien.DIACHI;
                updateNV.ChucvuNv.Text = selectedNhanVien.CHUCVU;
                updateNV.NgayvlNv.Text = selectedNhanVien.NGVL.ToString();
                updateNV.luongNV.Text = selectedNhanVien.LUONG.ToString();
                updateNV.quanliNv.Text = selectedNhanVien.ID_QLY;
                updateNV.NnNv.Text = selectedNhanVien.NGAYNGHI.ToString();

                Ava = selectedNhanVien.AVA;
                Uri fileUri = new Uri(Ava);
                updateNV.Img.ImageSource = new BitmapImage(fileUri);
                updateNV.ShowDialog();
                paramater.MaNV.Text = selectedNhanVien.MANV;
                paramater.TenNV.Text = selectedNhanVien.TENNV;
                paramater.MailNV.Text = selectedNhanVien.EMAIL;
                paramater.GtNV.Text = selectedNhanVien.GIOI;
                paramater.NsNV.Text = selectedNhanVien.NGSINH.ToString();
                paramater.SdtNV.Text = selectedNhanVien.SDT;
                paramater.DcNV.Text = selectedNhanVien.DIACHI;
                linkimage = selectedNhanVien.AVA;
                Uri fileuri = new Uri(linkimage);
                paramater.Ava.ImageSource = new BitmapImage(fileuri);
                paramater.CvNV.Text = selectedNhanVien.CHUCVU;
                paramater.NvlNV.Text = selectedNhanVien.NGVL.ToString();
                paramater.LuongNV.Text = selectedNhanVien.LUONG.ToString();
                paramater.QlcnNV.Text = selectedNhanVien.ID_QLY;
                paramater.Activate();
            }
        }
        void _DeleteNhanVien(DetailStaffView paramater)
        {
            MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn xóa nhân viên ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                foreach (NHANVIEN a in DataProvider.Ins.DB.NHANVIENs.Where(pa => (pa.EMAIL == TenSP1 && pa.NGAYNGHIVIEC == null)))
                {
                    a.NGAYNGHIVIEC = DateTime.Now;
                }
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa nhân viên thành công !", "THÔNG BÁO");
            }
        }
    }
}
