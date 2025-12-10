using Notes.Interfaces;
using Notes.ViewModels;

namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
    private readonly IJokeService _jokeService;

    public AllNotesPage(IJokeService jokeService, NotesViewModel viewModel)
    {
        InitializeComponent();
        _jokeService = jokeService;


        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string joke = await _jokeService.GetDailyJokeAsync();
        JokeLabel.Text = joke;
    }
}