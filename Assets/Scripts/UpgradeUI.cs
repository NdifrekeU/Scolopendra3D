using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeNameText, upgradeDescText;
    private UpgradeData upgradeData;

    // Start is called before the first frame update
    public void Init(UpgradeData data)
    {
        upgradeData = data;
        upgradeNameText.text = data.upgradeName;
        upgradeDescText.text = data.upgradeDesc;

        GetComponent<Button>().onClick.AddListener(() => ApplyUpgrade());
    }

    public void ApplyUpgrade()
    {
        UpgradeManager.Instance.ApplyUpgrade(upgradeData.upgradeStatType, upgradeData.increment);
        GameEvents.OnUpgrade?.Invoke();
    }

}
