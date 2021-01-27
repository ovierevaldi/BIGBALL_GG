using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text TextTimer;
    public float Waktu = 60;
    public Canvas gameover;

    public bool gameaktif = true;

    void SetText()
    {
        int detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = detik.ToString("00");
    }

    float s;

    private void Update()
    {
        if (gameaktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }

        if(gameaktif && Waktu <= 0)
        {
            Debug.Log("gameover");
            gameaktif = false;
            gameover.enabled = true;
        }

        SetText();

    }
}
