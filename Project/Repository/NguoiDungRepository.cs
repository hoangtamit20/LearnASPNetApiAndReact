using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Entity;
using Project.Repository.IRepository;

namespace Project.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly BanKhoaHocDbContext _context;
        
        public NguoiDungRepository(BanKhoaHocDbContext context)
        {
            _context = context;
        }

        public bool addNguoiDung(NguoiDung nguoiDung)
        {
            try
            {
                _context.Add(nguoiDung);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool deleteNguoiDung(int id)
        {
            if (_context.NguoiDungs != null)
            {
                var nguoiDung = _context.NguoiDungs.SingleOrDefault(n => n.Id == id);
                if (nguoiDung != null)
                {
                    try
                    {
                        _context.Remove(nguoiDung);
                        _context.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        public NguoiDung? getNguoiDungById(int id) => _context.NguoiDungs != null ? _context.NguoiDungs.SingleOrDefault(nd => nd.Id == id) : null;

        public List<NguoiDung>? nguoiDungs() => _context.NguoiDungs != null ? _context.NguoiDungs.ToList() : null;

        public bool updateNguoiDung(NguoiDung nguoiDung)
        {
            try{
                if (_context.NguoiDungs == null)
                    return false;
                var nd = _context.NguoiDungs.FirstOrDefault(nd => nd.Id == nguoiDung.Id);
                if (nd == null)
                    return false;
                nd.TenDangNhap = nguoiDung.TenDangNhap;
                nd.MatKhau = nguoiDung.MatKhau;
                nd.NgaySinh = nguoiDung.NgaySinh;
                nd.Email = nguoiDung.Email;
                nd.DiaChi = nguoiDung.DiaChi;
                var s = _context.NguoiDungs.Update(nd);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}