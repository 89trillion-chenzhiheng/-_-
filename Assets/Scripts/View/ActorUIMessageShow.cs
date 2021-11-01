using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorUIMessageShow : MonoBehaviour
{
    // HP显示的的Text
    public Text hpShowText;
    // HP显示的Slider
    public Slider hoShowSlider;

    /// <summary>
    /// 当HP更改时刷新显示
    /// </summary>
    public void RefreshHpShowByHpChallenge(int currentHP , int maxHP)
    {
        // 刷新Text
        hpShowText.text = currentHP.ToString() + "/" + maxHP.ToString();
        // 刷新Slider
        hoShowSlider.value = (float)currentHP / (float)maxHP;
    }
}
