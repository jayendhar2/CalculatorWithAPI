namespace Calculator;

public partial class ExercisePage : ContentPage
{
    public string selectedResult = "";
	public ExercisePage()
	{
		InitializeComponent();
        InitComponents();
	}

    private void InitComponents()
    {

    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
        if (selectedResult == "") return;
        else
        {
            if (selectedResult == "20")
            {
                RightResult.IsVisible = true;
                Problem.IsVisible = false;
                WrongResult.IsVisible = false;
                RightButton.IsVisible = true;
                WrongButtons.IsVisible = false;
                Thread.Sleep(100);

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

    }

    private void SkipButton_Clicked(object sender, EventArgs e)
    {

    }

    private void PossibleResult_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton button = sender as RadioButton;
        selectedResult = button.Content.ToString();
    }
}