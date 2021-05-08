using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    [SerializeField] LocalizedText playText;

    public void OpenOptions()
    {
        gameObject.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void StartGame()
    {
        playText.ChangeText("MainMenuNotPlayButton");
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
