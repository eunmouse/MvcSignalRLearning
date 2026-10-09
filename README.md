# MVC SignalR Learning

ASP.NET Core MVC의 기본 구조를 익히고, SignalR을 이용한 실시간 통신을 학습하기 위한 프로젝트입니다.

## 학습 목표

- ASP.NET Core MVC의 요청 처리 흐름 이해
- Controller와 View 연결 방식 이해
- Razor 문법과 Layout 사용법 학습
- Middleware와 Routing 구조 이해
- SignalR Hub 구성 및 클라이언트 연결
- SignalR을 이용한 실시간 메시지 송수신 구현

## 개발 환경

- .NET 10
- ASP.NET Core MVC
- Razor View
- Bootstrap
- SignalR 예정

## 현재 구현 내용

- 기본 라우트를 `MainController.ShowMain()`으로 설정
- Main 화면과 Memo 화면 구성
- 공통 Layout 적용
- 공통 오류 화면 및 Request ID 처리
- 기본 HomeController와 Home View 제거

## 요청 처리 흐름

MVC View 요청은 다음 순서로 처리됩니다.

```text
브라우저 HTTP 요청
    ↓
Kestrel
    ↓
ASP.NET Core Middleware
    ↓
Routing
    ↓
Controller Action
    ↓
Razor View
    ↓
HTML 응답
    ↓
브라우저
```

예를 들어 `/Main/Memo` 요청은 다음과 같이 처리됩니다.

```text
GET /Main/Memo
    ↓
MainController.Memo()
    ↓
Views/Main/Memo.cshtml
    ↓
Views/Shared/_Layout.cshtml 적용
    ↓
HTML 응답
```

## 프로젝트 구조

```text
MvcSignalRLearning/
├─ Controllers/
│  └─ MainController.cs
├─ Models/
│  └─ ErrorViewModel.cs
├─ Views/
│  ├─ Main/
│  │  ├─ Main.cshtml
│  │  └─ Memo.cshtml
│  ├─ Shared/
│  │  ├─ _Layout.cshtml
│  │  └─ Error.cshtml
│  ├─ _ViewImports.cshtml
│  └─ _ViewStart.cshtml
├─ wwwroot/
└─ Program.cs
```

## 실행 방법

### 필요 환경

- .NET 10 SDK

### 실행

저장소 루트에서 다음 명령을 실행합니다.

```powershell
dotnet run --project MvcSignalRLearning
```

개발 환경 주소는 다음과 같습니다.

```text
HTTP  : http://localhost:5159
HTTPS : https://localhost:7236
```

## 주요 경로

| URL | Controller Action | View |
|---|---|---|
| `/` | `MainController.ShowMain()` | `Views/Main/Main.cshtml` |
| `/Main` | `MainController.ShowMain()` | `Views/Main/Main.cshtml` |
| `/Main/Memo` | `MainController.Memo()` | `Views/Main/Memo.cshtml` |
| `/Main/Error` | `MainController.Error()` | `Views/Shared/Error.cshtml` |

## View 탐색 규칙

`MainController`에서 매개변수 없이 `View()`를 반환하면 액션 이름을 기준으로 View를 찾습니다.

```csharp
public IActionResult Memo()
{
    return View();
}
```

이 경우 다음 순서로 탐색합니다.

```text
Views/Main/Memo.cshtml
Views/Shared/Memo.cshtml
```

View 이름을 직접 지정할 수도 있습니다.

```csharp
return View("Main");
```

이 경우 다음 순서로 탐색합니다.

```text
Views/Main/Main.cshtml
Views/Shared/Main.cshtml
```

## 학습 계획

- [x] 기본 MVC 프로젝트 구조 확인
- [x] Controller와 View 연결
- [x] Razor와 Layout 사용
- [x] 기본 라우트 변경
- [ ] ViewModel을 이용한 데이터 전달
- [ ] Form 입력과 Model Binding
- [ ] 입력값 Validation
- [ ] Dependency Injection
- [ ] SignalR Hub 생성
- [ ] JavaScript SignalR 클라이언트 연결
- [ ] 실시간 메시지 전송
- [ ] 사용자별 또는 그룹별 메시지 전송
- [ ] 연결 및 재연결 처리

## 참고

이 프로젝트는 ASP.NET Core MVC와 SignalR 학습을 목적으로 작성되고 있습니다. 학습 과정에 따라 코드와 프로젝트 구조가 계속 변경될 수 있습니다.
