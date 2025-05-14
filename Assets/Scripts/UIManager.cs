using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text scoreText;

    [SerializeField] private GameObject tutInfo;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        tutInfo.transform.DOScale(1.5f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutInfo.SetActive(false);
        }
    }


}
