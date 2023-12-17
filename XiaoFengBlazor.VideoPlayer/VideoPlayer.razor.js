
var player = null;

//播放视频列表
export function loadPlayerList(instance, id, options) {

    console.log('player sourcesList id:', id);
    console.log('options:', options);

    var videoSources = options.sourcesList;

    player = videojs(id, options);
    // 当前播放视频索引
    var currentVideoIndex = 0;

    player.ready(function () {
        instance.invokeMethodAsync('GetInit');
        // 首次加载
        player.src(videoSources[currentVideoIndex]);
        if (options.autoplay) {
            player.play();
        }
    });
    // 监听视频播放结束事件
    player.on('ended', function () {
        currentVideoIndex++;
        if (currentVideoIndex >= videoSources.length) {
            currentVideoIndex = 0; // 如果需要循环播放则重置索引，或者移除此行以停止播放。
        }
        player.src(videoSources[currentVideoIndex]);
        player.play();
    });
    return false;
}
 
export function loadPlayer(instance, id, options) {
    console.log('player sources id:', id);
    console.log('options:', options);

    player = videojs(id, options);
    player.ready(function () {
        console.log('player.ready');

        if (options.autoplay) {
            var promise = player.play();

            if (promise !== undefined) {
                promise.then(function () {
                    console.log('Autoplay started!');
                }).catch(function (error) {
                    console.log('Autoplay was prevented.', error);
                    instance.invokeMethodAsync('Logger', 'Autoplay was prevented.' + error);
                });
            }
        } else {
            player.poster(options.poster);
        }
        instance.invokeMethodAsync('GetInit');
    });

    return false;
}

export function setPoster(poster) {
    //  获取封面和设置封面
    console.log(player.poster());
    player.poster(poster);
}

export function reloadPlayerList(videoSources) {
    if (!player.paused) {
        player.pause();
    }
    // 当前播放视频索引
    var currentVideoIndex = 0;
    // 首次加载
    player.src(videoSources[currentVideoIndex]);
    player.load();
    player.play();
    // 监听视频播放结束事件
    player.on('ended', function () {
        currentVideoIndex++;
        if (currentVideoIndex >= videoSources.length) {
            currentVideoIndex = 0; // 如果需要循环播放则重置索引，或者移除此行以停止播放。
        }
        player.src(videoSources[currentVideoIndex]);
        player.play();
    });
}

export function reloadPlayer(videoSource, type) {
    if (!player.paused) {
        player.pause();
    }

    // 获取资源
    console.log(player.currentSrc());
    // 更新资源
    player.src({ src: videoSource, type: type });
    player.load();
    player.play();
}

export function destroy(id) {
    if (undefined !== player && null !== player) {
        player = null;
        console.log('destroy');
    }
}