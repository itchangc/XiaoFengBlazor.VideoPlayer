"# XiaoFengBlazor.VideoPlayer" 
感谢这个开源的系统： https://github.com/densen2014/BootstrapBlazor.VideoPlayer
我是参考的这个开源项目做的播放器。我给作者提供html代码，估计作者没有时间整理。在加上我又迫切需要使用。
于是我在这个基础上做了升级。
仅仅是我个人使用，秉承着人人为我，我为人人的思想。我也把我做开源出来，因为我是个人使用，所以代码都是我自己想要的功能，如果大家有想使用的，可以自己改造。
下面讲解使用方式。我直接复制上个作者写的代码。

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
