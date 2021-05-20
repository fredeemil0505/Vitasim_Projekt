using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winnerscript : MonoBehaviour
{
    public GameObject MainMenu;
    public Text text;
    private void Awake()
    {
        if (StopButtonTrigger.winner)
        {
            StopButtonTrigger.winner = false;
            this.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(false);
            text.text = StopButtonTrigger.timeSpent.ToString();
        }
    }
}
