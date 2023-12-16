using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoFengBlazor.Components;

namespace XiaoFengBlazor.Components;

/// <summary>
/// 播放器选项
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
    /// 设置封面资源,相对或者绝对路径
    /// </summary>
    public string? Poster { get; set; }

    //public bool EnableSourceset { get; set; }

    //public string[] TechOrder { get; set; } = new string[] { "html5", "flvjs" };
    //public string? TechOrder { get; set; } = "{ \"html5\", \"flvjs\" }";

    //public string? Flvjs { get; set; } = "{ \"mediaDataSource\": { \"isLive\": true, \"cors\": true, \"withCredentials\": false } }";

    public string[] TechOrder { get; set; }
    public FlvOptions Flvjs { get; set; }


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
