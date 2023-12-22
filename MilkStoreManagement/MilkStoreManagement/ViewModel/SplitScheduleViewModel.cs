using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MilkStoreManagement.ViewModel
{
    public class View
    {
        public string THU { get; set; }
        public string CA { get; set; }
        public string MANV { get; set; }
        public View(string thu = "", string ca = "", string manv = "")
        {
            THU = thu;
            CA = ca;
            MANV = manv;
        }
    }
    public class SplitScheduleViewModel : BaseViewModel
    {
        public string[] dayLabels = { "Chủ nhật", "Hai", "Ba", "Tư", "Năm", "Sáu", "Bảy" };
        public string[] times = { "7:00-12:00", "12:30-17:30", "18:00-22:30" };
        private ObservableCollection<LICHLAMVIEC> _listLLV;
        public ObservableCollection<LICHLAMVIEC> listLLV { get => _listLLV; set { _listLLV = value; OnPropertyChanged(); } }
        private List<NHANVIEN> _ListNV;
        public List<NHANVIEN> ListNV { get => _ListNV; set { _ListNV = value; OnPropertyChanged(); } }

        private ObservableCollection<View> _LLLV;
        public ObservableCollection<View> LLLV { get => _LLLV; set { _LLLV = value; OnPropertyChanged(); } }
        public ICommand MinimizeWd { get; set; }
        public ICommand Closewd { get; set; }
        public ICommand Movewd { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand Add { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Update { get; set; }
        public ICommand Save { get; set; }
        public ICommand Choose { get; set; }
        public SplitScheduleViewModel()
        {
            LLLV = new ObservableCollection<View>();
            listLLV = new ObservableCollection<LICHLAMVIEC>();
            Loadwd = new RelayCommand<SplitSchedule>((p) => true, (p) => _Loadwd(p));
            Closewd = new RelayCommand<SplitSchedule>((p) => true, (p) => Close(p));
            MinimizeWd = new RelayCommand<SplitSchedule>((p) => true, (p) => Minimize(p));
            Movewd = new RelayCommand<SplitSchedule>((p) => true, (p) => _Movewd(p));
            Add = new RelayCommand<SplitSchedule>((p) => true, (p) => _Add(p));
            Delete = new RelayCommand<SplitSchedule>((p) => true, (p) => _Delete(p));
            Save = new RelayCommand<SplitSchedule>((p) => true, (p) => _Save(p));
            Update = new RelayCommand<SplitSchedule>((p) => true, (p) => _Update(p));
            Choose = new RelayCommand<SplitSchedule>((p) => true, (p) => _Choose(p));
        }
        void _Loadwd(SplitSchedule p)
        {
            ListNV = DataProvider.Ins.DB.NHANVIENs.ToList();
            p.NVBox.ItemsSource = ListNV;
            var query = (from llv in DataProvider.Ins.DB.LICHLAMVIECs
                         orderby llv.THU, llv.CA ascending
                         select new
                         {
                             THU = llv.THU,
                             CA = llv.CA,
                             MANV = llv.MANV
                         });
            var schedules = query.ToList();

            LLLV.Clear();
            foreach (var schedule in schedules)
            {
                string thu = dayLabels[schedule.THU - 1];
                string ca = schedule.CA.ToString();
                string manv = schedule.MANV;

                View view = new View(thu, ca, manv);
                LLLV.Add(view);
            }
            p.ListViewLLV.ItemsSource = LLLV;
        }
        void _Movewd(SplitSchedule p)
        {
            p.DragMove();
        }
        void Close(SplitSchedule p)
        {
            p.Close();
        }
        void Minimize(SplitSchedule p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _Choose(SplitSchedule p)
        {
            if (p.ListViewLLV.SelectedItem != null)
            {
                View view = p.ListViewLLV.SelectedItem as View;
                p.THUBox.SelectedIndex = Array.IndexOf(dayLabels, view.THU);
                p.CABox.SelectedIndex = int.Parse(view.CA) - 1;

                int index = ListNV.FindIndex(nv => nv.MANV == view.MANV);
                if (index != -1) p.NVBox.SelectedIndex = index;
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên có mã " + view.MANV, "LỖI", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                p.THUBox.SelectedIndex = -1;
                p.CABox.SelectedIndex = -1;
                p.NVBox.SelectedIndex = -1;
            }
        }
        void _Add(SplitSchedule p)
        {
            if (p.THUBox.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn thứ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (p.CABox.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn ca !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (p.NVBox.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string thu = dayLabels[p.THUBox.SelectedIndex];
            string ca = (p.CABox.SelectedIndex + 1).ToString();
            NHANVIEN nv = (NHANVIEN)p.NVBox.SelectedItem;
            bool isDuplicate = LLLV.Any(l => l.THU == thu && l.CA == ca && l.MANV == nv.MANV);
            if (isDuplicate)
            {
                MessageBox.Show("Lịch làm việc đã tồn tại!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            View view = new View(thu, ca, nv.MANV);
            LICHLAMVIEC llv = new LICHLAMVIEC()
            {
                THU = p.THUBox.SelectedIndex + 1,
                CA = p.CABox.SelectedIndex + 1,
                TGIAN = times[p.CABox.SelectedIndex],
                MANV = nv.MANV
            };
            int insertIndex = -1;
            for (int i = 0; i < LLLV.Count; i++)
            {
                var item = LLLV[i];
                if (Array.IndexOf(dayLabels, item.THU) > Array.IndexOf(dayLabels, thu) || (item.THU == thu && item.CA.CompareTo(ca) >= 0))
                {
                    insertIndex = i;
                    break;
                }
            }
            if (insertIndex == -1)
            {
                insertIndex = LLLV.Count;
            }

            LLLV.Insert(insertIndex, view);
            p.ListViewLLV.ItemsSource = LLLV;
            p.ListViewLLV.Items.Refresh();
            p.CABox.SelectedIndex = -1;
            p.NVBox.SelectedIndex = -1;
        }
        void _Delete(SplitSchedule p)
        {
            if (p.ListViewLLV.SelectedItem == null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dữ liệu ?", "XÁC NHẬN", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    LLLV.Clear();
                    p.ListViewLLV.ItemsSource = null;
                    return;
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi để xóa !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            MessageBoxResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này ?", "XÁC NHẬN", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (re == MessageBoxResult.Yes)
            {
                View selectedView = p.ListViewLLV.SelectedItem as View;
                if (selectedView != null)
                {
                    LLLV.Remove(selectedView);
                    p.ListViewLLV.ItemsSource = LLLV;
                    p.ListViewLLV.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Không thể xóa bản ghi được chọn!", "LỖI", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                p.ListViewLLV.SelectedItem = null;
            }
        }
        void _Update(SplitSchedule p)
        {
            if (p.ListViewLLV.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi muốn sửa !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            View selectedView = p.ListViewLLV.SelectedItem as View;
            string thu = dayLabels[p.THUBox.SelectedIndex];
            string ca = (p.CABox.SelectedIndex + 1).ToString();
            NHANVIEN nv = (NHANVIEN)p.NVBox.SelectedItem;

            bool isDuplicate = LLLV.Any(l => l != selectedView && l.THU == thu && l.CA == ca && l.MANV == nv.MANV);
            if (isDuplicate)
            {
                MessageBox.Show("Lịch làm việc đã tồn tại!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            selectedView.THU = thu;
            selectedView.CA = ca;
            selectedView.MANV = nv.MANV;
            p.ListViewLLV.Items.Refresh();
            p.ListViewLLV.SelectedItem = null;

        }
        void _Save(SplitSchedule p)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu lịch làm việc mới ?", "XÁC NHẬN", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            DataProvider.Ins.DB.LICHLAMVIECs.RemoveRange(DataProvider.Ins.DB.LICHLAMVIECs);
            listLLV.Clear();
            foreach (var view in LLLV)
            {
                int thu = Array.IndexOf(dayLabels, view.THU) + 1;
                int ca = int.Parse(view.CA);
                string manv = view.MANV;

                LICHLAMVIEC llv = new LICHLAMVIEC()
                {
                    THU = thu,
                    CA = ca,
                    TGIAN = times[ca - 1],
                    MANV = manv
                };

                listLLV.Add(llv);
            }
            try
            {
                DataProvider.Ins.DB.LICHLAMVIECs.AddRange(listLLV);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Lưu thành công !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Lưu không thành công !", "LỖI", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
