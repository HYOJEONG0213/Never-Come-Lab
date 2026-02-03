using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;
    // UI 업데이트 이벤트
    public event Action<int> OnWeaponChanged;
    private int currentWeaponId = -1;
    private Dictionary<int, WeaponController> createdWeapons = new Dictionary<int, WeaponController>();

    private void Awake()
    {
        Instance = this;
    }

    public void ToggleWeapon(WeaponData data)
    {
        //같은 무기 또 선택시 해제 
        if (currentWeaponId == data.itemId)
        {
            UnequipCurrent();
            return;
        }

        Equip(data);
    }

    private void Equip(WeaponData data)
    {
        UnequipCurrent();

        if (!createdWeapons.ContainsKey(data.itemId))
        {
            CreateWeaponObject(data);
        }

        WeaponController weapon = createdWeapons[data.itemId];
        weapon.gameObject.SetActive(true);
        weapon.Init(data);

        currentWeaponId = data.itemId;
        OnWeaponChanged?.Invoke(currentWeaponId);
    }
    public void UnequipCurrent()
    {
        if (currentWeaponId != -1 && createdWeapons.ContainsKey(currentWeaponId))
        {
            createdWeapons[currentWeaponId].gameObject.SetActive(false);
        }

        currentWeaponId = -1;
        OnWeaponChanged?.Invoke(-1);
    }

    private void CreateWeaponObject(WeaponData data)
    {
        GameObject newWeapon = new GameObject($"Weapon_{data.itemName}");
        newWeapon.transform.parent = transform;
        newWeapon.transform.localPosition = Vector3.zero;

        WeaponController newCtrl = newWeapon.AddComponent<WeaponController>();
        createdWeapons.Add(data.itemId, newCtrl);
    }
    
}
