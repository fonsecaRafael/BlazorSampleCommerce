namespace BlazorSampleCommerce.Services;

public class SearchService
{
    public string SelectedBrand { get; private set; } = "";

    public event Action? OnSearchChanged;

    public void UpdateBrand(string brand)
    {
        SelectedBrand = brand;
        OnSearchChanged?.Invoke();
    }
}