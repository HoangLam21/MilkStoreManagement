using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MilkStoreManagement.ViewModel
{
    public class ProductsViewModel : BaseViewModel
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

        private ObservableCollection<SANPHAM> _listSP;
        public ObservableCollection<SANPHAM> listSP { get => _listSP; set { _listSP = value; OnPropertyChanged(); } }
        private ObservableCollection<SANPHAM> _listSP1;
        public ObservableCollection<SANPHAM> listSP1 { get => _listSP1; set { _listSP1 = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand DetailPdCommand { get; set; }
        public ICommand AddPdPdCommand { get; set; }
        public ICommand LoadCsCommand { get; set; }
        private ObservableCollection<string> _listTK;
        public ObservableCollection<string> listTK { get => _listTK; set { _listTK = value; OnPropertyChanged(); } }
        public ICommand Filter { get; set; }
        public ProductsViewModel()
        {
            listTK = new ObservableCollection<string>() { "Tên SP", "Giá SP" };
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()));
            AddPdPdCommand = new RelayCommand<ProductsView>((p) => { return p == null ? false : true; }, (p) => _AddPdCommand(p));
            SearchCommand = new RelayCommand<ProductsView>((p) => { return p == null ? false : true; }, (p) => _SearchCommand(p));
            DetailPdCommand = new RelayCommand<ProductsView>((p) => { return p.ListViewProduct.SelectedItem == null ? false : true; }, (p) => _DetailPd(p));
            LoadCsCommand = new RelayCommand<ProductsView>((p) => true, (p) => _LoadCsCommand(p));
            Filter = new RelayCommand<ProductsView>((p) => true, (p) => _Filter(p));
        }
        void _LoadCsCommand(ProductsView parameter)
        {
            listTK = new ObservableCollection<string>() { "Tên SP", "Giá SP" };
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()));
            parameter.cbxChon.SelectedIndex = 0;
            parameter.cbxChon1.SelectedIndex = 0;
            _Filter(parameter);
            _SearchCommand(parameter);
        }
        void _Filter(ProductsView parameter)
        {

            switch (parameter.cbxChon1.SelectedIndex.ToString())
            {
                case "0":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "1":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "SBOT"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "2":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "STC"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "3":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "STCC"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "4":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "SDAC"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "5":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "SBAU"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "6":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "ST"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
                case "7":
                    {
                        listSP = new ObservableCollection<SANPHAM>(listSP1.GroupBy(p => p.TENSP).Select(grp => grp.FirstOrDefault()).Where(p => p.MALOAISP == "SNL"));
                        foreach (var item in listSP)
                        {
                            item.HINHSP = Path.Combine(_localLink, "Resource", "ImgProducts", item.HINHSP);
                        }
                        parameter.ListViewProduct.ItemsSource = listSP;
                        break;
                    }
            }

        }
        void _SearchCommand(ProductsView paramater)
        {
            ObservableCollection<SANPHAM> temp = new ObservableCollection<SANPHAM>();
            if (paramater.txbSearch.Text != "")
            {
                switch (paramater.cbxChon.SelectedItem.ToString())
                {
                    case "Tên SP":
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
                    case "Giá SP":
                        {
                            try
                            {
                                foreach (SANPHAM s in listSP)
                                {
                                    if (s.GIABAN <= int.Parse(paramater.txbSearch.Text))
                                    {
                                        temp.Add(s);
                                    }
                                }
                            }
                            catch { }
                            break;
                        }
                    default:
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
                }
                paramater.ListViewProduct.ItemsSource = temp;
            }
            else
                paramater.ListViewProduct.ItemsSource = listSP;
        }
        void _DetailPd(ProductsView paramater)
        {
            DetailProduct detailProduct = new DetailProduct();
            SANPHAM temp = (SANPHAM)paramater.ListViewProduct.SelectedItem;

            detailProduct.TenSP.Text = temp.TENSP;
            detailProduct.GiaSP.Text = string.Format("{0:0,0}", temp.GIABAN) + " VNĐ";
            detailProduct.LoaiSP.Text = temp.LOAISANPHAM.TENLOAISP;
            detailProduct.MASP.Text = temp.MASP;

            string SL = listSP1.Where(p => p.TENSP == temp.TENSP && p.SL >= 0).Select(p => p.SL).Sum().ToString();
            detailProduct.SLSP.Text = SL;

            detailProduct.MOTA.Text = temp.MOTA;
            detailProduct.MALSP.Text = temp.MALOAISP;
            detailProduct.XUATXU.Text = temp.XUATXU;
            detailProduct.NSX.Text = temp.NSX.ToShortDateString();
            detailProduct.HSD.Text = temp.HSD.ToShortDateString();
            detailProduct.MANCC.Text = temp.MANCC.ToString();

            detailProduct.DVT.Text = temp.DVT;
            detailProduct.KLG.Text = temp.KLG.ToString();

            linkimage = temp.HINHSP;
            Uri fileUri = new Uri(linkimage);
            detailProduct.HinhAnh.Source = new BitmapImage(fileUri);

            detailProduct.ShowDialog();

            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            paramater.ListViewProduct.SelectedItem = null;
            _Filter(paramater);
            _SearchCommand(paramater);

        }
        bool check(string m)
        {
            foreach (SANPHAM temp in DataProvider.Ins.DB.SANPHAMs)
            {
                if (temp.MASP == m)
                    return true;
            }
            return false;
        }
        string rdma()
        {
            string ma;
            Random rand = new Random();

            do
            {
                int randomNumber = rand.Next(0, 10000);
                ma = randomNumber.ToString("D4");
            } while (check(ma));

            return ma;
        }

        void _AddPdCommand(ProductsView paramater)
        {
            AddProductView addProductView = new AddProductView();
            addProductView.MaSp.Text = rdma();
            addProductView.ShowDialog();
            listSP1 = new ObservableCollection<SANPHAM>(DataProvider.Ins.DB.SANPHAMs.Where(p => p.SL >= 0));
            _Filter(paramater);
            _SearchCommand(paramater);
        }

    }
}
