初始化项目与指令链接

1. 安装 spacetime

```powershell
iwr https://windows.spacetimedb.com -useb | iex
```

2. 安装 .NET SDK 8

```powershell
winget install Microsoft.DotNet.SDK.8
```

3. 安装 WASI 工作负载（实验性）

```powershell
dotnet workload install wasi-experimental
```

4. 初始化项目

```powershell
spacetime init --lang csharp --project-path ./main-server main-server
```

5. 生成解决方案并添加项目

```powershell
dotnet new sln -n main-server
dotnet sln main-server.sln add "main-server\spacetimedb\StdbModule.csproj"
```

VS Code 任务快捷方式
- 任务：`配置环境`（一步安装 1-3）
- 任务：`初始化服务器`（执行第 4 步）
- 任务：`生成解决方案`（执行第 5 步）

在 VS Code 中按 `Ctrl+Shift+P`，运行“Tasks: Run Task”，选择对应任务即可。

