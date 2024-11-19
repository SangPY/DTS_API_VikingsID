using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DTS_API_VikingsID.Services;

namespace DTS_API_VikingsID.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _statusMessage;
        private string _response;
        private readonly ApiService _apiService;

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

        public LoginViewModel()
        {
            _apiService = new ApiService();
        }

        public async Task LoginAsync()
        {
            var result = await _apiService.LoginAsync(Username, Password);

            if (result != null && result.Success)
            {
                StatusMessage = "Login successful!";

                Response = result.Result.AccessToken;
                //MessageBox.Show($"Access Token: {result.Result.AccessToken}"); a
            }
            else
            {
                StatusMessage = "Login failed!";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
