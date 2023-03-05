namespace NK_Library.Interfaces.BusinessComponents.ManualCreators
{
    internal interface IManualCreator <T>
    {
        /// <summary>
        /// Создать объект через консоль.
        /// </summary>
        /// <param name="item">Созданный объект.</param>
        /// <returns>false если пользователь отменил ввод данных.</returns>
        bool TryCreate(out T item);
    }
}
