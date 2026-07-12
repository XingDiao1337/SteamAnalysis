# SteamAnalysis 原生增强版

![SteamAnalysis](https://img.shields.io/badge/License-MIT-blue.svg)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgray.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)

本项目基于 [OpenSteamEYA](https://github.com/hvh-software/OpenSteamEYA) 二次开发而来，已经**完全移除了对任何第三方庞大 UI 库（如 Avalonia/WPF）的依赖**。
项目使用原生 **Windows Forms (WinForms)** 重构了底层与界面排版，大幅降低了体积、内存占用，解决了由于渲染框架导致的部分机器闪退与性能问题。

## ⚠️ 免责声明 (Disclaimer)
如果使用这个软件出现任何问题，和 **tuntun1337**、**XingDiao1337** 以及 **小司大王喵** 没有任何关系。使用者需自行承担所有可能带来的后果与风险。

## ✨ 特性 (Features)
- 🚀 **极速解析**：支持一键解析卡密并获取详细 Steam 账户状态。
- ⚡ **原生极致轻量**：采用纯正 WinForms 编写，内存占用极低，不再闪退。单文件打包支持极限缩减。
- 📊 **深度核心情报挖掘**：
  - **Steam 账号注册时间**（防初始号甄别）
  - **隐私设置状态**
  - **CS2 真实游戏时长**提取
  - VAC 封禁状态 (包含游戏内与 GC 状态)
  - 交易封禁详情
  - 社区 5 刀限制检测
  - 竞技匹配冷却期与具体原因分析
  - CS2 优先分数与等级、胜场
- 🔗 **一键操作**：支持一键登入 Steam 客户端，一键清理创意工坊订阅。
- 🌐 **代理支持**：内置自动获取系统代理/加速器网络进行请求的逻辑，告别网络连接失败。

---

## 🛠️ 如何自行编译 (How to Build)

本项目非常易于编译，不依赖复杂的环境，按照以下步骤即可生成属于你自己的 `.exe` 文件。

### 1. 下载必要的编译环境
你需要下载并安装微软官方的 **.NET 9.0 SDK** (注意是 **SDK** 而不是 Runtime)。
- **下载地址**: [https://dotnet.microsoft.com/zh-cn/download/dotnet/9.0](https://dotnet.microsoft.com/zh-cn/download/dotnet/9.0)
- 选择 `Windows` 下的 `x64` 安装包进行安装。

### 2. 克隆源代码
将本仓库的源码下载到本地：
```cmd
git clone https://github.com/XingDiao1337/SteamAnalysis.git
cd SteamAnalysis
```

### 3. 编译与打包
打开命令行 (CMD 或 PowerShell) 进入源码目录，运行以下命令：

**选项 A: 打包为免环境版 (体积较大，约 108MB)**
*包含完整的 .NET 运行库，用户的电脑上不需要安装任何东西就能直接双击运行。*
```cmd
dotnet publish SteamAnalysisAvalonia.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -o .\Publish_Standalone
```

**选项 B: 打包为框架依赖极限缩小版 (体积极小，约 1.3MB)**
*体积非常小，但要求运行该软件的用户电脑上必须提前安装好 .NET 9.0 桌面运行时环境。*
```cmd
dotnet publish SteamAnalysisAvalonia.csproj -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -o .\Publish_Tiny
```

编译完成后，你的 `.exe` 程序将分别出现在 `Publish_Standalone` 或 `Publish_Tiny` 文件夹中。

---

## 📄 协议 (License)
本项目基于 [MIT License](LICENSE) 协议开源。
