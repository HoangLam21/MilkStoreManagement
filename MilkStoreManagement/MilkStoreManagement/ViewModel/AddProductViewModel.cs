using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Globalization;
using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System.Data.Entity.Validation;

namespace MilkStoreManagement.ViewModel
{
    public class AddProductViewModel : BaseViewModel
    {
        private readonly string _localLink = System.Reflection.Assembly.GetExecutingAssembly().Location.Remove(System.Reflection.Assembly.GetExecutingAssembly().Location.IndexOf(@"bin\Debug"));
        public ICommand AddImage { get; set; }
        private string _linkimage;
        public string linkimage { get => _linkimage; set { _linkimage = value; OnPropertyChanged(); } }
        public ICommand AddProduct { get; set; }
        public ICommand Loadwd { get; set; }
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand MoveWindow { get; set; }
        public AddProductViewModel()
        {
            Closewd = new RelayCommand<AddProductView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<AddProductView>((p) => true, (p) => Minimize(p));
            linkimage = Path.Combine(_localLink, "Resource", "Image", "add.png");
            AddImage = new RelayCommand<Image>((p) => true, (p) => _AddImage(p));
            AddProduct = new RelayCommand<AddProductView>((p) => true, (p) => _AddProduct(p));
            Loadwd = new RelayCommand<AddProductView>((p) => true, (p) => _Loadwd(p));
        }
        void Close(AddProductView p)
        {
            p.Close();
        }
        void Minimize(AddProductView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _Loadwd(AddProductView paramater)
        {
            linkimage = Path.Combine(_localLink, "Resource", "Image", "add.png");
        }

        void _AddImage(Image img)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                linkimage = open.FileName;
            };
            if (linkimage == "/Resource/Image/add.png")
            {
                Uri fileUri = new Uri(linkimage, UriKind.Relative);
                img.Source = new BitmapImage(fileUri);
            }
            else
            {
                Uri fileUri = new Uri(linkimage);
                img.Source = new BitmapImage(fileUri);
            }
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
            do
            {
                Random rand = new Random();
                ma = rand.Next(0, 10000).ToString();
            } while (check(ma));
            return ma;
        }
        void _AddProduct(AddProductView paramater)
        {
            try
            {
                if (string.IsNullOrEmpty(paramater.MaSp.Text) || string.IsNullOrEmpty(paramater.TenSp.Text) || string.IsNullOrEmpty(paramater.LoaiSp.Text) || string.IsNullOrEmpty(paramater.GiaSp.Text) || string.IsNullOrEmpty(paramater.SlSp.Text) || linkimage == "/Resource/Image/add.png")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBoxResult h = System.Windows.MessageBox.Show("Bạn muốn thêm sản phẩm mới ?", "THÔNG BÁO", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (h == MessageBoxResult.Yes)
                    {
                        if (DataProvider.Ins.DB.SANPHAMs.Where(p => p.MASP == paramater.MaSp.Text).Count() > 0)
                        {
                            MessageBox.Show("Mã sản phẩm đã tồn tại.", "Thông Báo");
                        }
                        else
                        {
                            SANPHAM a = new SANPHAM();
                            a.MASP = paramater.MaSp.Text;
                            a.TENSP = paramater.TenSp.Text;
                            a.GIABAN = Convert.ToDecimal(paramater.GiaSp.Text);
                            try
                            {
                                a.GIABAN = Convert.ToDecimal(paramater.GiaSp.Text);
                            }
                            catch
                            {
                                MessageBox.Show("Giá sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            if (int.Parse(paramater.GiaSp.Text) < 0)
                            {
                                MessageBox.Show("Giá sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            string maLoaiSP = paramater.MALSP.Text;

                            LOAISANPHAM existingLoaiSP = DataProvider.Ins.DB.LOAISANPHAMs.FirstOrDefault(l => l.MALOAISP == maLoaiSP);
                            if (existingLoaiSP == null)
                            {
                                a.LOAISANPHAM = new LOAISANPHAM
                                {
                                    TENLOAISP = paramater.LoaiSp.Text,
                                    MALOAISP = maLoaiSP
                                };

                            }
                            else
                            {
                            }
                            a.MALOAISP = paramater.MALSP.Text;
                            //a.SL = int.Parse(paramater.SlSp.Text);
                            //try
                            //{
                            //    a.SL = int.Parse(paramater.SlSp.Text);
                            //}
                            //catch
                            //{
                            //    MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            //    return;
                            //}
                            //if (a.SL < 0)
                            //{
                            //    MessageBox.Show("Số lượng sản phẩm không hợp lệ !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                            //    return;
                            //}
                            a.SL = 0;
                            string dateFormat = "yyyy-MM-dd";

                            if (!DateTime.TryParseExact(paramater.NSX.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nsxDate))
                            {
                                MessageBox.Show("Ngày sản xuất không hợp lệ.", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            if (!DateTime.TryParseExact(paramater.HSD.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hsdDate))
                            {
                                MessageBox.Show("Hạn sử dụng không hợp lệ.", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            a.NSX = DateTime.ParseExact(paramater.NSX.Text, dateFormat, CultureInfo.InvariantCulture);
                            a.HSD = DateTime.ParseExact(paramater.HSD.Text, dateFormat, CultureInfo.InvariantCulture);
                            a.XUATXU = paramater.XUATXU.Text;
                            a.MANCC = paramater.MANCC.Text;
                            a.DVT = paramater.DVT.Text;
                            a.KLG = int.Parse(paramater.KLG.Text);
                            a.MOTA = paramater.MOTA.Text;
                            a.HINHSP = paramater.TenSp.Text + ((linkimage.Contains(".jpg")) ? ".jpg" : ".png").ToString();

                            DataProvider.Ins.DB.SANPHAMs.Add(a);
                            DataProvider.Ins.DB.SaveChanges();

                            try
                            {
                                File.Copy(linkimage, _localLink + @"Resource\ImgProducts\" + paramater.TenSp.Text + ((linkimage.Contains(".jpg")) ? ".jpg" : ".png").ToString(), true);
                            }
                            catch { }
                            MessageBox.Show("Thêm sản phẩm mới thành công !", "THÔNG BÁO");
                            paramater.MaSp.Clear();
                            paramater.MaSp.Text = rdma();
                            paramater.TenSp.Clear();
                            paramater.LoaiSp.SelectedItem = null;
                            paramater.GiaSp.Clear();
                            //paramater.SlSp.Clear();
                            Uri fileUri = new Uri(linkimage = Path.Combine(_localLink, "Resource", "Image", "add.png"), UriKind.Relative);
                            paramater.HinhAnh.Source = new BitmapImage(fileUri);
                            paramater.NSX.Clear();
                            paramater.HSD.Clear();
                            paramater.XUATXU.Clear();
                            paramater.MANCC.Clear();
                            paramater.MALSP.Clear();
                            paramater.KLG.Clear();
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessage = "Validation errors:\n";

                foreach (var entityValidationError in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        errorMessage += $"Entity: {entityValidationError.Entry.Entity.GetType().Name}, Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}\n";
                    }
                }

                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
