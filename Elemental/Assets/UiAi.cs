using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiAi : MonoBehaviour
{
    // Start is called before the first frame update
    public playerLogic PlayerScrpit;
    public Image HpBar;
    public Image ShieldBar;
    public TMP_Text time_text;
    private bool timeFlow = false;
    public float timeActive = 0;

    
    void Start()
    {
        timeFlow =  true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeFlow)
        {
            if(timeActive >= 0)
            {
                timeActive += Time.deltaTime;
                showTime(timeActive);
            }
        }
        HpBar.fillAmount = PlayerScrpit.hp /100f; // Hp & shield Bar
        ShieldBar.fillAmount = PlayerScrpit.shield /50f;
    }

    void showTime(float curerntTime)
    {
        curerntTime += 1;
        float min = Mathf.FloorToInt(curerntTime / 60);
        float sec = Mathf.FloorToInt(curerntTime % 60);
        time_text.text = string.Format("{0:00} : {1:00}", min, sec);
    }
}
