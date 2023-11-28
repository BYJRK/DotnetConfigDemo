# ConfigDemo

该项目旨在演示如何在新版的 DOTNET 项目中使用传统的 `App.config` 配合 `ConfigurationManager` 的方式管理配置项。

## 为什么将 `App.config` 称为传统方式？

因为自 .NET Core 以来，诞生了新的 JSON 格式的配置方式，即 `appsettings.json`，而不再推荐使用传统的 XML 格式的 `App.config`。

以及，新版的 .NET 项目中，也不再推荐使用 `ConfigurationManager` 来读取配置项，而是使用 `IConfiguration` 接口。

另外，一些 .NET 新版本的一些新特性并不是很兼容传统的方式，尤其是发布单一文件（`PublishSingleFile`），极有可能会导致 `ConfigurationManager.OpenExeConfiguration()` 方法无法顺利读取配置文件。

## 传统方式的概述

传统方式的配置项管理，主要有以下几个步骤：

1. 在项目中添加 `App.config` 文件。无需关注该文件的生成操作（Build Action）以及是否复制到输出目录，因为它会自动被拷贝为输出目录中的 `ProjectName.dll.config`。
2. 在 `App.config` 中添加符合格式要求的配置项。
3. 在代码中使用 `ConfigurationManager.OpenExeConfiguration()` 方法读取配置项

## 现存问题

当尝试发布为单一文件时，如果配置文件及配置项的读取并不发生在入口项目，此时上述读取配置项的方式会无法顺利找到 `.config` 配置文件。

发布指令如下：

```bash
dotnet publish -c Release -o publish -p:PublishSingleFile=true --self-contained false
```

此时有这么几种解决方案：

### 1. 只在入口项目中管理及读取配置项

简单来说，只在入口项目中添加 `App.config` 文件，并在入口项目中通过 `OpenExeConfiguration()` 方法读取配置项，并生成 `Configuration` 实例，进而传参给其他方法。

具体可以查看 `workaround` 分支。

### 2. 使用 `IncludeAllContentForSelfExtract` 选项

在发布时添加这一参数：

```bash
-p:IncludeAllContentForSelfExtract=true
```

可以使本应出现在输出目录的一些 .dll 以及 .config 文件被转移到用户目录下，例如 `C:\Users\username\AppData\Local\Temp\AppName\`。

但这个方法并不推荐，因为这会导致配置文件不出现在应用程序的根目录，不利于管理。

参考：

- [.NET 5 PublishSingleFile - Produces exe and dlls](https://stackoverflow.com/a/65170521/10150864)

### 3. 使用 `OpenMappedExeConfiguration()` 方法

这个方法可以指定配置文件的路径，从而避免了配置文件无法被找到的问题。

```csharp
var map = new ExeConfigurationFileMap
{
    ExeConfigFilename = "ConfigDemo.dll.config"
};
var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
```

注意：`OpenExeConfiguration()` 方法也支持传入文件名，但并不能正确找到并读取配置项。这里只能通过 `OpenMappedExeConfiguration` 方法来实现。

参考：

- [ConfigurationManager.OpenExeConfiguration - loads the wrong file?](https://stackoverflow.com/questions/1083927/configurationmanager-openexeconfiguration-loads-the-wrong-file/12587078#12587078)