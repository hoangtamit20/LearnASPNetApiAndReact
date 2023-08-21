using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Services.DataAnnotationService;

namespace Project.Entity
{
    public class NguoiDung
    {
        private int id;
        private string? tenDangNhap;
        private string? matKhau;
        private DateOnly? ngaySinh;
        private string? email;
        private string? diaChi;

        public NguoiDung()
        {
        }

        public NguoiDung(int id, string? tenDangNhap, string? matKhau, DateOnly? ngaySinh, string? email, string? diaChi)
        {
            this.id = id;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.ngaySinh = ngaySinh;
            this.email = email;
            this.diaChi = diaChi;
        }

        [Key]
        [DisplayName("ID người dùng : ")]
        public int Id { get => id; set => id = value; }

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

        [DisplayName("Ngày sinh : ")]
        [Column("DATE")]
        [Required(ErrorMessage = "{0} không được để trống.")]
        [NgaySinhExpression]
        public DateOnly? NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        [DisplayName("Email : ")]
        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "{0} phải có ít nhất {2} ký tự và nhiều nhất {1} ký tự.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} không đúng định dạng.")]
        public string? Email { get => email; set => email = value; }

        [DisplayName("Địa chỉ : ")]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(150, ErrorMessage = "{0} không được vượt quá {1} ký tự")]
        public string? DiaChi { get => diaChi; set => diaChi = value; }
    }
}