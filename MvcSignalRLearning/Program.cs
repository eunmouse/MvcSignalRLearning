var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Main/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// 미들웨어 파이프라인 구성 (요청이 지나가는 통로)
app.UseHttpsRedirection();
app.UseRouting(); // 1. 라우팅 행위 실행 지점

app.UseAuthorization(); 

app.MapStaticAssets();

// 2. 라우팅 규칙 매칭
// 예) "/"              -> MainController.ShowMain()
//     "/Main/Memo"     -> MainController.Memo()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=ShowMain}/{id?}")
    .WithStaticAssets();


app.Run();
