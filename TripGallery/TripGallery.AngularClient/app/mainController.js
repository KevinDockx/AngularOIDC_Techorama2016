(function () {
    "use strict";
    angular
        .module("tripGallery")
        .controller("mainController",
                     ["OidcManager", MainController]);
       

     function MainController(OidcManager) {
        var vm = this;
      
        vm.mgr = OidcManager.OidcTokenManager();

         vm.logOutOfIdSrv = function () {
                    vm.mgr.redirectForLogout();
                } 

        // no token or expired => start flow
        if (vm.mgr.expired) {
            vm.mgr.redirectForToken();
        } 
    }

}());
