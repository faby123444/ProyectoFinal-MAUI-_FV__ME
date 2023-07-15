using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace ProyectoFinal_MAUI__FV__ME
{
    public partial class JokePage : ContentPage
    {
        private JokeService jokeService;
        public JokePage()
        {
            InitializeComponent();
            jokeService = new JokeService();
        }

        private async void JokeButton_Clicked(object sender, EventArgs e)
        {
            string joke = await jokeService.GetJoke();
            contentLabel.Text = joke;
        }
    }
}