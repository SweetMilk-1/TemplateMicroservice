namespace TemplateMicroservice.DAL.Entities;

/// <summary>
/// Класс Person
/// </summary>
public class Person
{
    /// <summary>
    /// Уникальный ID
    /// </summary>
    public int Id { get; set; } 

    /// <summary>
    /// Имя человека
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age { get; set; }
}
