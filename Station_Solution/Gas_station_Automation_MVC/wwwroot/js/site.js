// wwwroot/js/site.js dosyanıza ekleyin
document.addEventListener('DOMContentLoaded', function () {
    const videos = document.querySelectorAll('.gallery-video-container video');

    videos.forEach(video => {
        const container = video.closest('.gallery-video-container');

        container.addEventListener('mouseenter', () => {
            video.play();
        });

        container.addEventListener('mouseleave', () => {
            video.pause();
            video.currentTime = 0;
        });
    });
});