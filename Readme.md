# 项目结构说明

本项目包含 SpacetimeDB 的服务端模块代码及运行所需的工具和数据目录。

## 目录结构

- **main-server/**
  - **spacetimedb/**: 核心业务逻辑代码，包含 SpacetimeDB 模块的 C# 实现。
    - `Lib.cs`: 模块入口及主要逻辑定义。
    - `StdbModule.csproj`: C# 项目配置文件。
- **sapcetimedb/**: 包含 SpacetimeDB 的本地运行环境和工具。
  - `spacetimedb-cli.exe`: SpacetimeDB 命令行管理工具 (CLI)，用于发布和管理模块。
  - `spacetimedb-standalone.exe`: SpacetimeDB 独立数据库服务程序。
- **server-data/**: 数据库运行时产生的数据、日志和配置文件目录。
  - `config.toml`: 服务端配置文件。
  - `logs/`: 运行日志目录。
- **SpacetimdeDB.sln**: 项目的 .NET 解决方案文件，用于管理整个工程。
- **global.json**: .NET SDK 版本配置文件，确保构建环境一致性。

## 使用 VS Code 任务运行服务器和工具

本项目已经在 VS Code 中配置了常用任务（初始化服务器 / 启动服务器 / 编译插件），推荐通过任务来统一操作，而不是手动输入命令。

### 1. 打开任务列表

1. 在 VS Code 顶部菜单中选择：`终端` → `运行任务...`
2. 或者按 `Ctrl + Shift + P`，输入 `任务: 运行任务` 并回车。

在弹出的列表中，你会看到类似以下任务：

- `初始化服务器`
- `启动服务器`
- `编译插件`

### 2. 常用任务说明

#### 2.1 初始化服务器（仅首次或需要重新初始化时）

在任务列表中选择：`初始化服务器`，VS Code 会在终端中执行：


https://spacetimedb.com/docs/quickstarts/c-sharp/
