namespace NK_Library.Interfaces.BusinessComponents.Controllers.MenusStates
{
    internal interface IMenuContext : IMenuState
    {
        void SetNextState(IMenuState state);
    }
}
