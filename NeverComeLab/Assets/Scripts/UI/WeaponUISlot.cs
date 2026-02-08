using UnityEngine;
using UnityEngine.UI;
using System;


public class WeaponUISlot : MonoBehaviour
{
    [Header("Data")]
    public WeaponData data;

    [Header("UI Reference")]
    public Button weaponButton;
    public Image icon;

    private WeaponManager weaponManager;

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

    public void Initialize(WeaponManager manager)
    {
        weaponManager = manager;
        weaponManager.OnWeaponChanged += UpdateUI;
        UpdateUI(-1);
    }


    // 메모리 누수 방지용
    private void OnDestroy()
    {
        if (weaponManager != null)
        {
            weaponManager.OnWeaponChanged -= UpdateUI;
        }
    }

    public void OnClick()
    {
        if(data != null)
        {
            weaponManager.ToggleWeapon(data);
        }
    }

    // 매니저가 무기 바뀌었다고 한다면
    private void UpdateUI(int currentEquippedId)
    {
        bool isSelected = (data.itemId == currentEquippedId);

        SetButtonColor(isSelected ? Color.gray : Color.white);
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
