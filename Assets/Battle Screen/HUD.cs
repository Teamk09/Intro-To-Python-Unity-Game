using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text NameText;
    public TMP_Text lvl;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        NameText.text = $"{unit.unitName}".ToUpper();
        lvl.text = $"LVL {unit.unitLevel}";
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void HP(int hp)
    {
        hpSlider.value = hp;
    }

}
