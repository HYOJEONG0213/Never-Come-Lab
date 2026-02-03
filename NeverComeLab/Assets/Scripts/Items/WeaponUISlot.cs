using UnityEngine;
using UnityEngine.UI;
using System;


public class Item : MonoBehaviour
{
    public ItemData data;

    [Header("UI Reference")]
    public Button weaponButton;
    Image icon;


    private void Awake()
    {
        weaponButton = GetComponent<Button>();
        Image[] images = GetComponentsInChildren<Image>();
        if(images.Length> 1)
        {
            icon = images[1];
            icon.sprite = data.ItemIcon;
        }
    }

    private void Start()
    {
        if (WeaponManager.Instance != null)
        {
            WeaponManager.Instance.OnWeaponChanged += UpdateUI;
            UpdateUI(data.isSelected ? data.itemId : -1);
        }
    }

    private void OnDestroy()
    {
        if (WeaponManager.Instance != null)
        {
            WeaponManager.Instance.OnWeaponChanged -= UpdateUI;
        }
    }

    public void OnClick()
    {
        if(data.itemType == ItemData.ItemType.Weapon0 || data.itemType == ItemData.ItemType.Weapon1)
        {
            WeaponManager.Instance.EquipWeapon(data);
        }
    }

    // 매니저가 무기 바뀌었다고 한다면
    private void UpdateUI(int equippedWeaponId)
    {
        bool isEquipped = (data.itemId == equippedWeaponId);
        SetButtonColor(isEquipped ? Color.gray : Color.white);
    }

    private void SetButtonColor(Color color)
    {
        ColorBlock cb = weaponButton.colors;
        cb.normalColor = color;
        cb.selectedColor = color;
        cb.highlightedColor = color;
        weaponButton.colors = cb;
    }

}
