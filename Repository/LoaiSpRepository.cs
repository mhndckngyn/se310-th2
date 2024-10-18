using se310_th2.Context;
using se310_th2.Models;

namespace se310_th2.Repository;

public class LoaiSpRepository : ILoaiSpRepository
{
    private readonly MyDbContext _context;

    public LoaiSpRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public TLoaiSp Add(TLoaiSp loaiSp)
    {
        _context.TLoaiSps.Add(loaiSp);
        _context.SaveChanges();
        return loaiSp;
    }

    public TLoaiSp Update(TLoaiSp loaiSp)
    {
        _context.Update(loaiSp);
        _context.SaveChanges();
        return loaiSp;
    }

    public TLoaiSp Delete(string maLoaiSp)
    {
        throw new NotImplementedException();
    }

    public TLoaiSp Get(string maLoaiSp)
    {
        return _context.TLoaiSps.Find(maLoaiSp);
    }

    public IEnumerable<TLoaiSp> GetAllLoaiSp()
    {
        return _context.TLoaiSps;
    }
}