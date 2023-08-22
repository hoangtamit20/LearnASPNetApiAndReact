using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Entity;

namespace Project.Repository.IRepository
{
    public interface INguoiDungRepository
    {
        List<NguoiDung>? nguoiDungs();
        List<NguoiDung>? nguoiDungs(int pageNumber, int pageSize);
        NguoiDung? getNguoiDungById(int id);
        bool updateNguoiDung(NguoiDung nguoiDung);
        bool addNguoiDung(NguoiDung nguoiDung);
        bool deleteNguoiDung(int id);
    }
}