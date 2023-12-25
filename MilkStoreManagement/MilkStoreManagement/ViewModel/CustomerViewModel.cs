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

namespace MilkStoreManagement.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<KHACHHANG> _listKH;
        public ObservableCollection<KHACHHANG> listKH { get => _listKH; set { _listKH = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand Detail { get; set; }
        public ICommand AddCsCommand { get; set; }
        public ICommand LoadListCommand { get; set; }

        private KHACHHANG _temp;
        public KHACHHANG temp { get => _temp; set { _temp = value; OnPropertyChanged(); } }
        public ICommand LoadCsCommand { get; set; }
        private ObservableCollection<string> _listTK;
        public string _GC;
        public string GC { get => _GC; set { _GC = value; OnPropertyChanged(); } }

        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public CustomerViewModel()
        {
            listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            listTK = new ObservableCollection<string>() { "Họ tên", "Mã KH", "SĐT" };
            SearchCommand = new RelayCommand<CustomerView>((p) => true, (p) => _SearchCommand(p));
            Detail = new RelayCommand<CustomerView>((p) => { return p.DatagridNV.SelectedItem == null ? false : true; }, (p) => _DetailCs(p));
            AddCsCommand = new RelayCommand<CustomerView>((p) => true, (p) => _AddCs(p));
            LoadCsCommand = new RelayCommand<CustomerView>((p) => true, (p) => _LoadCsCommand(p));
        }
        void _LoadCsCommand(CustomerView parameter)
        {
            parameter.cbxChon.SelectedIndex = 0;
        }



        void _SearchCommand(CustomerView paramater)
        {
            ObservableCollection<object> temp = new ObservableCollection<object>();
            var query = (from kh in DataProvider.Ins.DB.KHACHHANGs
                         select new
                         {
                             MAKH = kh.MAKH,
                             TENKH = kh.TENKH,
                             NGSINH = kh.NGSINH,
                             SDT = kh.SDT,
                             DOANHSO = kh.DOANHSO,
                             GHICHU = kh.GHICHU
                         });

            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã KH":
                        {
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.MAKH.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "Họ tên":
                        {
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.TENKH.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    case "SĐT":
                        {
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.SDT.Contains(paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            foreach (KHACHHANG s in listKH)
                            {
                                if (s.TENKH.Contains(paramater.txbSearch.Text))
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
                paramater.DatagridNV.ItemsSource = listKH;
        }
        void _DetailCs(CustomerView paramater)
        {
            DetailCustomerView detailCustomerView = new DetailCustomerView();
            KHACHHANG temp = (KHACHHANG)paramater.DatagridNV.SelectedItem;
            detailCustomerView.MAKH.Text = temp.MAKH;
            detailCustomerView.TenKH.Text = temp.TENKH;
            detailCustomerView.NGSINH.Text = temp.NGSINH.ToShortDateString();
            detailCustomerView.SDT.Text = temp.SDT;
            detailCustomerView.DOANHSO.Text = temp.DOANHSO.ToString();
            detailCustomerView.GHICHU.Text = temp.GHICHU;

            detailCustomerView.ShowDialog();
            listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            paramater.DatagridNV.ItemsSource = listKH;
            paramater.DatagridNV.SelectedItem = null;
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
        void _AddCs(CustomerView paramater)
        {
            AddCustomerView addCustomerView = new AddCustomerView();
            addCustomerView.MAKH.Text = rdma();
            addCustomerView.ShowDialog();
            listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            paramater.DatagridNV.ItemsSource = listKH;
        }
    }
}
