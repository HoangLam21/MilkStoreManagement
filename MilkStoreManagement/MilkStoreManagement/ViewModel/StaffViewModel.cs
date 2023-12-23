using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MilkStoreManagement.ViewModel
{
    public class StaffViewModel : BaseViewModel
    {
        private readonly string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
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

        private ObservableCollection<NHANVIEN> _listNV;
        private ObservableCollection<NHANVIEN> _listNV1;
        public ObservableCollection<NHANVIEN> ListNV { get => _listNV; set { _listNV = value; OnPropertyChanged(); } }
        public ObservableCollection<NHANVIEN> ListNV1 { get => _listNV1; set { _listNV1 = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand UpdateNVCommand { get; set; }
        public ICommand DeleteNVCommand { get; set; }
        public ICommand AddNVCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }
        public ICommand Closewd { get; set; }
        private string TenSP1;
        public ICommand Minimizewd { get; set; }
        public ICommand UpdateNhanVien { get; set; }
        public ICommand MoveWindow { get; set; }

        public ICommand FirstCommand { get; set; }
        public ICommand Previouscommand { get; set; }

        public ICommand NextCommand { get; set; }

        public ICommand LastCommand { get; set; }
        public int SoDH { get; set; }
        public int SoSPDB { get; set; }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public StaffViewModel()
        {
            listTK = new ObservableCollection<string>() { "Mã nhân viên", "Tên nhân viên", "Tất cả" };
            ListNV = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            ListNV1 = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(p => p.NGAYNGHIVIEC == null));
            SearchCommand = new RelayCommand<StaffView>((p) => true, (p) => _SearchCommand(p));
            Detail = new RelayCommand<StaffView>((p) => { return p.DatagridNV.SelectedItem == null ? false : true; }, (p) => _DetailNV(p));
            AddNVCommand = new RelayCommand<StaffView>((p) => true, (p) => _AddNV(p));
            LoadCsCommand = new RelayCommand<StaffView>((p) => true, (p) => _LoadCsCommand(p));
            Closewd = new RelayCommand<DetailStaffView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<DetailStaffView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<DetailStaffView>((p) => true, (p) => moveWindow(p));
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
        void _LoadCsCommand(StaffView parameter)
        {
            parameter.cbxChon.SelectedIndex = 2;

        }
        void _SearchCommand(StaffView paramater)
        {
            ObservableCollection<NHANVIEN> temp = new ObservableCollection<NHANVIEN>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã nhân viên":
                        {
                            try
                            {
                                foreach (NHANVIEN s in ListNV1)
                                {
                                    if (s.MANV == (paramater.txbSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }

                            }
                            catch { }
                            break;
                        }
                    case "Tên nhân viên":
                        {
                            foreach (NHANVIEN s in ListNV1)
                            {
                                if (s.TENNV.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }

                    default:
                        {
                            foreach (NHANVIEN s in ListNV1)
                            {
                                if (s.TENNV.ToLower().Contains(paramater.txbSearch.Text.ToLower()) || s.MANV == (paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.DatagridNV.ItemsSource = temp;
            }
            else
                paramater.DatagridNV.ItemsSource = ListNV1;
        }

        private int GetTotalOrdersForEmployee(string employeeId)
        {
            var query = (from hd in DataProvider.Ins.DB.HOADONs
                         where hd.MANV == employeeId
                         select hd).Count();

            return query;
        }

        private int GetTotalProductsSoldForEmployee(string employeeId)
        {
            var query = (from nv in DataProvider.Ins.DB.NHANVIENs
                         join hd in DataProvider.Ins.DB.HOADONs on nv.MANV equals hd.MANV
                         join ct in DataProvider.Ins.DB.CTHDs on hd.SOHD equals ct.SOHD
                         where nv.MANV == employeeId
                         select ct).Count();

            return query;
        }
        void _GetName(DetailStaffView p)
        {
            TenSP1 = p.MailNV.Text;
        }


        void _DetailNV(StaffView paramater)
        {
            DetailStaffView detailNVView = new DetailStaffView();
            DetailStaffViewModel detailViewModel = new DetailStaffViewModel();
            NHANVIEN temp = (NHANVIEN)paramater.DatagridNV.SelectedItem;
            detailNVView.MaNV.Text = temp.MANV;
            detailNVView.TenNV.Text = temp.TENNV;
            detailNVView.MailNV.Text = temp.EMAIL;
            detailNVView.GtNV.Text = temp.GIOI;
            detailNVView.NsNV.Text = temp.NGSINH.ToString();
            detailNVView.SdtNV.Text = temp.SDT;
            detailNVView.DcNV.Text = temp.DIACHI;
            detailNVView.CvNV.Text = temp.CHUCVU;
            detailNVView.NvlNV.Text = temp.NGVL.ToString();
            detailNVView.LuongNV.Text = temp.LUONG.ToString();
            detailNVView.QlcnNV.Text = temp.ID_QLY;
            detailNVView.NnNV.Text = temp.NGAYNGHI.ToString();
            detailNVView.SoDH.Text = GetTotalOrdersForEmployee(temp.MANV).ToString();
            detailNVView.SoSP.Text = GetTotalProductsSoldForEmployee(temp.MANV).ToString();
            linkimage = temp.AVA;
            Uri fileUri = new Uri(linkimage);
            detailNVView.Ava.ImageSource = new BitmapImage(fileUri);
            detailNVView.ShowDialog();
            ListNV1 = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(p => p.NGAYNGHIVIEC == null));
            paramater.DatagridNV.ItemsSource = ListNV1;
            paramater.DatagridNV.SelectedItem = null;

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
        void _AddNV(StaffView parameter)
        {
            AddStaffView addNVView = new AddStaffView();
            addNVView.MaNv.Text = rdma();
            addNVView.Show();
            addNVView.NnNv.Text = "0";
            addNVView.PassNV.Text = "123";
            addNVView.quanliNv.Text = "NV1";
            linkimage = Const._localLink + "/Resource/ImageNV/imageava.png";
            Uri fileUri = new Uri(linkimage);
            addNVView.HinhAnh1.ImageSource = new BitmapImage(fileUri);
            ListNV1 = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs.Where(p => p.NGAYNGHIVIEC == null));
            parameter.DatagridNV.ItemsSource = ListNV1;
            parameter.DatagridNV.SelectedItem = null;
        }
    }
}
