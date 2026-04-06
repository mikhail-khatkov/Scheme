mergeInto(LibraryManager.library, {

    TelegramShareUrl: function (urlPtr, textPtr) {
        var url  = UTF8ToString(urlPtr);
        var text = UTF8ToString(textPtr);
        var shareUrl = 'https://t.me/share/url?url=' + encodeURIComponent(url) + '&text=' + encodeURIComponent(text);
        if (window.Telegram && window.Telegram.WebApp) {
            window.Telegram.WebApp.openTelegramLink(shareUrl);
        } else {
            window.open(shareUrl, '_blank');
        }
    }

});
