using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    /// <summary>
    /// Object that will be Purchased and placed in inventory
    /// </summary>
    public Purchasable Purchasable;
    /// <summary>
    /// Picture of item in inventory
    /// </summary>
    private Texture2D _itemPicture;
	/// Picture of item in inventory
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

    /// <summary>
    /// Action that will invoke once player clicks on inventory item
    /// if its a weapon, player will change the current weapon on the one clicked and his old weapon will be placed in inventory
    /// </summary>
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
