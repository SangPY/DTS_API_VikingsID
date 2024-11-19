using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DTS_API_VikingsID.Models;
using DTS_API_VikingsID.Services;
using Newtonsoft.Json;

namespace DTS_API_VikingsID.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _statusMessage;
        private string _response;
        private string _accessToken;
        private MyIdentityResult _info;
        private readonly ApiService _apiService;
        private readonly InfoApiService _infoApiService;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public string Response
        {
            get => _response;
            set { _response = value; OnPropertyChanged(); }
        }

        public string AccessToken
        {
            get => _accessToken;
            set { _accessToken = value; OnPropertyChanged(); }
        }

        public MyIdentityResult Info
        {
            get => _info;
            set { _info = value; OnPropertyChanged(); }
        }

        public LoginViewModel()
        {
            _apiService = new ApiService();
            _infoApiService = new InfoApiService();
        }

        public async Task LoginAsync()
        {
            var result = await _apiService.LoginAsync(Username, Password);

            if (result != null && result.Success)
            {
                StatusMessage = "Login successful!";

                Response = JsonConvert.SerializeObject(result.Result);
                AccessToken = result.Result.AccessToken;
                //MessageBox.Show($"Access Token: {result.Result.AccessToken}"); a

                // Gọi API để lấy thông tin người dùng
                var identityResponse = await _infoApiService.GetMyIdentityAsync(AccessToken);
                if (identityResponse != null && identityResponse.Success)
                {
                    Info = identityResponse.Result;
                }
            }
            else
            {
                StatusMessage = "Login failed!";
            }
        }

        public async Task GetInfo()
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                var InfoResponse = await _infoApiService.GetMyIdentityAsync(AccessToken);
                if (InfoResponse != null & InfoResponse.Success)
                {
                    Info = InfoResponse.Result;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
