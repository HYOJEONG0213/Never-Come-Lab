using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public WeaponUISlot[] weaponSlots;

    [Header("# UI Components")]
    public FadeScript fade;
    public GameObject menuSet;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        if(GameManager.Instance.player != null)
        {
            BindWeaponSlots(GameManager.Instance.player);
        }
    }

    private void BindWeaponSlots(Player player)
    {
        if (player.weaponManger == null) return;

        foreach (var slot in weaponSlots)
        {
            slot.Initialize(player.weaponManger);
        }
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += GameOverEffect;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= GameOverEffect;
    }

    private void Update()
    {
        if (GameManager.Instance == null || GameManager.Instance.player == null) return;

        HandleMenuInput();
        HandleWeaponInput();
    }

    private void HandleMenuInput()
    {
        if (Input.GetButtonDown("Cancel") && !GameManager.Instance.player.isDie)
        {
            if (menuSet != null)
                menuSet.SetActive(!menuSet.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.R) && !GameManager.Instance.player.isDie)
        {
            InGame_Menu.Retry();
        }
    }

    private void HandleWeaponInput()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                weaponSlots[i].OnClick();
                break;
            }
        }
    }

    public void GameOverEffect()
    {
        if (fade != null) fade.FadeOut();
    }
}