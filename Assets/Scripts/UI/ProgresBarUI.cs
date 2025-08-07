using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBarUI : MonoBehaviour
{
    [SerializeField] GameObject hasProgressGameObject;
    [SerializeField] Image barImage;

    IHasProgress hasProgress;

    void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        if (hasProgress == null)
        {
            Debug.LogError("Game Object " + hasProgressGameObject + " does not have a component that implements IHasProgress");
        }

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        barImage.fillAmount = 0f;

        Hide();
    }

    void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0 || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
