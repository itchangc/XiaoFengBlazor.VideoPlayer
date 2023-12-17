```
感谢这篇文章的教程：https://www.cnblogs.com/densen2014/p/16981092.html  Blazor组件自做十三: VideoPlayer 视频播放器
自学一下Blazor，我也做个视频播放器玩玩
```
﻿# 欢迎使用 XiaoFengBlazor.VideoPlayer 工具库
 | QQ群号 | QQ群 | 公众号 |
| :----:| :----: | :----: |
| 748408911  | ![QQ 群](https://user-images.githubusercontent.com/16105174/198058269-0ea5928c-a2fc-4049-86da-cca2249229ae.png) | ![畅聊了个科技](https://user-images.githubusercontent.com/16105174/198059698-adbf29c3-60c2-4c76-b894-21793b40cf34.jpg) |

使用方法:

1.nuget包

```XiaoFengBlazor.VideoPlayer```

2._Imports.razor 文件 或者页面添加 添加组件库引用

```@using XiaoFengBlazor.Components```


3.razor页面
```
<VideoPlayer MineType=EnumVideoType.m3u8 Url="https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" />

<VideoPlayer MineType=EnumVideoType.mp4 Url="//vjs.zencdn.net/v/oceans.mp4" />

<VideoPlayer MineType=EnumVideoType.mp4 Url="//vjs.zencdn.net/v/oceans.mp4" Width="400" Height="300" Autoplay="false" Poster="//vjs.zencdn.net/v/oceans.png" />

```

### 批量视频播放
```
@page "/counter"
<PageTitle>Counter</PageTitle>

<VideoPlayer MineType=EnumVideoType.mp4 Url="http://192.168.0.194:80/rtp/02930F45.live.mp4" VideoJsPath="./video/video.min.js"
             CssPath="./video/video-js.min.css" Liveui=true SourcesList=@videoSources  />

@code {
    List<VideoSources> videoSources = new List<VideoSources>
    {
        new VideoSources(EnumVideoType.mp4, "http://192.168.0.194:80/record/rtp/02930F45/2023-12-09/22-30-23-23.mp4"),
        new VideoSources(EnumVideoType.mp4, "http://192.168.0.194:80/record/rtp/02930F45/2023-12-09/22-32-25-24.mp4"),
        new VideoSources(EnumVideoType.mp4, "http://192.168.0.194:80/record/rtp/02930F45/2023-12-09/22-34-27-25.mp4"),
        new VideoSources(EnumVideoType.mp4, "http://192.168.0.194:80/record/rtp/02930F45/2023-12-09/22-36-29-26.mp4")
    };
}

```
###  http...flv播放
```
@page "/fetchdata"
@inject HttpClient Http

<PageTitle>Weather forecast</PageTitle>
 
<VideoPlayer MineType=EnumVideoType.flv
             Url="http://192.168.0.194:80/rtp/02930F45.live.flv"
             Width="400"
             Height="300"
             Autoplay="true"
             Liveui=true
             VideoJsPath="./video/video.min.js"
             CssPath="./video/video-js.min.css" />
```

### ws...flv播放 4/6/9宫格 播放
```
@page "/ninegrid"
<PageTitle>4宫格</PageTitle>

<div class="grid-container">
    @for (int i = 0; i < 4; i++)
    {
        <div class="grid-item">
            <VideoPlayer MineType=EnumVideoType.flv
                         Url="ws://192.168.0.194:80/rtp/02930F45.live.flv"
                         Width="400"
                         Height="300"
                         Autoplay="true"
                         Liveui=true
                         VideoJsPath="./video/video.min.js"
                         CssPath="./video/video-js.min.css" />
        </div>
    }
</div>
<style>
.grid-container {
  display: grid;
  grid-template-columns: auto auto auto;
  padding: 10px;
}
.grid-item {
  padding: 20px;
  text-align: center;
}
</style>
```


4.参数说明

|  类型   |  参数   | 说明  | 默认值  | 
|  ----  |  ----  | ----  | ----  | 
| string | Url  | 资源地址 | null | 
| string | MineType  | 资源类型,video/mp4, application/x-mpegURL, video/ogg .. 更多参考 EnumVideoType | application/x-mpegURL | 
| int | Width  | 宽度 | 300 | 
| int | Height  | 高度 | 200 | 
| bool | Controls  | 显示控制条 | true | 
| bool | Autoplay  | 自动播放 | true | 
| string | Poster  | 设置封面资源,相对或者绝对路径 |  | 
| string | Language  | 界面语言,默认 获取当前文化, 例如 zh-CN / en-US,如果语言包不存在,回退到 zh-CN | 当前文化 | 
| VideoPlayerOption | Option  | 播放器选项, 不为空则优先使用播放器选项,否则使用参数构建 | null | 
| async Task |  Reload(string? url, string? type) | 切换播放资源 | |
| async Task |  SetPoster(string? poster) | 设置封面 | |
| string |  VideoJsPath | 因为video.js版本问题，8.0之后对flv ws支持不友好，直接报错，于是我使用了7.0的js。所以我在调用的位置，使用我指定的js版本 参考这个 https://cdn.bootcdn.net/ajax/libs/video.js/7.21.5/alt/video.core.min.js |
| string |  CssPath |  因为video.js版本问题，8.0之后对flv ws支持不友好，直接报错，于是我使用了7.0的js。所以我在调用的位置，使用我指定的css版本 |
| int |  InactivityTimeout |  用于定义用户在多少毫秒内没有与播放器进行交互之后，系统会将其判定为“不活跃”,设置0 是不用判断 |
| string |  CssPath |  因为video.js版本问题，8.0之后对flv ws支持不友好，直接报错，于是我使用了7.0的js。所以我在调用的位置，使用我指定的css版本 |
| bool |  Liveui |  允许玩家使用新的实时 UI |
| bool |  Fluid |  播放器将具有可变大小 |
| bool |  Debug |  显示调试信息 |
| double[]  |  PlaybackRates | 严格大于 0 的数字数组，其中 1 表示正常速度 （100%）、0.5表示半速（50%）、2表示双速（200%）等 |

##效果图如下：
![image](https://github.com/itchangc/XiaoFengBlazor.VideoPlayer/assets/40175292/3e396c05-e511-4591-9b5c-adfb5adee1ab)

![image](https://github.com/itchangc/XiaoFengBlazor.VideoPlayer/assets/40175292/1f36c446-ae5c-4fba-bf84-a9ee3f1a0ac1)

![image](https://github.com/itchangc/XiaoFengBlazor.VideoPlayer/assets/40175292/58ec3ecb-08c6-4c2b-ad91-9f34c3322236)


# XiaoFeng 类库包含库
| 命名空间 | 所属类库 | 开源状态 | 说明 | 包含功能 |
| :----| :---- | :---- | :----: | :---- |
| XiaoFeng.Prototype | XiaoFeng.Core | :white_check_mark: | 扩展库 | ToCase 类型转换<br/>ToTimestamp,ToTimestamps 时间转时间戳<br/>GetBasePath 获取文件绝对路径,支持Linux,Windows<br/>GetFileName 获取文件名称<br/>GetMatch,GetMatches,GetMatchs,IsMatch,ReplacePatten,RemovePattern 正则表达式操作<br/> |
| XiaoFeng.Net | XiaoFeng.Net | :white_check_mark: | 网络库 | XiaoFeng网络库，封装了Socket客户端，服务端（Socket,WebSocket），根据当前库可轻松实现订阅，发布等功能。|
| XiaoFeng.Http | XiaoFeng.Core | :white_check_mark: | 模拟请求库 | 模拟网络请求 |
| XiaoFeng.Data | XiaoFeng.Core | :white_check_mark: | 数据库操作库 | 支持SQLSERVER,MYSQL,ORACLE,达梦,SQLITE,ACCESS,OLEDB,ODBC等数十种数据库 |
| XiaoFeng.Cache | XiaoFeng.Core | :white_check_mark: | 缓存库 |  内存缓存,Redis,MemcachedCache,MemoryCache,FileCache缓存 |
| XiaoFeng.Config | XiaoFeng.Core | :white_check_mark: | 配置文件库 | 通过创建模型自动生成配置文件，可为xml,json,ini文件格式 |
| XiaoFeng.Cryptography | XiaoFeng.Core | :white_check_mark: | 加密算法库 | AES,DES,RSA,MD5,DES3,SHA,HMAC,RC4加密算法 |
| XiaoFeng.Excel | XiaoFeng.Excel | :white_check_mark: | Excel操作库 | Excel操作，创建excel,编辑excel,读取excel内容，边框，字体，样式等功能  |
| XiaoFeng.Ftp | XiaoFeng.Ftp | :white_check_mark: | FTP请求库 | FTP客户端 |
| XiaoFeng.IO | XiaoFeng.Core | :white_check_mark: | 文件操作库 | 文件读写操作 |
| XiaoFeng.Json | XiaoFeng.Core | :white_check_mark: | Json序列化，反序列化库 | Json序列化，反序列化库 |
| XiaoFeng.Xml | XiaoFeng.Core | :white_check_mark: | Xml序列化，反序列化库 | Xml序列化，反序列化库 |
| XiaoFeng.Log | XiaoFeng.Core | :white_check_mark: | 日志库 | 写日志文件,数据库 |
| XiaoFeng.Memcached | XiaoFeng.Memcached | :white_check_mark: | Memcached缓存库 | Memcached中间件,支持.NET框架、.NET内核和.NET标准库,一种非常方便操作的客户端工具。实现了Set,Add,Replace,PrePend,Append,Cas,Get,Gets,Gat,Gats,Delete,Touch,Stats,Stats Items,Stats Slabs,Stats Sizes,Flush_All,Increment,Decrement,线程池功能。|
| XiaoFeng.Redis | XiaoFeng.Redis | :white_check_mark: | Redis缓存库 | Redis中间件,支持.NET框架、.NET内核和.NET标准库,一种非常方便操作的客户端工具。实现了Hash,Key,String,ZSet,Stream,Log,List,订阅发布,线程池功能; |
| XiaoFeng.Threading | XiaoFeng.Core | :white_check_mark: | 线程库 | 线程任务,线程队列 |
| XiaoFeng.Mvc | XiaoFeng.Mvc | :x: | 低代码WEB开发框架 | .net core 基础类，快速开发CMS框架，真正的低代码平台，自带角色权限，WebAPI平台，后台管理，可托管到服务运行命令为:应用.exe install 服务名 服务说明,命令还有 delete 删除 start 启动  stop 停止。 |
| XiaoFeng.Proxy | XiaoFeng.Proxy | :white_check_mark: | 代理库 | 开发中 |
| XiaoFeng.TDengine | XiaoFeng.TDengine | :white_check_mark: | TDengine 客户端 | 开发中 |
| XiaoFeng.GB28181 | XiaoFeng.GB28181 | :white_check_mark: | 视频监控库，SIP类库，GB28181协议 | 开发中 |
| XiaoFeng.Onvif | XiaoFeng.Onvif | :white_check_mark: | 视频监控库Onvif协议 | XiaoFeng.Onvif 基于.NET平台使用C#封装Onvif常用接口、设备、媒体、云台等功能， 拒绝WCF服务引用动态代理生成wsdl类文件 ， 使用原生XML扩展标记语言封装参数，所有的数据流向都可控。 |

