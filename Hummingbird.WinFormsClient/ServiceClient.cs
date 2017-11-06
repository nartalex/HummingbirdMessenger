using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;


using Hummingbird.Model;

namespace Hummingbird.WinFormsClient
{
    static class ServiceClient
    {
        private static HttpClient _client;

        public static void Initialize()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(@"http://localhost:12345/api/")
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string GetSHA512Hash(string input)
        {
            SHA512 shaM = new SHA512Managed();
            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            shaM.Dispose();
            return sBuilder.ToString();
        }

        public static object RegisterUser(User user)
        {
            var responce = _client.PostAsJsonAsync(@"users/register", user).Result.Content;

            try
            {
                user = responce.ReadAsAsync<User>().Result;
                Properties.Settings.Default.CurrentUserID = user.ID;
                return user;
            }
            catch (UnsupportedMediaTypeException e)
            {
                return responce.ReadAsStringAsync().Result;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return new User();
        }
    }
}
