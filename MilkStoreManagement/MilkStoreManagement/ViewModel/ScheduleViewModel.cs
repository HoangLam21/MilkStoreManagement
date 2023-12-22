using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using MilkStoreManagement.Model;
using MilkStoreManagement.View;

namespace MilkStoreManagement.ViewModel
{
    public class ScheduleViewModel : BaseViewModel
    {
        private ObservableCollection<LICHLAMVIEC> _listLLV;
        public ObservableCollection<LICHLAMVIEC> listLLV { get => _listLLV; set { _listLLV = value; OnPropertyChanged(); } }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public string[] dayLabels = { "Chủ nhật", "Hai", "Ba", "Tư", "Năm", "Sáu", "Bảy" };
        public ICommand SearchCommand { get; set; }
        public ICommand LoadSchewd { get; set; }
        public ICommand LoadLLV { get; set; }
        public ICommand Update { get; set; }
        public ICommand Print { get; set; }
        public ScheduleViewModel()
        {
            listLLV = new ObservableCollection<LICHLAMVIEC>();
            listTK = new ObservableCollection<string>();
            LoadSchewd = new RelayCommand<ScheduleView>((p) => true, (p) => _LoadSchewd(p));
            LoadLLV = new RelayCommand<ScheduleView>((p) => true, (p) => _LoadLLV(p));
            SearchCommand = new RelayCommand<ScheduleView>((p) => true, (p) => _SearchCommand(p));
            Print = new RelayCommand<ScheduleView>((p) => true, (p) => _Print(p));
            Update = new RelayCommand<ScheduleView>((p) => { return p == null ? false : true; }, (p) => _Update(p));
        }
        void _LoadSchewd(ScheduleView p)
        {
            if (Const.Admin)
            {
                p.btnUpdate.Visibility = Visibility.Visible;
                listTK = new ObservableCollection<string>() { "Thứ", "Ca", "Mã NV" };
            }
            else
            {
                listTK = new ObservableCollection<string>() { "Thứ", "Ca" };
            }
        }
        void _SearchCommand(ScheduleView p)
        {
            ObservableCollection<object> temp = new ObservableCollection<object>();
            var query = (from llv in DataProvider.Ins.DB.LICHLAMVIECs
                         join nv in DataProvider.Ins.DB.NHANVIENs on llv.MANV equals nv.MANV
                         orderby llv.THU, llv.CA ascending
                         select new
                         {
                             THU = llv.THU,
                             CA = llv.CA,
                             MANV = llv.MANV,
                             TENNV = nv.TENNV
                         });
            if (!Const.Admin)
            {
                query = query.Where(e => e.MANV == Const.TenDangNhap);
            }
            if (p.txbSearch.Text != "")
            {
                switch (p.cbxChon.SelectedItem.ToString())
                {
                    case "Thứ":
                        {
                            var schedules = query.ToList().Where(e => dayLabels[e.THU - 1].ToLower().Contains(p.txbSearch.Text.ToLower())).ToList();
                            temp = new ObservableCollection<object>(schedules.Select(e => new {
                                THU = dayLabels[e.THU - 1],
                                CA = e.CA,
                                MANV = e.MANV,
                                TENNV = e.TENNV
                            }));
                            p.ListViewLLV.ItemsSource = temp;
                            break;
                        }
                    case "Ca":
                        {
                            var schedules = query.Where(e => e.CA.ToString().Contains(p.txbSearch.Text)).ToList();
                            temp = new ObservableCollection<object>(schedules.Select(e => new {
                                THU = dayLabels[e.THU - 1],
                                CA = e.CA,
                                MANV = e.MANV,
                                TENNV = e.TENNV
                            }));
                            p.ListViewLLV.ItemsSource = temp;
                            break;
                        }
                    case "Mã NV":
                        {
                            var schedules = query.Where(e => e.MANV.ToLower().Contains(p.txbSearch.Text.ToLower())).ToList();
                            temp = new ObservableCollection<object>(schedules.Select(e => new {
                                THU = dayLabels[e.THU - 1],
                                CA = e.CA,
                                MANV = e.MANV,
                                TENNV = e.TENNV
                            }));
                            p.ListViewLLV.ItemsSource = temp;
                            break;
                        }
                    default:
                        {
                            var schedules = query.Where(e => e.TENNV.ToLower().Contains(p.txbSearch.Text.ToLower())).ToList();
                            temp = new ObservableCollection<object>(schedules.Select(e => new {
                                THU = dayLabels[e.THU - 1],
                                CA = e.CA,
                                MANV = e.MANV,
                                TENNV = e.TENNV
                            }));
                            p.ListViewLLV.ItemsSource = temp;
                            break;
                        }
                }
            }
            else
            {
                var schedules = query.ToList();
                var listLLV = new ObservableCollection<object>(schedules.Select(e => new
                {
                    THU = dayLabels[e.THU - 1],
                    CA = e.CA,
                    MANV = e.MANV,
                    TENNV = e.TENNV
                }));
                p.ListViewLLV.ItemsSource = listLLV;
            }
        }
        void _LoadLLV(ScheduleView p)
        {
            var query = (from llv in DataProvider.Ins.DB.LICHLAMVIECs
                         join nv in DataProvider.Ins.DB.NHANVIENs on llv.MANV equals nv.MANV
                         orderby llv.THU, llv.CA ascending
                         select new
                         {
                             THU = llv.THU,
                             CA = llv.CA,
                             MANV = llv.MANV,
                             TENNV = nv.TENNV
                         });
            if (!Const.Admin)
            {
                query = query.Where(e => e.MANV == Const.TenDangNhap);
            }
            var schedules = query.ToList();
            var listLLV = new ObservableCollection<object>(schedules.Select(e => new
            {
                THU = dayLabels[e.THU - 1],
                CA = e.CA,
                MANV = e.MANV,
                TENNV = e.TENNV
            }));
            p.ListViewLLV.ItemsSource = listLLV;
        }
        void _Update(ScheduleView p)
        {
            SplitSchedule splitSchedule = new SplitSchedule();
            splitSchedule.ShowDialog();

            _SearchCommand(p);
        }
        void _Print(ScheduleView p)
        {
            PrintScheduleView printSchedule = new PrintScheduleView();
            printSchedule.DateNow.Text = DateTime.Now.ToShortDateString();
            printSchedule.NameStaff.Text = DataProvider.Ins.DB.NHANVIENs.Where(x => x.MANV == Const.TenDangNhap).FirstOrDefault().TENNV;
            var query = (from llv in DataProvider.Ins.DB.LICHLAMVIECs
                         join nv in DataProvider.Ins.DB.NHANVIENs on llv.MANV equals nv.MANV
                         orderby llv.THU, llv.CA ascending
                         select new
                         {
                             THU = llv.THU,
                             CA = llv.CA,
                             MANV = llv.MANV,
                             TENNV = nv.TENNV
                         });
            query = query.Where(e => e.MANV == Const.TenDangNhap);
            var schedules = query.ToList();
            var listLLV = new ObservableCollection<object>(schedules.Select(e => new
            {
                THU = dayLabels[e.THU - 1],
                CA = e.CA,
                MANV = e.MANV,
                TENNV = e.TENNV
            }));
            printSchedule.ListViewLLV.ItemsSource = listLLV;
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog().GetValueOrDefault(false))
            {
                printDialog.PrintVisual(printSchedule.PrintSche, "LỊCH LÀM VIỆC");
                MessageBox.Show("In lịch làm việc thành công !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
