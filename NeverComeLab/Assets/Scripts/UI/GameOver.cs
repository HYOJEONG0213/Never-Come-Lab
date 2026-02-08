using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (UIManager.Instance != null) UIManager.Instance.GameOverEffect();

            GameManager.Instance.health = GameManager.Instance.maxHealth;
            string currentScene = PlayerPrefs.GetString("CurrentScene", "Unknown Scene");

            PlayBgmForScene(currentScene);
            SceneManager.LoadScene(currentScene);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.health = GameManager.Instance.maxHealth;
            SceneManager.LoadScene("Main_Demo");
        }
    }

    void PlayBgmForScene(string currentScene)
    {
        if (currentScene == "Stage1")
        {
            AudioManager.instance.PlayBgm(AudioManager.Bgm.Stage1); //브금 시작
        }
        else if (currentScene == "Stage2")
        {
            AudioManager.instance.PlayBgm(AudioManager.Bgm.Stage2); //브금 시작
        }
    }
}
