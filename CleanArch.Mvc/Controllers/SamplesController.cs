using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class SamplesController : Controller
    {
        public IActionResult ProgramSamples()
        {
            List<CartViewModel> carts = new List<CartViewModel>();
            CartViewModel cart1 = new CartViewModel()
            {
                Title = "اپلیکیشن تحت ویندوز ERP",
                FileName = "1.jpg",
                ToolsName = "WinForms + SQL Server",
                Description = "اعم از خرید و فروش محصولات و...",
                Rate = 4.3f
            };
            carts.Add(cart1);

            CartViewModel cart2 = new CartViewModel()
            {
                Title = "سامانه حضور و غیاب",
                FileName = "3.jpg",
                ToolsName = "WinForms + SQL Server",
                Description = "سامانه‌ای برای مدیریت حضور کارکنان یک شرکت.",
                Rate = 4.8f
            };
            carts.Add(cart2);

            CartViewModel cart3 = new CartViewModel()
            {
                Title = "پنل مدیریتی فروشگاه",
                FileName = "2.jpg",
                ToolsName = "Blazor + Web API",
                Description = "مدیریت محصولات، کاربران، سفارش‌ها و موجودی انبار.",
                Rate = 5f
            };
            carts.Add(cart3);

            CartViewModel cart4 = new CartViewModel()
            {
                Title = "اپلیکیشن سفارش غذا",
                FileName = "4.jpg",
                ToolsName = ".NET MAUI",
                Description = "برای کاربران اندروید جهت سفارش سریع غذا با GPS.",
                Rate = 4.9f
            };
            carts.Add(cart4);

            return View(carts);
        }
    }
}
