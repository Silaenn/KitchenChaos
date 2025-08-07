using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] Image timerImage;

    void Update()
    {
        timerImage.fillAmount = GameManager.Instance.GetPlayingTimerNormalized();
    }
}
