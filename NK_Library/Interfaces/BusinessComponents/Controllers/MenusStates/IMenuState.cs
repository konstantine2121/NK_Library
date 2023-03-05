namespace NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates
{
    public interface IMenuState
    {
        string Name { get; }

        void PerformAction();
    }
}
