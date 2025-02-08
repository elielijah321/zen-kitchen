using AremuCoreServices.Models.CredentialRecords;
using Google.Apis.Sheets.v4;

namespace Company.Function
{
    public static class GetGoogleCredentials
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };

        public static string SpreadsheetId = "1jprjTBJcZgMsBYtUdPbfejCze4o5W5jeM_sB8g0aXgw";


        public static GoogleCredentialsRecord Get()
        {

            string credentialsJson = "{\"type\":\"service_account\",\"project_id\":\"aremusoftwaresolutions\",\"private_key_id\":\"6386ab5de8b6b7a4a5d80395e5eafde726ae8862\",\"private_key\":\"-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDpJY/AgBabwiUA\noqRubH5QB37I6JzgdnhrlWdO3OsElftxjPrMHNm5W6Q4aWkQXSSVkdAsMZ/+Z3Lt\nGoSAtkcaYjK+CeCthHAHYBUVNaSEXs0wdU0Yd6OE9rXOA2FDjnE0h26w467i4aQH\nA/J6BSHw4ooSHxW8WxqMKcvE+CX0IcIj0M+DwJH5nZZH3/JYxVCCQDIG9UG9w6ON\nw+cSDzOwo0Lx0kohSZ7vUxJWDUOp/r84u1QHpYyaM09RBFVLhx9F6OvlwFgH+D2k\nVWgrPvuv10Vy2xX+viO1hIv2d4Rg8iJEmpJGqgYayLbnk0pP2XmS+3xfOeYYP3Hp\nh+IIq37jAgMBAAECggEAPtJTMMCS1vdyNwCcI/Dx/Ch43jPniYgCnKKOSq62WO78\n6LTfIz6m4A40asrkd3dRk0fN+wqIHOnNCtx5VaFH+XD6UUCiHL8x3JrkM2nX4Z8V\n1PfWhUA/fGVpyZAZljV8hXX0uo8vIY1BQG6s2HonkhvIrmdX2QAHYDsm3/UpbOVj\n/5U66YrLKD/sStRvRh33+xeHfGqKu4NrY7z9FXRw/d49uE1kwEOUqr/rd9vO6mo1\nik3xLu19lpDXhx34651IWsqeblj6bwZqJTsCUyegHBJcXppcLTQaMUllQpYmVBOU\nkmhQ3DhCQAPEiL0jrm0/sBqH9bIjDBllgdeUD8p44QKBgQD+rte1DI0oM3aGuddQ\nzrtgOq3POOAlGofAnv77v1VXLkOoeoV/psYbSrnlD5ARJZi0qfW11za/qBGSTVEG\nNZaoMvxn+HWJY6nDKo6V76goFozcj9xgUtLwFJxCZMnq6Nj7PbyPdQyNLl3dh+qZ\nm2bqKCq/FOBoj7FElulAcXsVcwKBgQDqWjVjfVZXKNEoteACYnzlsiyfx5KudfGM\nSF5qHugZkMeq9J+neT9os/iT2ATcuLdIQ2y+wELH15TxiYN/bJk87QtCi+zmVGM4\nkEm7+kvJeEn7n9l0t6vyNozGeWeJk8nfzc8pj6cXaebkCTgLKDS3CDRgGfFzPLr6\nYJfn8/YU0QKBgQD3EfNdRnHiIBrKFJvXXtbUQdjAATMhi51KtnQzEajezJkCZun/\nrnDdpR62IuTmXYzJJ2ChKcmJIKj7P1ptJaukPOI0kwqjYDYeibiNqFN/oHDCwCVQ\npMjR84yrtE9WPtHQ2lGE8k5c4DBbazGiFuo+Gv1tJfmWNmAIZEagJ/b6FQKBgQCU\nA0WVAKR3iCASRkylNO8NY+srPzE1XuigYVTAUaTmALsbDkWH0NxrlL97IQRxI3ke\n+vbDw0pqTY6UvvV+lWhzQoPKE/Ybw1CnePoY74zOQlr3wY3mWdsPr8RZ1nO+QMlP\nwP0GkuRFtW1OuUPcSBiDQXtS9w+4aLLvT/KhXUQfAQKBgQC8EJQiFTdcJXDMhMlC\niHyoEbWl8gBJHhbKMYeqT/Ig3pnnOSB+HBNHPdoFwwxI4lw2cBWxaalKEGlnYgsj\ndsorWExuB/ru+nISQWR8yp4lyHHfEEfJJ5ebPygOJam6XyfIDE/hFp8AncLi2tpT\nGazMhbpFyzxFWXWuAkxELo0dPA==\n-----END PRIVATE KEY-----\n\",\"client_email\":\"aremu-software@aremusoftwaresolutions.iam.gserviceaccount.com\",\"client_id\":\"103275707152368667426\",\"auth_uri\":\"https://accounts.google.com/o/oauth2/auth\",\"token_uri\":\"https://oauth2.googleapis.com/token\",\"auth_provider_x509_cert_url\":\"https://www.googleapis.com/oauth2/v1/certs\",\"client_x509_cert_url\":\"https://www.googleapis.com/robot/v1/metadata/x509/aremu-software%40aremusoftwaresolutions.iam.gserviceaccount.com\",\"universe_domain\":\"googleapis.com\"}";
            
            var result = new GoogleCredentialsRecord(credentialsJson, "mrelijaha@gmail.com", Scopes, "Zen Kitchen MCR");
        
            return result;
        }
    }
}