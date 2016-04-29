(function () {
    "use strict";
    angular
        .module("tripGallery")
        .controller("tripIndexController",
                     ["tripResource", "OidcManager",
                         TripIndexController]);

    function TripIndexController(tripResource, OidcManager) {
        var vm = this;
       
        vm.mgr = OidcManager.OidcTokenManager();

        vm.loadTrips = function()
        {
            tripResource.query(
                   // no query params
                   null,
                   // success
                   function (data) {
                       vm.trips = data;
                   },
                   // failure
                   null);
        };
   
        vm.loadTrips();
        
    }
}());
