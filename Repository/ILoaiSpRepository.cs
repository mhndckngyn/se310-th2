using se310_th2.Models;

namespace se310_th2.Repository;

public interface ILoaiSpRepository
{
    TLoaiSp Add(TLoaiSp loaiSp);
    TLoaiSp Update(TLoaiSp loaiSp);
    TLoaiSp Delete(string maLoaiSp);
    TLoaiSp Get(string maLoaiSp);
    IEnumerable<TLoaiSp> GetAllLoaiSp();
}