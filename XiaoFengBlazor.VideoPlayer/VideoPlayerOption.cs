namespace XiaoFengBlazor.Components;

/// <summary>
/// 播放器选项
///  URL:https://videojs.com/guides/options/
/// </summary>
public class VideoPlayerOption
{
    /// <summary>
    /// 宽度
    /// </summary>
    public int Width { get; set; } = 300;

    /// <summary>
    /// 高度
    /// </summary>
    public int Height { get; set; } = 200;

    /// <summary>
    /// 显示控制条,默认 true
    /// </summary>
    public bool Controls { get; set; } = true;

    /// <summary>
    /// 自动播放,默认 true
    /// </summary>
    public bool Autoplay { get; set; } = true;

    /// <summary>
    /// 预载,默认 auto
    /// </summary>
    public string Preload { get; set; } = "auto";

    /// <summary>
    /// 播放资源
    /// </summary>
    public List<VideoSources> Sources { get; set; } = new List<VideoSources>();

    /// <summary>
    /// 播放列表
    /// </summary>
    public List<VideoSources> SourcesList { get; set; } = new List<VideoSources>();

    /// <summary>
    /// 设置封面资源,相对或者绝对路径
    /// </summary>
    public string? Poster { get; set; }

    //public bool EnableSourceset { get; set; }


    public string[] TechOrder { get; set; } = new[] { "html5", "flvjs" };
    public FlvOptions Flvjs { get; set; } = new FlvOptions
    {
        MediaDataSource = new FlvOptions.MediaDataSourceOption
        {
            IsLive = true,
            Cors = true,
            WithCredentials = false
        }
    };
    /// <summary>
    /// 用于定义用户在多少毫秒内没有与播放器进行交互之后，系统会将其判定为“不活跃”
    /// </summary>
    public int InactivityTimeout { get; set; } = 0;
    /// <summary>
    /// 允许玩家使用新的实时 UI
    /// </summary>
    public bool Liveui { get; set; } = false;
    /// <summary>
    /// 播放器将具有可变大小
    /// </summary>
    public bool Fluid { get; set; } = true;

    /// <summary>
    /// 严格大于 0 的数字数组，其中 1 表示正常速度 （100%）、0.5表示半速（50%）、2表示双速（200%）等
    /// </summary>
    public double[] PlaybackRates { get; set; } = new[] { 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5 };

    /// <summary>
    /// 界面语言,默认 zh-CN
    /// </summary>
    public string? Language { get; set; } = "zh-CN";
}
public class FlvOptions
{
    public MediaDataSourceOption MediaDataSource { get; set; }

    public class MediaDataSourceOption
    {
        public bool IsLive { get; set; }
        public bool Cors { get; set; }
        public bool WithCredentials { get; set; }
    }
}
