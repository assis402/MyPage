namespace MyPage.Application.Models.Pages
{
    public class TagModel
    {
        public TagModel(bool selectedToFilter, string tagName)
        {
            SelectedToFilter = selectedToFilter;
            TagName = tagName;
        }

        public bool SelectedToFilter { get; private set; }

        public string TagName { get; private set; }

        public void ToggleSelectedToFilter() => SelectedToFilter = !SelectedToFilter;
    }
}
