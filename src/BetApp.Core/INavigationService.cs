namespace BetApp.Core
{
    public interface INavigationService
    {
        void Push(PagesEnum page, params object[] parameters);
        void Pop();
    }
}
