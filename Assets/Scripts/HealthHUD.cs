using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthHUD : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;


    private void Start()
    {

    }

    public void UpdateHealth(int health)
    {
        text.text = health.ToString();
    }
}
