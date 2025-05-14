using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnEnemyDie += ReloadLevel;
        GameEvents.OnPlayerDie += ReloadLevel;
    }

    public static void ReloadLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    void GameOver() => SceneManager.LoadScene("GameOver");
}
