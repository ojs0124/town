using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuncBtn : MonoBehaviour
{
    public GameObject HiddenNCPanel; // �г��� ���� �г�
    public GameObject HiddenCCPanel; // ĳ���� ���� �г�
    public Button changeNicknameButton; // �г��� ���� ��ư
    public Button changeCharacterButton; // ĳ���� ���� ��ư
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
            string playerName = currentPlayer.name; // ���� �÷��̾� �̸� ����
            string playerNickname = currentPlayer.GetComponentInChildren<Text>().text;

            // ���� �÷��̾� ĳ���� ����
            Destroy(currentPlayer);

            // ���ο� ĳ���� ����
            currentPlayer = Instantiate(newCharacterPrefab);
            currentPlayer.name = playerName; // ���� �̸� ����

            // �̸��� ���� ����
            Text nameText = currentPlayer.GetComponentInChildren<Text>();
            nameText.text = playerName;
        }

        HiddenCCPanel.SetActive(false);
    }

}
