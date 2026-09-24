using Microsoft.AspNetCore.Mvc;
using MvcSignalRLearning.Models;
using System.Diagnostics;

namespace MvcSignalRLearning.Controllers
{
    // Program.cs의 라우팅 규칙에서 "Main"이 이 컨트롤러(MainController)에 대응된다.
    // View("Main") -> Views/Main/Main.cshtml 을 찾아 렌더링한다. 
    public class MainController : Controller
    {
        public IActionResult ShowMain()
        {
            return View("Main");
        }

        public IActionResult Memo()
        {
            return View();
        }

        // "/Main/Error" 요청이 오면 실행됨.
        // View(model) 형태로 ErrorViewModel을 뷰에 전달 -> Views/Shared/Error.cshtml에서 @Model로 사용 가능
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
