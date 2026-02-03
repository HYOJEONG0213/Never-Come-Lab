using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptble Object/ItemData")]
public class WeaponData : ScriptableObject
{
    [Header("# Main Info")]
    public int itemId;
    public string itemName;
    public Sprite ItemIcon;

    [Header("# Specs")]
    public float baseDamage;
    public float fireRate;
    public AudioManager.Sfx fireSound;

    [Header("# Resources")]
    public GameObject projectile;
    

}
