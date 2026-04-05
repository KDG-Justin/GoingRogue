using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthRate = 1.5f; // 50% increase per level
    public Slider expBar;
    public TMP_Text levelText;

    void Start()
    {
        UpdateUI();
    }
    public void AddExperience(int amount)
    {
        currentExp += amount;
        CheckLevelUp();
        UpdateUI();
    }

    private void CheckLevelUp()
    {
        while (currentExp >= expToLevel)
        {
            currentExp -= expToLevel;
            level++;
            expToLevel = Mathf.RoundToInt(expToLevel * expGrowthRate);
            Debug.Log("Level Up! Current Level: " + level);
        }
    }

    public void UpdateUI()
    {
        expBar.maxValue = expToLevel;
        expBar.value = currentExp;
        levelText.text = "Level: " + level;
    }

}