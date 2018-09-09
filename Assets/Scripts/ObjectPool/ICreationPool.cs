using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс для использования шаблона "Object Pool"
/// </summary>
/// <typeparam name="T">Тип образца</typeparam>
public interface ICreationPool<T>
{
    /// <summary>
    /// Добавляет образец для сцены и родителя в иерархии 
    /// </summary>
    /// /// <typeparam name="T">Тип образца</typeparam>
    /// <param name="sample">Образец</param>
    /// <param name = "objectsParent"> Родитель</param>
    /// <param name = "createOnStart">Включать объекты на старте</param>
    void AddObject(T sample, Transform objectsParent, bool createOnStart);

    /// <summary>
    /// Инициализизация
    /// </summary>
    /// <param name="count">Количество объектов в пуле</param>
    /// <typeparam name="T">Тип образца</typeparam>
    /// <param name="sample">Образец</param>
    /// <param name = "objectsParent">Родитель</param>
    /// <param name = "createOnStart">Включать объекты на старте</param>
    void Initialize(int count, T sample, Transform objectsParent, bool createOnStart);

    /// <summary>
    /// Возвращает T
    /// </summary>
    /// <typeparam name="T">Тип образца</typeparam>
    T GetObject();
}
