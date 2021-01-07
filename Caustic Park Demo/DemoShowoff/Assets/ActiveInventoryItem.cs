using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActiveInventoryItem<T> : ISerializationCallbackReceiver
{
    public List<T> _items;
    public int _selectedItem;

    public T item
    {
        get {
            if (_selectedItem < _items.Count)
            {
                return _items[_selectedItem];
            }
            return default;
        }

        set {
            if (_items.Contains(value))
            {
                _selectedItem = _items.IndexOf(value);
                return;
            }
            _items.Add(value);
            _selectedItem = _items.Count - 1;
        }
    }

    public bool rotate(bool backwards = false)
    {
        if (_items.Count <= 1)
        {
            return false;
        }
        int dir = backwards ? -1 : 1;
        _selectedItem = (_selectedItem + dir) % _items.Count;
        if (_selectedItem < 0)
        {
            _selectedItem = _items.Count + _selectedItem;
        }
        return true;
    }
    public bool remove(T item)
    {
        return _items.Remove(item);
    }

    public T this[int i]
    {
        get { return _items[i]; }
        set { _items[i] = value; }
    }

    public int count
    {
        get { return _items.Count; }
    }

    public bool contains(T item)
    {
        return _items.Contains(item);
    }

    public void OnBeforeSerialize()
    {

    }
    public void OnAfterDeserialize()
    {

    }
}
