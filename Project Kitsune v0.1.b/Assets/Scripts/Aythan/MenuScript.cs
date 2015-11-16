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
<<<<<<< .merge_file_a01312
                    playButton.GetComponent<Image>().color = Color.yellow;
=======
                    playButton.GetComponent<Image>().color = Color.cyan;
>>>>>>> .merge_file_a03896
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
<<<<<<< .merge_file_a01312
                    quitButton.GetComponent<Image>().color = Color.yellow;
=======
                    quitButton.GetComponent<Image>().color = Color.cyan;
>>>>>>> .merge_file_a03896
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
<<<<<<< .merge_file_a01312
=======

>>>>>>> .merge_file_a03896
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
<<<<<<< .merge_file_a01312
=======

    public void MouseHover(bool playButtonHovered)
    {
        if (!XCI.IsPluggedIn(1))
        {
            if (playButtonHovered)
            {
                playButton.GetComponent<Image>().color = Color.cyan;
                quitButton.GetComponent<Image>().color = Color.white;
            }
            else
            {
                quitButton.GetComponent<Image>().color = Color.cyan;
                playButton.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void ResetButtons()
    {
        playButton.GetComponent<Image>().color = Color.white;
        quitButton.GetComponent<Image>().color = Color.white;
    }
>>>>>>> .merge_file_a03896
}
