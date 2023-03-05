namespace NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates
{
    internal interface IMenuContext : IMenuState
    {
        bool InvalidState { get; }

        void SetNextState(IMenuState state);
    }
}
