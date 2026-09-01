using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    public GameObject msgText;
    public float timerTime = 180;
    int mintTime = 0;
    float hideTime = 0;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timerTime -= Time.deltaTime;
        mintTime = (int)(timerTime / 60);
        timerText.text = mintTime + " : " + (timerTime % 60).ToString("0");

        if (timerTime <= 0)
        {
            timerTime = 0;
            SceneManager.LoadScene(3); // Game Over
            Cursor.lockState = CursorLockMode.Confined;
        }
        hideMsg();
    }

    public void showMsg(string msg, float timer)
    {
        msgText.SetActive(true);
        msgText.GetComponent<TextMeshProUGUI>().text = msg;
        hideTime = timerTime - timer;
    }

    void hideMsg()
    {
        if(hideTime > timerTime)
        {
            msgText.SetActive(false);
        }
    }
}