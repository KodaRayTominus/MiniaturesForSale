var formSchema =  {"components":[{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"Card Number","key":"cardNumber","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"4032030376024569","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"Name on Card","key":"nameonCard","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"Khademul Basher","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"Expiration Date","key":"expirationDate","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"01/2022","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"CVC","key":"cvc","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"000","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"tableView":true,"label":"Country","key":"country","placeholder":"","data":{"values":[{"value":"US","label":"United State"}],"json":"","url":"","resource":"","custom":""},"dataSrc":"values","valueProperty":"","defaultValue":"","refreshOn":"","filter":"","authenticate":false,"template":"<span>{{ item.label }}</span>","multiple":false,"protected":false,"unique":false,"persistent":true,"validate":{"required":false},"type":"select","tags":[],"conditional":{"show":"","when":null,"eq":""}},{"input":true,"tableView":true,"label":"State","key":"state","placeholder":"","data":{"values":[{"value":"OH","label":"OH"}],"json":"","url":"","resource":"","custom":""},"dataSrc":"values","valueProperty":"","defaultValue":"","refreshOn":"","filter":"","authenticate":false,"template":"<span>{{ item.label }}</span>","multiple":false,"protected":false,"unique":false,"persistent":true,"validate":{"required":false},"type":"select","tags":[],"conditional":{"show":"","when":null,"eq":""}},{"input":true,"tableView":true,"label":"City","key":"city","placeholder":"","data":{"values":[{"value":"Johnstown","label":"Johnstown"}],"json":"","url":"","resource":"","custom":""},"dataSrc":"values","valueProperty":"","defaultValue":"","refreshOn":"","filter":"","authenticate":false,"template":"<span>{{ item.label }}</span>","multiple":false,"protected":false,"unique":false,"persistent":true,"validate":{"required":false},"type":"select","tags":[],"conditional":{"show":"","when":null,"eq":""}},{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"Street","key":"street","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"52 N Main ST","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"Postal Code","key":"postalCode","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"43210","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"tableView":true,"inputType":"text","inputMask":"","label":"Email","key":"email","placeholder":"","prefix":"","suffix":"","multiple":false,"defaultValue":"khademulbasher-buyer@gmail.com","protected":false,"unique":false,"persistent":true,"validate":{"required":false,"minLength":"","maxLength":"","pattern":"","custom":"","customPrivate":false},"conditional":{"show":"","when":null,"eq":""},"type":"textfield","tags":[]},{"input":true,"label":"Submit","tableView":false,"key":"submit1","size":"md","leftIcon":"","rightIcon":"","block":false,"action":"submit","disableOnInvalid":false,"theme":"primary","type":"button","tags":[],"conditional":{"show":"","when":null,"eq":""}}],"display":"form","page":0,"numPages":1};

    var app = angular.module('paypalApp', [
          'ui.bootstrap',
          'ui.select',
          'formio',
          'ngFormBuilder',
          'ngJsonExplorer',
          'ngFileUpload'
    ]);

    app.controller('paypalAppCtrl', ['$scope', '$http', '$rootScope', 'Upload', '$compile', 'formioComponents', '$timeout', function ($scope, $http, $rootScope, Upload, $compile, formioComponents, $timeout) {
        $rootScope.form = formSchema;

        $rootScope.displays = [{
            name: 'form',
            title: 'Form'
        }, {
            name: 'wizard',
            title: 'Wizard'
        }];

        $rootScope.renderForm = true;
        $rootScope.$on('formUpdate', function (event, form) {
            angular.merge($rootScope.form, form);
            $rootScope.renderForm = false;
            setTimeout(function () {
                $rootScope.renderForm = true;
            }, 10);
        });

        var originalComps = _.cloneDeep($rootScope.form.components);
        $rootScope.jsonCollapsed = true;
        $timeout(function () {
            $rootScope.jsonCollapsed = false;
        }, 200);

        $scope.$on('formSubmission', function (err, submission) {

            var cardInput = JSON.stringify(submission.data, null, "  ");
            $.ajax({
                type: "GET",
                url: "http://localhost:56863/api/PayPal?cardData=" + cardInput,
                dataType: 'jsonp',
                jsonpCallback: 'apiStatus',
                success: function (msg) {
                    alert("Payment Id: " + JSON.parse(msg.items[0].response).id);
                    console.log( JSON.parse(msg.items[0].response));
                },
                error: function (request, status, error) {
                    alert("error");
                }
            });
            
        });
        
    }]);
