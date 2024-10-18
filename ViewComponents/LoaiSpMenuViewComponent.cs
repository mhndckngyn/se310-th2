using Microsoft.AspNetCore.Mvc;
using se310_th2.Repository;

namespace se310_th2.ViewComponents;

public class LoaiSpMenuViewComponent : ViewComponent
{
    private readonly ILoaiSpRepository _loaiSpRepository;

    public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
    {
        _loaiSpRepository = loaiSpRepository;
    }

    public IViewComponentResult Invoke()
    {
        var loaiSp = _loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
        return View(loaiSp);
    }
}