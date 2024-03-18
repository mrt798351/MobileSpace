using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;

    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt(EndGameManager.endManager.lvlUnlock, firstLevelBuildIndex);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + firstLevelBuildIndex <= unlockedLvl)
            {
                levelButtons[i].interactable = true;
                levelButtons[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = levelButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
            }
            else
            {
                levelButtons[i].interactable = false;
                levelButtons[i].image.sprite = lockedIcon;
                levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }
}
