using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;

namespace XiaoFengBlazor.Components;

/// <summary>
/// 播放类型
/// </summary>
public enum EnumVideoType
{
    [Description("video/ogg")]
    opus,
    [Description("video/ogg")]
    ogv,
    [Description("video/mp4")]
    mp4,
    [Description("video/mp4")]
    mov,
    [Description("video/mp4")]
    m4v,
    [Description("video/x-matroska")]
    mkv,
    [Description("audio/mp4")]
    m4a,
    [Description("audio/mpeg")]
    mp3,
    [Description("audio/aac")]
    aac,
    [Description("audio/x-caf")]
    caf,
    [Description("audio/flac")]
    flac,
    [Description("audio/ogg")]
    oga,
    [Description("audio/wav")]
    wav,
    [Description("application/x-mpegURL")]
    m3u8,
    [Description("application/dash+xml")]
    mpd,
    [Description("image/jpeg")]
    jpg,
    [Description("image/jpeg")]
    jpeg,
    [Description("image/gif")]
    gif,
    [Description("image/png")]
    png,
    [Description("image/svg+xml")]
    svg,
    [Description("image/webp")]
    webp,

}