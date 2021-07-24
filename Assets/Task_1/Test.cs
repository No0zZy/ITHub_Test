using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private ItemsList items;
    private void Start()
    {
        items = new ItemsList();

        items.Add("������ �������");
        items.Add("������ �������");
        items.Add("������ �������");
        items.Add("��������� �������");
        items.Add("����� �������");
        items.Add("������ �������");
        items.Add("������� �������");

        Debug.Log("���������� ���������: " + items.GetItemsCount());

        foreach (var i in items.GetAllItemsValues())
            Debug.Log(i);

        items.DeleteFirstItem();
        Debug.Log("�������� ������� ��������");
        Debug.Log("����� ���������� ���������: " + items.GetItemsCount());

        foreach (var i in items.GetAllItemsValues())
            Debug.Log(i);
    }
}
