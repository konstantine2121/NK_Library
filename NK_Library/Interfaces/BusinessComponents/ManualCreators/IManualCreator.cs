namespace NK_Library.Interfaces.BusinessComponents.ManualCreators
{
    internal interface IManualCreator <T>
    {
        bool TryCreate(out T item);
    }
}
