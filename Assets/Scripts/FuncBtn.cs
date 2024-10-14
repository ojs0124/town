using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuncBtn : MonoBehaviour
{
    public GameObject HiddenNCPanel; // 닉네임 변경 패널
    public GameObject HiddenCCPanel; // 캐릭터 선택 패널
    public Button changeNicknameButton; // 닉네임 변경 버튼
    public Button changeCharacterButton; // 캐릭터 변경 버튼
    public InputField inputName;
    public Button nameChangeBtn;
    public Button knightBtn;
    public Button samuraiBtn;

    public GameObject knightPrefab;
    public GameObject samuraiPrefab;
    private GameObject currentPlayer;

    void Start()
    {
        changeNicknameButton.onClick.AddListener(OnChangeNicknameButtonClicked);
        changeCharacterButton.onClick.AddListener(OnChangeCharacterButtonClicked);
        nameChangeBtn.onClick.AddListener(NameChangeBtnClicked);
        knightBtn.onClick.AddListener(knightBtnClicked);
        samuraiBtn.onClick.AddListener(samuraiBtnClicked);

        currentPlayer = GameObject.Find(PlayerData.PlayerName);
    }

    private void OnChangeNicknameButtonClicked()
    {
        HiddenNCPanel.SetActive(true);
    }

    private void OnChangeCharacterButtonClicked()
    {
        HiddenCCPanel.SetActive(true);
    }

    private void NameChangeBtnClicked()
    {
        string playerName = inputName.text;

        if (StartSceneManager.IsValidName(playerName))
        {
            GameObject player = GameObject.Find(PlayerData.PlayerName);
            Text nameText = player.GetComponentInChildren<Text>();
            nameText.text = playerName;
            inputName.text = null;
            HiddenNCPanel.SetActive(false);
        }
    }

    private void knightBtnClicked()
    {
        ChangeCharacter(knightPrefab);
    }

    private void samuraiBtnClicked()
    {
        ChangeCharacter(samuraiPrefab);
    }

    private void ChangeCharacter(GameObject newCharacterPrefab)
    {
        if (currentPlayer != null)
        {
            string playerName = currentPlayer.name; // 기존 플레이어 이름 저장
            string playerNickname = currentPlayer.GetComponentInChildren<Text>().text;

            // 현재 플레이어 캐릭터 삭제
            Destroy(currentPlayer);

            // 새로운 캐릭터 생성
            currentPlayer = Instantiate(newCharacterPrefab);
            currentPlayer.name = playerName; // 기존 이름 유지

            // 이름을 새로 설정
            Text nameText = currentPlayer.GetComponentInChildren<Text>();
            nameText.text = playerName;
        }

        HiddenCCPanel.SetActive(false);
    }

}
