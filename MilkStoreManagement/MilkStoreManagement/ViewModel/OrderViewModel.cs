using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MilkStoreManagement.ViewModel
{
    public class OrderViewModel : BaseViewModel
    {
        public class HienThi
        {
            public string TenSP { get; set; }
            public int SL { get; set; }
            public Decimal Dongia { get; set; }
            public Decimal Tong { get; set; }

            public HienThi(string TenSP = "", Decimal Dongia = 0, int SL = 0, Decimal Tong = 0)
            {
                this.TenSP = TenSP;
                this.SL = SL;
                this.Tong = Tong;
                this.Dongia = Dongia;

            }
        }
        private ObservableCollection<HOADON> _listHD;
        public ObservableCollection<HOADON> listHD { get => _listHD; set { _listHD = value; OnPropertyChanged(); } }
        public ICommand OpenAddOrder { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }

        private string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        public ICommand LoadCsCommand { get; set; }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public OrderViewModel()
        {
            listTK = new ObservableCollection<string>() { "Số hóa đơn", "Mã nhân viên", "Mã khách hàng" };
            listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            OpenAddOrder = new RelayCommand<OrderView>((p) => true, (p) => _OpenAdd(p));
            SearchCommand = new RelayCommand<OrderView>((p) => true, (p) => _SearchCommand(p));
            Detail = new RelayCommand<OrderView>((p) => { return p?.DatagridHD?.SelectedItem != null; }, (p) => _Detail(p));
            LoadCsCommand = new RelayCommand<OrderView>((p) => true, (p) => _LoadCsCommand(p));
        }
        //void _LoadCsCommand(OrderView parameter)
        //{
        //    parameter.cbxChon.SelectedIndex = 0;
        //}
        void _LoadCsCommand(OrderView parameter)
        {
            parameter.cbxChon.SelectedIndex = 3;
            listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);

        }
        bool check(int m)
        {
            foreach (HOADON temp in DataProvider.Ins.DB.HOADONs)
            {
                if (temp.SOHD == m)
                    return true;
            }
            return false;
        }
        int rdma()
        {
            int ma;
            do
            {
                Random rand = new Random();
                ma = rand.Next(0, 10000);
            } while (check(ma));
            return ma;
        }
        void _OpenAdd(OrderView paramater)
        {
            AddOrderView addOrder = new AddOrderView();
            addOrder.SOHD.Text = rdma().ToString();
            addOrder.ShowDialog();
            listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            paramater.DatagridHD.ItemsSource = listHD;
            paramater.DatagridHD.Items.Refresh();
        }
        void _SearchCommand(OrderView paramater)
        {
            ObservableCollection<HOADON> temp = new ObservableCollection<HOADON>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Số hóa đơn":
                        {
                            try
                            {
                                foreach (HOADON s in listHD)
                                {
                                    if (s.SOHD == int.Parse(paramater.txbSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }

                            }
                            catch { }
                            break;
                        }
                    case "Mã nhân viên":
                        {
                            foreach (HOADON s in listHD)
                            {
                                if (s.NHANVIEN.MANV.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Mã khách hàng":
                        {
                            foreach (HOADON s in listHD)
                            {
                                if (s.KHACHHANG.MAKH.ToLower().Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            foreach (HOADON s in listHD)
                            {
                                if (s.SOHD == int.Parse(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.DatagridHD.ItemsSource = temp;
            }
            else
                paramater.DatagridHD.ItemsSource = listHD;
        }
        void _Detail(OrderView parameter)
        {
            if (parameter != null && parameter.DatagridHD.SelectedItem != null)
            {
                HOADON temp = (HOADON)parameter.DatagridHD.SelectedItem;
                if (temp != null)
                {
                    parameter.MANV.Text = temp.NHANVIEN.MANV;
                    parameter.NGHD.Text = temp.NGHD.ToString();
                    parameter.SOHD.Text = temp.SOHD.ToString();
                    parameter.MAKH.Text = temp.MAKH.ToString();
                    parameter.TENKH.Text = temp.KHACHHANG.TENKH;
                    parameter.SDT.Text = temp.KHACHHANG.SDT;
                    parameter.GIAM.Text = temp.KHUYENMAI.ToString() + "%";

                    List<HienThi> list = new List<HienThi>();
                    foreach (CTHD a in temp.CTHDs)
                    {
                        string tenSanPham = a.SANPHAM.TENSP;
                        decimal giaSanPham = a.SANPHAM.GIABAN;
                        int soLuongMua = a.SLMUA;
                        list.Add(new HienThi(tenSanPham, giaSanPham, soLuongMua, soLuongMua * giaSanPham));
                    }

                    parameter.listCTHD.ItemsSource = list;
                    parameter.GIAM.Text = "- " + String.Format("{0:0,0}", (temp.TRIGIA * temp.KHUYENMAI) + " VND");
                    parameter.TONGTIEN.Text = String.Format("{0:0,0}", temp.TRIGIA) + " VND";
                    parameter.THANHTIEN.Text = String.Format("{0:0,0}", temp.THANHTIEN) + " VND";
                }
            }
            else
                MessageBox.Show("Không tìm thấy hóa đơn!");

        }

    }
}
