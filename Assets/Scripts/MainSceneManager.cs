using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public GameObject knightPrefab;
    public GameObject samuraiPrefab;
    public CameraMovement followCamera;

    void Start()
    {
        string playerName = PlayerData.PlayerName;
        string playerCharacter = PlayerData.PlayerCharacter;

        GameObject characterPrefab = null;

        if (playerCharacter == "Knight")
        {
            characterPrefab = knightPrefab;
        }
        else if (playerCharacter == "Samurai")
        {
            characterPrefab = samuraiPrefab;
        }

        if (characterPrefab != null)
        {
            GameObject playerCharacterObject = Instantiate(characterPrefab);
            playerCharacterObject.name = playerName;

            Text nameText = playerCharacterObject.GetComponentInChildren<Text>();
            nameText.text = playerName;

            playerCharacterObject.transform.position = Vector3.zero;
            followCamera.SetTarget(playerCharacterObject.transform);
        }
        else
        {
            Debug.LogError("캐릭터를 찾을 수 없습니다: " + playerCharacter);
        }
    }
}
