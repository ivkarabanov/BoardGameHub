namespace BoardGameHub.Domain.ValueObjects
{
    public struct BoardGameTitle
    {
        public BoardGameTitle(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
