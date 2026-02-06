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
    public float damage;
    public float fireRate;
    public float speed;
    public float maxRange;
    public AudioManager.Sfx fireSound;

    [Header("# Resources")]
    public GameObject projectile;
    

}
