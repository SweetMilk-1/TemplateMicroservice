/// <summary>
/// Вспомогательный класс для преобразования одного объекта в другой
/// </summary>
public sealed class Map
{
    /// <summary>
    /// Тип класса источника данных
    /// </summary>
    public Type Source { get; set; }

    /// <summary>
    /// Тип целевого класса данных
    /// </summary>
    public Type Destination { get; set; }
}