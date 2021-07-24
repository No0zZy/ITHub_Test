using System.Collections;
using System.Collections.Generic;

public class ItemsList
{
    private Item firstItem;

    public ItemsList()
    {

    }
    public ItemsList(string firstItemValue)
    {
        Add(firstItemValue);
    }
    public ItemsList(string[] itemsValues)
    {
        foreach (var i in itemsValues)
            Add(i);
    }

    public void Add(string value)
    {
        if (firstItem == null)
        {
            firstItem = new Item(value);
            return;
        }

        Item lastItem = GetLastItem();
        lastItem.NextItem = new Item(value);
    }

    private Item GetLastItem()
    {
        if (firstItem == null)
            return null;

        Item lastItem = firstItem;
        while(lastItem.NextItem != null)
            lastItem = lastItem.NextItem;

        return lastItem;
    }

    public void DeleteFirstItem()
    {
        if (firstItem == null)
            return;

        if (firstItem.NextItem != null)
            firstItem = firstItem.NextItem;
        else
            firstItem = null;
    }

    public int GetItemsCount()
    {
        int i = 0;

        if (firstItem == null)
            return i;

        i++;
        Item lastItem = firstItem;
        while (lastItem.NextItem != null)
        {
            i++;
            lastItem = lastItem.NextItem;
        }

        return i;
    }

    public string[] GetAllItemsValues()
    {
        string[] allItemsValues;

        int count = GetItemsCount();
        allItemsValues = new string[count];

        if (count == 0)
            return allItemsValues;

        Item lastItem = firstItem;

        for(int i = 0; i < count; i++)
        {
            allItemsValues[i] = lastItem.Value;
            lastItem = lastItem.NextItem;
        }

        return allItemsValues;
    }
}
