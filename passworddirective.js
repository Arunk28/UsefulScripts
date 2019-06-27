angular.module("passwordModule", []).directive('passwordVerify', function () {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, elem, attrs, ngModel) {
            if (!ngModel) return;
            scope.$watch(attrs.ngModel, function () {
                validate();
            });
            attrs.$observe('passwordVerify', function (val) {
                validate();
            });
            var validate = function () {

                var val1 = ngModel.$viewValue;
                var val2 = attrs.passwordVerify;

                ngModel.$setValidity('passwordVerify', val1 === val2);
            };
        }
    }
    
    
    //<index.Html
    //<input id="ConfirmPassword" name="confirmPassword" type="password" ng-model="Password" required password-verify="{{ac.Password}}" />
    //<div ng-messages for="ac.form_name.confirmPassword.$error">
    //<div ng-message="passwordVerify">Those passwords didn't match. Try again.</div>
    //</div>
