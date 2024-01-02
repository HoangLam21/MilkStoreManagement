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
using static System.Data.Entity.Infrastructure.Design.Executor;
using MilkStoreManagement.Model;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.ComponentModel;
using static MilkStoreManagement.ViewModel.OrderViewModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Data.Entity;

namespace MilkStoreManagement.ViewModel
{



    public class AddOrderViewModel : BaseViewModel

    {
        public class HienThi1 : BaseViewModel
        {

            public ICommand IncreaseCommand { get; set; }
            public ICommand DecreaseCommand { get; set; }
            public string TenSP { get; set; }
            public string MASP { get; set; }

            public int SL { get; set; }
            public Decimal Dongia { get; set; }
            public Decimal Tong { get; set; }
            private string _HINHSP;
            public string HINHSP
            {
                get
                {
                    if (string.IsNullOrEmpty(_HINHSP))
                    {
                        return Const._localLink + @"Resource\ImgProducts\ava1.jpg";
                    }
                    else if (_HINHSP.Contains(Const._localLink))
                    {
                        return _HINHSP;
                    }
                    else
                    {
                        return Const._localLink + _HINHSP;
                    }
                }
                set { _HINHSP = value; }
            }

            public HienThi1(string MASP = "", string TenSP = "", Decimal Dongia = 0, int SL = 1, string hinh = null)
            {
                this.TenSP = TenSP;
                this.SL = SL;
                this.Dongia = Dongia;
                this.MASP = MASP;
                this.HINHSP = hinh;
                IncreaseCommand = new RelayCommand<AddOrderView>((p) => true, (p) => IncreaseQuantity(p));
                DecreaseCommand = new RelayCommand<AddOrderView>((p) => true, (p) => DecreaseQuantity(p));
            }
            private bool check = false;
            private void IncreaseQuantity(AddOrderView obj)
            {
                check = true;
                SL++;
                OnPropertyChanged(nameof(SL));
                UpdateTotalAmount(obj);
            }

            private void DecreaseQuantity(AddOrderView obj)
            {

                if (CanDecreaseQuantity())
                {
                    check = false;
                    SL--;
                    OnPropertyChanged(nameof(SL));
                    UpdateTotalAmount(obj);
                }
            }

            private bool CanDecreaseQuantity()
            {
                return SL > 1;
            }
            private void UpdateTotalAmount(AddOrderView obj)
            {
                if (check == true)
                {
                    if (decimal.TryParse(obj.TONGTIEN.Text.Replace(" VND", "").Replace(",", ""), out decimal currentTotal))
                    {
                        decimal updatedTotal = currentTotal + this.Dongia;
                        obj.TONGTIEN.Text = updatedTotal.ToString("N0") + " VND";

                        if (decimal.TryParse(obj.GIAM.Text.Replace("%", ""), out decimal Giam))
                        {
                            decimal giam = ((Giam * updatedTotal) / 100);
                            decimal updatedFinalTotal = updatedTotal - giam;
                            obj.TONGGIAM.Text = giam.ToString("N0") + " VND";
                            obj.THANHTIEN.Text = updatedFinalTotal.ToString("N0") + " VND";
                        }
                    }
                }
                else
                {
                    if (decimal.TryParse(obj.TONGTIEN.Text.Replace(" VND", "").Replace(",", ""), out decimal currentTotal))
                    {
                        decimal updatedTotal = currentTotal - this.Dongia;
                        obj.TONGTIEN.Text = updatedTotal.ToString("N0") + " VND";
                        if (decimal.TryParse(obj.GIAM.Text.Replace("%", ""), out decimal Giam))
                        {
                            decimal giam = ((Giam * updatedTotal) / 100);
                            decimal updatedFinalTotal = updatedTotal - giam;
                            obj.TONGGIAM.Text = giam.ToString("N0") + " VND";
                            obj.THANHTIEN.Text = updatedFinalTotal.ToString("N0") + " VND";
                        }
                    }
                }
            }
        }
        public ICommand DeleteSP { get; set; }
        public ICommand AddOrderCommand { get; set; }
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand AddPd { get; set; }
        public ICommand chooseKH { get; set; }
        public Decimal tongtien { get; set; }
        public Decimal tonggiam { get; set; }
        public Decimal tienkm { get; set; }
        public Decimal km { get; set; }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }


        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }
        public ICommand SaveHD { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<KHACHHANG> _LKH;
        public List<KHACHHANG> LKH { get => _LKH; set { _LKH = value; OnPropertyChanged(); } }
        private ObservableCollection<SANPHAM> _listSP;
        public ObservableCollection<SANPHAM> listSP { get => _listSP; set { _listSP = value; OnPropertyChanged(); } }

        private ObservableCollection<CTHD> _LCTHD;
        public ObservableCollection<CTHD> LCTHD { get => _LCTHD; set { _LCTHD = value; OnPropertyChanged(); } }
        private ObservableCollection<SANPHAM> _LSPSelected;

        private List<SANPHAM> _LSP;
        public List<SANPHAM> LSP { get => _LSP; set { _LSP = value; OnPropertyChanged(); } }
        public ObservableCollection<SANPHAM> LSPSelected { get => _LSPSelected; set { _LSPSelected = value; OnPropertyChanged(); } }

        private ObservableCollection<HienThi1> _LHT1;
        public ObservableCollection<HienThi1> LHT1
        {
            get => _LHT1;
            set
            {
                if (_LHT1 != value)
                {
                    _LHT1 = value;
                    OnPropertyChanged(nameof(LHT1));
                }
            }
        }

        private ObservableCollection<HienThi1> _selectedProducts;
        public ObservableCollection<HienThi1> SelectedProducts
        {
            get => _selectedProducts;
            set { _selectedProducts = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }

        public AddOrderViewModel()
        {
            listTK = new ObservableCollection<string>() { "Mã sản phẩm", "Tên sản phẩm", "Tất cả" };
            Quantity = 1;
            tongtien = 0;
            tonggiam = 0;
            SearchCommand = new RelayCommand<AddOrderView>((p) => true, (p) => _SearchCommand(p));
            tienkm = 0;
            SelectedProducts = new ObservableCollection<HienThi1>();
            AddPd = new RelayCommand<AddOrderView>((p) => true, (p) => _AddPd(p));
            listSP = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs);
            LHT1 = new ObservableCollection<HienThi1>();
            LCTHD = new ObservableCollection<CTHD>();
            LSPSelected = new ObservableCollection<SANPHAM>();
            Closewd = new RelayCommand<AddOrderView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<AddOrderView>((p) => true, (p) => Minimize(p));
            MoveWindow = new RelayCommand<AddOrderView>((p) => true, (p) => moveWindow(p));
            Loadwd = new RelayCommand<AddOrderView>((p) => true, (p) => _Loadwd(p));
            chooseKH = new RelayCommand<AddOrderView>((p) => true, (p) => _chooseKH(p));
            SaveHD = new RelayCommand<AddOrderView>((p) => true, (p) => _SaveHD(p));
            DeleteSP = new RelayCommand<AddOrderView>((p) => true, (p) => _DeleteSP(p));
        }

        void _SearchCommand(AddOrderView paramater)
        {
            ObservableCollection<SANPHAM> temp = new ObservableCollection<SANPHAM>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Mã sản phẩm":
                        {
                            try
                            {
                                foreach (SANPHAM s in listSP)
                                {
                                    if (s.MASP == (paramater.txbSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }

                            }
                            catch { }
                            break;
                        }
                    case "Tên sản phẩm":
                        {
                            foreach (SANPHAM s in listSP)
                            {
                                if (s.TENSP.ToLower().Contains(paramater.txbSearch.Text.ToLower()))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }

                    default:
                        {
                            foreach (SANPHAM s in listSP)
                            {
                                if (s.TENSP.ToLower().Contains(paramater.txbSearch.Text.ToLower()) || s.MASP == (paramater.txbSearch.Text))
                                {
                                    temp.Add(s);
                                }
                            }
                            break;
                        }
                }
                paramater.ListViewSP.ItemsSource = temp;
            }
            else
                paramater.ListViewSP.ItemsSource = listSP;
        }


        void _Loadwd(AddOrderView parmater)
        {
            LKH = DataProvider.Ins.DB.KHACHHANGs.ToList();
            LSP = DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0).ToList();
            parmater.ListViewSP.ItemsSource = LSP;
            parmater.KH.ItemsSource = LKH;
            parmater.cbxChon.SelectedIndex = 2;
            parmater.MANV.Text = Const.TenDangNhap;
            DateTime nghd = DateTime.Now;
            parmater.NGHD.Text = nghd.ToShortDateString();
            parmater.GIAM.Text = (0).ToString() + "%";
            parmater.TONGTIEN.Text = String.Format("{0:0,0}", tongtien) + " VND";
            parmater.THANHTIEN.Text = String.Format("{0:0,0}", tongtien) + " VND";
            parmater.TONGGIAM.Text = String.Format("{0:0,0}", tongtien) + " VND";
        }

        void moveWindow(AddOrderView p)
        {
            p.DragMove();
        }
        void Close(AddOrderView p)
        {
            tongtien = 0;
            tienkm = 0;
            LHT1.Clear();

            p.Close();

        }
        void Minimize(AddOrderView p)
        {
            p.WindowState = WindowState.Minimized;
        }




        void _chooseKH(AddOrderView parameter)
        {
            KHACHHANG temp = (KHACHHANG)parameter.KH.SelectedItem;
            if (temp != null)
            {
                Decimal doanhso = 0;
                foreach (HOADON a in DataProvider.Ins.DB.HOADONs)
                {
                    if (a.MAKH == temp.MAKH)
                        doanhso += a.TRIGIA;
                }
                km = 0;
                if (doanhso > 2000000 && doanhso <= 5000000)
                    km = 2;
                else if (doanhso > 5000000 && doanhso <= 10000000)
                    km = 5;
                else if (doanhso > 10000000)
                    km = 10;

                parameter.GIAM.Text = (km).ToString() + "%";
            }
            else
            {
                km = 0;
                parameter.GIAM.Text = (km).ToString() + "%";
            }
        }

        void _AddPd(AddOrderView paramater)
        {

            SANPHAM selectedProduct = (SANPHAM)paramater.ListViewSP.SelectedItem;
            paramater.ListViewSP.SelectedIndex = -1;

            if (selectedProduct != null)
            {



                HienThi1 newSelectedItem = LHT1.FirstOrDefault(item => item.TenSP == selectedProduct.TENSP);

                if (newSelectedItem != null)
                {
                    newSelectedItem.SL++;

                    newSelectedItem.Dongia = selectedProduct.GIABAN;
                }
                else
                {
                    HienThi1 newItem = new HienThi1(selectedProduct.MASP, selectedProduct.TENSP, selectedProduct.GIABAN, 1, selectedProduct.HINHSP);
                    LHT1.Add(newItem);
                }

                if (paramater.listHT != null)
                {
                    paramater.listHT.ItemsSource = LHT1;
                    paramater.listHT.Items.Refresh();
                }
                if (decimal.TryParse(paramater.TONGTIEN.Text.Replace(" VND", "").Replace(",", ""), out decimal currentTotal))
                {
                    decimal updatedTotal = currentTotal + selectedProduct.GIABAN;
                    paramater.TONGTIEN.Text = updatedTotal.ToString("N0") + " VND";
                    if (decimal.TryParse(paramater.GIAM.Text.Replace("%", ""), out decimal Giam))
                    {
                        decimal giam = ((Giam * updatedTotal) / 100);
                        paramater.TONGGIAM.Text = giam.ToString("N0") + " VND";
                        decimal updatedFinalTotal = updatedTotal - giam;
                        paramater.THANHTIEN.Text = updatedFinalTotal.ToString("N0") + " VND";

                    }
                }


            }

        }
        void _DeleteSP(AddOrderView paramater)
        {
            if (paramater.listHT.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Bạn chưa chọn sản phẩm để xóa !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn có chắc muốn xóa sản phẩm.", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (h == MessageBoxResult.Yes)
            {
                decimal TT;
                decimal tienxoa;
                decimal tienconlai;

                HienThi1 a = (HienThi1)paramater.listHT.SelectedItem;

                if (a != null && a.SL > 0)
                {
                    if (decimal.TryParse(paramater.TONGTIEN.Text.Replace(" VND", "").Replace(",", ""), out decimal currentTotal))
                    {
                        TT = currentTotal;
                        tienxoa = a.Dongia * a.SL;
                        tienconlai = TT - tienxoa;

                        if (decimal.TryParse(paramater.GIAM.Text.Replace("%", ""), out decimal Giam))
                        {
                            decimal giam = ((Giam * tienconlai) / 100);
                            decimal updatedFinalTotal = tienconlai - giam;
                            paramater.TONGTIEN.Text = tienconlai.ToString("N0") + " VND";
                            paramater.TONGGIAM.Text = giam.ToString("N0") + " VND";
                            paramater.THANHTIEN.Text = updatedFinalTotal.ToString("N0") + " VND";
                        }

                    }


                    LHT1.Remove(a);

                    foreach (CTHD b in LCTHD.ToList())
                    {
                        if (b.MASP == a.MASP && b.SLMUA == a.SL)
                        {
                            LCTHD.Remove(b);
                            break;
                        }
                    }
                }
            }
            else
            {
                return;
            }
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
                ma = rand.Next(0, 99);
            } while (check(ma));
            return ma;
        }
        void _SaveHD(AddOrderView paramater)
        {
            DataProvider.Ins.DB.SaveChangesAsync();
            if (paramater.ListViewSP.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("Thông tin hóa đơn chưa đầy đủ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult h = System.Windows.MessageBox.Show("  Bạn muốn thanh toán ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (h == MessageBoxResult.Yes)
            {
                KHACHHANG a = (KHACHHANG)paramater.KH.SelectedItem;
                decimal trigia = decimal.Parse(paramater.TONGTIEN.Text.Replace(" VND", "").Replace(",", ""));
                decimal tien = decimal.Parse(paramater.THANHTIEN.Text.Replace(" VND", "").Replace(",", ""));
                decimal Giam = decimal.Parse(paramater.GIAM.Text.Replace("%", ""));
                decimal Km = Giam / 100;
                string giam = "- " + String.Format("{0:0,0}", tienkm) + " VND";
                string makh;
                if (a == null)
                {
                    makh = null;
                }
                else
                {
                    makh = a.MAKH;
                }
                HOADON temp = new HOADON()
                {
                    SOHD = int.Parse(paramater.SOHD.Text),
                    MAKH = makh,
                    MANV = Const.NV.MANV,
                    NGHD = DateTime.Now,
                    CTHDs = new ObservableCollection<CTHD>(LCTHD),
                    TRIGIA = trigia,
                    THANHTIEN = tien,
                    KHACHHANG = a,
                    KHUYENMAI = Km,
                    NHANVIEN = Const.NV,
                };
                foreach (HienThi1 s in LHT1)
                {
                    CTHD cthd = new CTHD()
                    {
                        MASP = s.MASP,
                        SLMUA = s.SL,
                    };
                    temp.CTHDs.Add(cthd);
                    SANPHAM SP = DataProvider.Ins.DB.SANPHAMs.FirstOrDefault(t => t.MASP == s.MASP);
                    if (SP != null)
                    {
                        SP.SL -= s.SL;
                    }
                }
                DataProvider.Ins.DB.HOADONs.Add(temp);
                if (a != null) a.DOANHSO += temp.THANHTIEN;
                DataProvider.Ins.DB.SaveChanges();
                MessageBoxResult d = System.Windows.MessageBox.Show("  Bạn có muốn in hóa đơn ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (d == MessageBoxResult.Yes)
                {
                    print(paramater);
                }

                paramater.KH.SelectedItem = null;
                LHT1.Clear();
                LCTHD.Clear();
                paramater.ListViewSP.ItemsSource = LHT1;
                paramater.GIAM.Text = (0).ToString() + "%";
                paramater.TONGTIEN.Text = String.Format("{0:0,0}", 0) + " VND";
                paramater.THANHTIEN.Text = String.Format("{0:0,0}", 0) + " VND";
                paramater.TONGGIAM.Text = String.Format("{0:0,0}", 0) + " VND";

                paramater.SOHD.Text = rdma().ToString();
                paramater.ListViewSP.ItemsSource = listSP;
                MessageBox.Show("Thanh toán hóa đơn thành công !", "THÔNG BÁO");
            }
            else
                return;
        }

        void print(AddOrderView parameter)
        {
            KHACHHANG temp = (KHACHHANG)parameter.KH.SelectedItem;
            PrintOrderView printOrderView = new PrintOrderView();
            printOrderView.Height = 300 + 35 * LHT1.Count;
            if (temp != null)
            {
                printOrderView.TenKH.Text = temp.TENKH;
                printOrderView.sdt.Text = temp.SDT;
            }
            else
            {
                printOrderView.TenKH.Text = "";
                printOrderView.sdt.Text = "";
            }

            printOrderView.manv.Text = parameter.MANV.Text;
            printOrderView.ngay.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            printOrderView.sohd.Text = parameter.SOHD.Text;
            printOrderView.ListSP.ItemsSource = LHT1;
            printOrderView.tt.Text = parameter.TONGTIEN.Text;
            printOrderView.gg.Text = parameter.TONGGIAM.Text;
            printOrderView.tt1.Text = parameter.THANHTIEN.Text;
            bool isPrintButtonClicked = false;

            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(printOrderView.PrintView, "BILL");
                    isPrintButtonClicked = true;

                }
            }
            finally
            {
                if (isPrintButtonClicked)
                {
                    MessageBox.Show("In Hóa đơn thành công !", "THÔNG BÁO");
                }
            }
        }

    }


}

