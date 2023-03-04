namespace NK_Library.Interfaces.BusinessComponents.Selectors
{
    internal interface ISelector<T>
    {
        bool Select(out T item);
    }
}
