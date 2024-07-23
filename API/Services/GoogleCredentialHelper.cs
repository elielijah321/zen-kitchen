using System;
using System.IO;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;

namespace Company.Function
{
    public static class GoogleCredentialHelper
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };

        public static GoogleCredential GetCredentials()
        {
            // string credentialsJson = Environment.GetEnvironmentVariable("GOOGLE_CREDENTIAL");

            string credentialsJson = "{\"type\":\"service_account\",\"project_id\":\"yoruba-exe\",\"private_key_id\":\"3e28bc9a60c6844c359c5985a642527cdce61921\",\"private_key\":\"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCkaAkHaslWeO19\\nHgeFaMQi00r1WZJDd1nM2fIvp+Sgda8ymEIAKe/Tps7xdvM1+dieC2oRnLU2rbnh\\n6ZaVp+PoeyZoqDnq0Xy6nk/0mCX7Rn+ehvf6bSD1ogmRFPsGBkCBg9yFztIe9QgB\\nLsUi5BHFDyDI9ZtQpvQals8bIjP+FdMXQh0HFlDe8Qy7McDKRaOnGNhX1wmjyhuC\\nODX00GmVhjOztphW+6MMIE78KIHMLP33Jvr5D3+sI6rKQYScCpNcKW6CAUP3v4AJ\\nAdFodAt3vGOyxShzzzURWzwYZQfhFZD4tq7Sz/ehA3om82N2ae+xb/lMDYR+Xblf\\nb8SiHKXHAgMBAAECggEABouBuILeywt7YNy+LehyznQc6tGLChaJQ6d1hcIoTt8A\\nf4IiNoF047cjS+eRXRe6MOiBa3wSlr+pw72Z2hFZ+FpWuBniXF/EmGVPB4y7DlrL\\nH9N9scGAa2bs/JKaP64mCUHnmIgYQ1U74VgsTuxHbNHiWz2z1i0fUKOqUQk2iqnh\\nYjGzMzBu5pKTzq/t4v39rx/bEwH3b+RN6KFEEnX5wsRbvWO8Wx8R+HyFnuNa/g7B\\n33iOeYwKk3vzQVgSmJX27QM5dHJNp+glhvfisWfGtBOnwKRC47COa9lzFQJoau3I\\nLPaWYMn+ZPif5vLYSHh5k0PjFJHAdz1SxgOb572nQQKBgQDcT9a8fAXoG4ktTtTG\\nNSCRRwjgsEdlY80qCCvbSuae1TUJLgpT/Uu+3UphPBiF8dwcOS3Pjvco5cyH6NuW\\nwy/fkacjBiamxQzaMK/HuP5Ha1OAq2/koeEBWlDUdyXoFmSpFRLPphPcZ7yS+Ndw\\ntyxY+XJArPr9+povzi60NbiP4QKBgQC/Cdb6aMHnJMs7ocRw7OC2bHiLu95Krba1\\nI2O2PP5HGM+xkAb04ri2mYs/WPBNWf9ATybNNQ8BW28agt/mhX5q44PqxJYETbNj\\n5VSGLGvYRqiuzHVllCsG1V97syehkvAvJpUeuIWhdTpB/BeCkBFUzmpoBL48PL6I\\nKRv7ZBgKpwKBgGlF7UJbsSbcIYx44stjj5Bb9S4IjdUw/1RaWzqKa/DxyEn+qgjA\\nPHWToHseEEnQ7HDAEdfgZNIyHK3E40kDM9kM7GScB9QgzKdmJFi3WSofauNNCEaj\\n47SVx5H+7SodqTPyUe7PWSY0m7NPHQNLQ/GwIJwvDDBYk1zMlRyfnvWBAoGAKdRv\\nvBjgDEqkLYR4TPmxIoCRzJbwT43F6de755VnYA3wvEJ7I3fZVjI8qTxCMc249E3g\\ngyJRDM0GgNmTSRiF28XBhtBQwNR6qS732QE1BABEwzGFqx5MZYynAaDy1pAkA08B\\na96fdAEFJpmaVD5TbSxdZDVVqj7qwUmvFNaP5RUCgYEAyBSw8AWD/moc0ouch+lX\\nr9Kq0sxJ6HZzilmw2EzAT4vqBH/Ovt6+WCz4gFTYfpas5SmP2gLTJexraXzdAwUV\\n/7Stn4A466L//ldkDvTLXndZxgWaR0kbmMIZpyGqPWaxC5yjjoGEu+Wu9nCBUJqI\\ncF1lqpw5atfN51T1ZhS8L1g=\\n-----END PRIVATE KEY-----\\n\",\"client_email\":\"yoruba@yoruba-exe.iam.gserviceaccount.com\",\"client_id\":\"110122233450973586117\",\"auth_uri\":\"https://accounts.google.com/o/oauth2/auth\",\"token_uri\":\"https://oauth2.googleapis.com/token\",\"auth_provider_x509_cert_url\":\"https://www.googleapis.com/oauth2/v1/certs\",\"client_x509_cert_url\":\"https://www.googleapis.com/robot/v1/metadata/x509/yoruba%40yoruba-exe.iam.gserviceaccount.com\",\"universe_domain\":\"googleapis.com\"}";

            byte[] byteArray = Encoding.ASCII.GetBytes(credentialsJson);

            using (var stream = new MemoryStream(byteArray))
            {
                // Create GoogleCredential from the stream
                return GoogleCredential.FromStream(stream)
                                        .CreateScoped(Scopes)
                                        .CreateWithUser("elijah@aremusoftwaresolutions.com");
            }
        }
    }
}