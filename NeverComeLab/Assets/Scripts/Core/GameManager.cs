using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    private int killedMonsters = 0;

    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100 ;

    public static event Action OnGameOver;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Instance.player = this.player;
            Instance.pool = this.pool;
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void RegisterPlayer(Player newPlayer)
    {
        player = newPlayer; 
    }

    public bool ApplyDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GameOver();
            return true;
        }
        return false;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        Invoke("LoadGameOverScene", 2f);
    }
    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void IncrementKilledMonsters()
    {
        killedMonsters++;
    }
}
