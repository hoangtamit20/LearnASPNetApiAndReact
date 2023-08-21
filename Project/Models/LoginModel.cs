using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LoginModel
    {
        private string? tenDangNhap;
        private string? matKhau;
        [DisplayName("Tên đăng nhập : ")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        [Required(ErrorMessage = "{0} không được để trống.")]
        [RegularExpression("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$", ErrorMessage = "{0}")]
        [Column(TypeName = "VARCHAR")]
        public string? TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }

        [DisplayName("Mật khẩu: ")]
        [StringLength(250, MinimumLength = 8, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        [Required(ErrorMessage = "{0} không được để trống.")]
        [MaxLength(16, ErrorMessage = "{0} không được quá {1} ký tự.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 và tối đa 16 ký tự, ít nhất một chữ cái viết hoa, một chữ cái viết thường, một số và một ký tự đặc biệt.")]
        [Column(TypeName = "VARCHAR")]
        public string? MatKhau { get => matKhau; set => matKhau = value; }
    }
}