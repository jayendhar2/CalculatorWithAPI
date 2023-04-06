using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Calculator;

public partial class ExercisePage : ContentPage
{
    public string selectedResult = "";
    List<Problem> allProblems;
    public int currentProblemNum = 0;
    public int correctNum = 0;
    public ExercisePage()
    {
        InitializeComponent();
        InitComponents();
    }

    private async void InitComponents()
    {
        HttpClientHandler _handler = new HttpClientHandler();
        // Fix way for exception-SSL connection could not be established
        _handler.ServerCertificateCustomValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };

        HttpClient client = new HttpClient(_handler) { BaseAddress = new Uri("https://10.97.5.30:5001/api/") };
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        allProblems = new List<Problem>();
        try
        {
            HttpResponseMessage response = await client.GetAsync("Exercise/loadExercises");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                allProblems = JsonSerializer.Deserialize<List<Problem>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        DisplayProblem();
    }

    private void DisplayProblem()
    {
        Button1.IsEnabled = true;
        if (currentProblemNum >= allProblems.Count())
        {
            ProNumber.Text = "Correct Answers";
            Problem.Text = correctNum.ToString();
            Problem.TextColor = Color.FromRgb(255, 0, 0);
            Problem.FontAttributes = FontAttributes.Bold;
            Problem.IsVisible = true;
            RightResult.IsVisible = false;
            WrongResult.IsVisible = false;
            PossibleResults.IsVisible = false;
            RightButton.IsVisible = false;
            WrongButtons.IsVisible = false;
            return;
        }
        ProNumber.Text = "Problem " + (currentProblemNum + 1);
        Problem currentProblem = allProblems[currentProblemNum];
        Problem.Text = currentProblem.problem.ToString();
        Problem.IsVisible = true;
        RightResult.IsVisible = false;
        WrongResult.IsVisible = false;
        PossibleResult1.Content = currentProblem.rightResult.ToString();
        PossibleResult2.Content = currentProblem.wrongResult1.ToString();
        PossibleResult3.Content = currentProblem.wrongResult2.ToString();
        PossibleResult1.IsChecked = false; PossibleResult2.IsChecked = false; PossibleResult3.IsChecked = false;
        selectedResult = "";
    }

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        if (selectedResult == "") return;
        else
        {
            if (selectedResult == allProblems[currentProblemNum].rightResult.ToString())
            {
                Button1.IsEnabled = false;
                correctNum++;
                RightResult.IsVisible = true;
                Problem.IsVisible = false;
                WrongResult.IsVisible = false;
                RightButton.IsVisible = true;
                WrongButtons.IsVisible = false;
                await Task.Delay(1000);
                currentProblemNum++;
                DisplayProblem();
            }
            else
            {
                RightResult.IsVisible = false;
                Problem.IsVisible = false;
                WrongResult.IsVisible = true;
                RightButton.IsVisible = false;
                WrongButtons.IsVisible = true;
            }
        }
    }

    private void AgainButton_Clicked(object sender, EventArgs e)
    {
        RightButton.IsVisible = true;
        WrongButtons.IsVisible = false;
        DisplayProblem();
    }

    private void SkipButton_Clicked(object sender, EventArgs e)
    {
        RightButton.IsVisible = true;
        WrongButtons.IsVisible = false;
        currentProblemNum++;
        DisplayProblem();
    }

    private void PossibleResult_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton button = sender as RadioButton;
        selectedResult = button.Content.ToString();
    }
}