using UnityEngine;

public class GameEntry : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.UpdateScore(0);
    }
}
