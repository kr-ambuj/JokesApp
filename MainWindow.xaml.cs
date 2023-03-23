using JokesApp.DataServices;
using JokesApp.JokesModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace JokesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DadJokesClass DadJokes;
        public MainWindow()
        {
            InitializeComponent();
            DadJokes = new DadJokesClass();
        }

        private async void _btnGetRandomJoke_Click(object sender, RoutedEventArgs e)
        {
            _btnGetJokeWithSearchString.IsEnabled = false;
            string result = await DadJokes.GetARandomJoke();
            _txtDisplayJoke.Text = result;
            _btnGetJokeWithSearchString.IsEnabled = true;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _btnGetRandomJoke.IsEnabled = false;
            string result = await DadJokes.GetJokesWithSearchString(_txtSearchString.Text);
            if (!string.IsNullOrEmpty(_txtSearchString.Text))
                result = result.Replace(_txtSearchString.Text, _txtSearchString.Text.ToUpper());
            var jsonData = JsonConvert.DeserializeObject<JokeModelClass>(result);

            if (jsonData.TotalJokes == 0)
                _txtDisplayJoke.Text = $"{jsonData.TotalJokes} jokes found from API.";
            else
            {
                string textData = ReformatData(jsonData);
                _txtDisplayJoke.Text = textData;
            }

            _btnGetRandomJoke.IsEnabled = true;
        }

        private string ReformatData(JokeModelClass? jsonData)
        {
            List<string> shortJokeList = new List<string>();
            List<string> mediumJokeList = new List<string>();
            List<string> longJokeList = new List<string>();
            foreach (var item in jsonData.Results)
            {
                int jokeLength = item.Joke.Split(' ').Length;
                if (jokeLength < 10)
                    shortJokeList.Add(item.Joke);
                else if (jokeLength < 20)
                    mediumJokeList.Add(item.Joke);
                else
                    longJokeList.Add(item.Joke);
            }
            StringBuilder sb = new StringBuilder();
            if (shortJokeList.Count > 0)
            {
                sb.AppendLine("Short Jokes");
                foreach (var item in shortJokeList)
                    sb.AppendLine(item);
            }
            if (mediumJokeList.Count > 0)
            {
                sb.AppendLine("\nMedium Jokes");
                foreach (var item in mediumJokeList)
                    sb.AppendLine(item);
            }
            if (longJokeList.Count > 0)
            {
                sb.AppendLine("\nLong Jokes");
                foreach (var item in longJokeList)
                    sb.AppendLine(item);
            }
            shortJokeList.Clear();
            mediumJokeList.Clear();
            longJokeList.Clear();
            return sb.ToString();
        }
    }
}
