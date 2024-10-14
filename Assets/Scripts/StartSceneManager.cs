using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public Image playerImage;
    public InputField inputName;
    public Button startBtn;
    public Button choiceBtn;

    GameObject ChoiceCharacterPanel;
    public Button KnightBtn;
    public Button SamuraiBtn;
    string playerCharacter;

    void Awake()
    {
        playerCharacter = "Knight";
        ChoiceCharacterPanel = transform.Find("ChoiceCharacterPanel").gameObject;
    }

    void Start()
    {
        startBtn.onClick.AddListener(OnStartButtonClicked);
        choiceBtn.onClick.AddListener(ChangeImageButtonClicked);
        KnightBtn.onClick.AddListener(ChoiceKnight);
        SamuraiBtn.onClick.AddListener(ChoiceSamurai);
    }

    void ChangeImageButtonClicked()
    {
        ChoiceCharacterPanel.SetActive(true);
    }

    void ChoiceKnight()
    {
        ChangeImage("Knight");
    }

    void ChoiceSamurai()
    {
        ChangeImage("Samurai");
    }

    void ChangeImage(string character)
    {
        ChoiceCharacterPanel.SetActive(false);
        playerCharacter = character;
        playerImage.sprite = Resources.Load<Sprite>(character);
    }

    public void OnStartButtonClicked()
    {
        string playerName = inputName.text;

        if (IsValidName(playerName))
        {
            PlayerData.PlayerName = playerName;
            PlayerData.PlayerCharacter = playerCharacter;
            SceneManager.LoadScene("MainScene");
        }
    }
    
    public static bool IsValidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Contains(" "))
            return false;

        if (name.Length < 2 || name.Length > 10)
            return false;

        return true;
    }
}
