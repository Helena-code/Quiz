using System;
using UnityEngine;


[Serializable]
public class CellData
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private Sprite _sprite;

    public string Identifier
    {
        get { return _identifier; }
    }

    public Sprite Sprite
    {
        get { return _sprite; }
    }
}
