angular.module('Service', ['ajaxApp', 'ngMaterial']).directive('selection', ['ajaxService', function (ajaxService,scope) {
    return {
        restrict: 'E',
        template: '<div><md-select placeholder="Select" ng-model="paramValue" ng-change="loadFunction({paramPass:paramValue})" class="width-control-center-domain"><md-option ng-value="result.id" ng-repeat="result in results">{{result.value}}</md-option></md-select></div>',
        scope: {
            paramValue: '=',
            loadFunction: '&'
        },
        link: function ($scope, element) {
            
            $scope.results = [];
            //$scope.paramOnly = null;                      
            var option = {
                url: "<url>",
                type: "GET",
                postInfo:" ",
                params:{}
            }
            ajaxService.ajaxData(option).then(function (x) {
                var data = angular.fromJson(x.data.d);
                $scope.results = data;
             
            });
        }
    };
}]);


<!--<selection-selection param-value="vm.paramValue" load-function="vm.loadFunction(domainid)"></selection>-->
