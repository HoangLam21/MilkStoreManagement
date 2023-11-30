using MilkStoreManagement.Model;
using MilkStoreManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MilkStoreManagement.ViewModel
{
    public class ForgetPassViewModel
    {
        public ICommand Closewd { get; set; }
        public ICommand Minimizewd { get; set; }
        public ICommand SendPass { get; set; }
        public ICommand movewd { get; set; }
        public ForgetPassViewModel()
        {
            Closewd = new RelayCommand<ForgetPassView>((p) => true, (p) => Close(p));
            Minimizewd = new RelayCommand<ForgetPassView>((p) => true, (p) => Minimize(p));
            SendPass = new RelayCommand<ForgetPassView>((p) => true, (p) => _SendPass(p));
            movewd = new RelayCommand<ForgetPassView>((p) => true, (p) => _movewd(p));
        }
        void Close(ForgetPassView p)
        {
            p.Close();
        }
        void _movewd(ForgetPassView p)
        {
            p.DragMove();
        }
        void Minimize(ForgetPassView p)
        {
            p.WindowState = WindowState.Minimized;
        }
        void _SendPass(ForgetPassView parameter)
        {
            int dem = DataProvider.Ins.DB.NHANVIENs.Where(p => p.EMAIL == parameter.mail.Text).Count();
            if (dem == 0)
            {
                MessageBox.Show("Email này chưa được đăng ký !", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Random rand = new Random();
            string newpass = rand.Next(100000, 999999).ToString();
            foreach (NHANVIEN temp in DataProvider.Ins.DB.NHANVIENs)
            {
                if (temp.EMAIL == parameter.mail.Text)
                {
                    temp.PASS = LoginViewModel.MD5Hash(LoginViewModel.Base64Encode(newpass));
                    break;
                }
            }
            DataProvider.Ins.DB.SaveChanges();

            string nd = "Mật khẩu hiện tại của bạn là <strong>" + newpass + "</strong>. Trân trọng !";
            MailMessage message = new MailMessage("milkstoremanagement@gmail.com", parameter.mail.Text, "LẤY LẠI MẬT KHẨU", nd);
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("milkstoremanagement@gmail.com", "dadg mfzv zppx baot");
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối không an toàn !", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show("Đã gửi mật khẩu vào Email đăng ký !", "Thông báo");
        }
    }
}
