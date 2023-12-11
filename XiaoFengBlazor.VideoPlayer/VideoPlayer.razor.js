
var player = null;

export function loadPlayer(instance, id, options) {
    
    console.log('player id', id);
    var options = {};

    // Add 'techOrder' array to the 'options' object
    options.techOrder = ['html5', 'flvjs'];

    // Add 'flvjs' object to the 'options' object with nested properties
    options.flvjs = {
        mediaDataSource: {
            isLive: true,
            cors: true,
            withCredentials: false,
        }
    };

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