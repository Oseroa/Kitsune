using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XboxCtrlrInput;

public class MenuScript : MonoBehaviour
{
    public string levelToLoad;

    public GameObject playButton;
    public GameObject quitButton;

    float selectionTimer = 0.0f;
    float selectionDelay = 0.3f;

    bool playButtonActive = true;
    bool doOnce = false;

    public void Update()
    {
        if (XCI.IsPluggedIn(1))
        {
            if (playButtonActive)
            {
                if (!doOnce)
                {
                    playButton.GetComponent<Image>().color = Color.yellow;
                    quitButton.GetComponent<Image>().color = Color.white;
                    doOnce = true;
                }
                if (XCI.GetButton(XboxButton.A))
                {
                    PlayButtonPress();
                }
            }
            else if (!playButtonActive)
            {
                if (!doOnce)
                {
                    quitButton.GetComponent<Image>().color = Color.yellow;
                    playButton.GetComponent<Image>().color = Color.white;
                    doOnce = true;
                }
                if (XCI.GetButton(XboxButton.A))
                {
                    QuitButtonPress();
                }
            }

            if (XCI.GetAxis(XboxAxis.LeftStickY) != 0)
            {
                if (selectionTimer >= selectionDelay)
                {
                    if (playButtonActive) playButtonActive = false;
                    else playButtonActive = true;
                    doOnce = false;
                    selectionTimer = 0.0f;
                }
            }
        }
        if (selectionTimer < selectionDelay)
        {
            selectionTimer += Time.deltaTime;
        }
    }

    public void PlayButtonPress()
    {
        Application.LoadLevel(levelToLoad);
    }

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
