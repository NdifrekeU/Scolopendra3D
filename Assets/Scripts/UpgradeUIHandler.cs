using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class UpgradeUIHandler : MonoBehaviour
{
    [SerializeField] private UpgradeUI upgradeUIsPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private UpgradeData[] upgradeDatas;
    private UpgradeUI[] upgradeUIs = new UpgradeUI[3];
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.DoShowUpgradeUI += ShowUpgradeUI;
        GameEvents.OnDestroyBodyPart += TrackPlayerProgress;
    }
    int progress = 0;
    private void TrackPlayerProgress()
    {
        progress++;
        if (progress >= 2)
        {
            upgradePanel.SetActive(true);
            GameEvents.DoShowUpgradeUI?.Invoke();
            progress = 0;
        }

        GameEvents.OnUpgrade += HideUpgradeUI;
    }

    private void ShowUpgradeUI()
    {
        for (int i = 0; i < 3; i++)
        {
            int x = Random.Range(0, upgradeDatas.Length);
            UpgradeUI upgradeUI = Instantiate(upgradeUIsPrefab, parent);
            upgradeUIs[i] = upgradeUI;
            upgradeUI.Init(upgradeDatas[x]);
        }
    }

    private void HideUpgradeUI()
    {
        upgradePanel.SetActive(false);

        foreach (var child in upgradeUIs)
        {
            child.gameObject.SetActive(false);
        }
    }

}
