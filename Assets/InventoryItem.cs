using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    private Texture2D _itemPicture;
    public Texture2D itemPicture
    {
        get
        {
            return _itemPicture;
        }

        set
        {
            if (value == null)
                return;
            _itemPicture = value;
            GetComponent<Image>().sprite = Sprite.Create(_itemPicture, new Rect(0, 0, _itemPicture.width, _itemPicture.height),new Vector2(0,0));
        }
    }
}
