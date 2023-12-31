using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiAi : MonoBehaviour
{
    // Start is called before the first frame update
    public playerLogic PlayerScrpit;
    public Image HpBar;
    public Image ShieldBar;
    public TMP_Text time_text;
    public TMP_Text score;
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
        if(HpBar.fillAmount == 0)
        {
            SceneManager.LoadScene(3);
        }
        ShieldBar.fillAmount = PlayerScrpit.shield /50f;

        score.text = string.Format("{0000}", playerLogic.score);
    }

    void showTime(float curerntTime)
    {
        curerntTime += 1;
        float min = Mathf.FloorToInt(curerntTime / 60);
        float sec = Mathf.FloorToInt(curerntTime % 60);
        time_text.text = string.Format("{0:00} : {1:00}", min, sec);
    }
}
