# UsefulScripts
repo contains common and useful scripts in a re-usable form

## ajaxService.js Usage 

var app = angular.module('module-name', ['ajaxApp']);  
app.controller('controller-name', ["ajaxService", function (ajaxService)  
{   
var options = {
                url: "url of service",
                type: http method type,
                postInfo: post-data                
            };  
            ajaxService.ajaxData(options).then(function (x) {
                var data = angular.fromJson(x.data.d);              
            },  
              function (err) {
                    console.log(err);                    
                }  
            );    
}]);
