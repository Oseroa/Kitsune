﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XboxCtrlrInput;

public class MenuScript : MonoBehaviour
{
    public string levelToLoad;

    public GameObject playButton;
    public GameObject quitButton;

    public Texture2D playButtonTexture;
    public Texture2D quitButtonTexture;

    float selectionTimer = 0.0f;
    float selectionDelay = 0.3f;

    bool playButtonActive = true;
    bool doOnce = false;

    public void Start()
    {
        Sprite playSprite;
        playSprite = Sprite.Create(playButtonTexture, new Rect(0, 0, 500, 245),new Vector2());
        playButton.GetComponent<Image>().sprite = playSprite;

        Sprite quitSprite;
        quitSprite = Sprite.Create(quitButtonTexture, new Rect(0, 0, 500, 236), new Vector2());
        quitButton.GetComponent<Image>().sprite = quitSprite;
    }

    public void Update()
    {
        if (XCI.IsPluggedIn(1))
        {
            if (playButtonActive)
            {
                if (!doOnce)
                {
                    playButton.GetComponent<Image>().color = Color.cyan;
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
                    quitButton.GetComponent<Image>().color = Color.cyan;
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
}
