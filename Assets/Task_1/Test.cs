using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private ItemsList items;
    private void Start()
    {
        items = new ItemsList();

        items.Add("Первый элемент");
        items.Add("Второй элемент");
        items.Add("Третий элемент");
        items.Add("Четвертый элемент");
        items.Add("Пятый элемент");
        items.Add("Шестой элемент");
        items.Add("Седьмой элемент");

        Debug.Log("Количество элементов: " + items.GetItemsCount());

        foreach (var i in items.GetAllItemsValues())
            Debug.Log(i);

        items.DeleteFirstItem();
        Debug.Log("Удаление первого элемента");
        Debug.Log("Новое количество элементов: " + items.GetItemsCount());

        foreach (var i in items.GetAllItemsValues())
            Debug.Log(i);
    }
}
