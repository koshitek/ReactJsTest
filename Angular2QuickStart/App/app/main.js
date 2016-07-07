(function (app) {
    document.addEventListener('DOMContentLoaded', function () {
        ng.platformBrowserDynamic.bootstrap(app.AppComponent);
        ng.platformBrowserDynamic.bootstrap(app.AppComponent2);
    });
})(window.app || (window.app = {}));