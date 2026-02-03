using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;
    // UI 업데이트 이벤트
    public event Action<int> OnWeaponChanged;

    [Header("Data Reset")]
    public ItemData[] allWeaponData;


    private void Awake()
    {
        Instance = this;

        foreach (var weaponData in allWeaponData)
        {
            if (weaponData != null)
            {
                weaponData.isSelected = false;
            }
        }
    }

    public void EquipWeapon(ItemData data)
    {
        //같은 무기 또 선택시 해제 
        if (data.isSelected)
        {
            UnequipAll();
            return;
        }

        UnequipAll();
        data.isSelected = true;

        Weapon weaponObj = FindWeaponById(data.itemId);

        if (weaponObj != null)
        {
            weaponObj.gameObject.SetActive(true);
            weaponObj.Init(data);
        }
        else
        {
            GameObject newObj = new GameObject($"Weapon {data.itemId}");
            newObj.transform.parent = transform;
            newObj.transform.localPosition = Vector3.zero;
            
            Weapon newWeapon = newObj.AddComponent<Weapon>();
            newWeapon.Init(data);
        }

        // UI에 이벤트 발송
        OnWeaponChanged?.Invoke(data.itemId);
    }

    private void UnequipAll()
    {
        Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
            if (weapon.Itemdata != null) weapon.Itemdata.isSelected = false;
        }

        //아무것도 장착하지 않음
        OnWeaponChanged?.Invoke(-1);
    }

    private Weapon FindWeaponById(int itemId)
    {
        Weapon[] weapons = GetComponentsInChildren<Weapon>(true);
        foreach (Weapon weapon in weapons)
        {
            if(weapon.id == itemId) return weapon;
        }
        return null;
    }

    
}
