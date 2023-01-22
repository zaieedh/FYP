using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    public Purchasable Purchasable;
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

    public void OnClick()
    {
        if(Purchasable.Type == PurchasableType.Weapon)
        {
            if (Purchasable.Name == "Pistol") {
                Purchasable.gameObject.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
                Purchasable.gameObject.GetComponent<Transform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                Purchasable.gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(-15.705f, -274.068f, 214.923f);
            }else if(Purchasable.Name == "Knife")
            {
                Purchasable.gameObject.GetComponent<Transform>().localScale = new Vector3(1,1,1);
                Purchasable.gameObject.GetComponent<Transform>().localPosition = new Vector3(0,0,0);
                Purchasable.gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(-180f, -180f, -180f);
            }
            WeaponManager.Instance.ChangeWeapon(Purchasable.gameObject);
        }
    }
}
