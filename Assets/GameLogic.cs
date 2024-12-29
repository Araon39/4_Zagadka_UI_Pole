using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    // ���� ��� ����� � ����������
    public TMP_InputField keyInput;           // ���� ��� ����� ������
    public Toggle lightToggle;               // ������������� �����
    public Button submitButton;              // ������ "���������"
    public TextMeshProUGUI resultText;       // ����� ����������
    public TextMeshProUGUI infoText;         // ����� � ����������
    public TMP_Dropdown difficultyDropdown;  // Dropdown ��� ������ ���������
    public Image backgroundPanel;            // ������ ��� ����� �����
    public Light sceneLight;                 // �������� �����

    private int correctAnswer;               // ���������� �����
    private int minRange;                    // ����������� ��������
    private int maxRange;                    // ������������ ��������

    void Start()
    {
        // ����������� ��������� ��������
        UpdateDifficulty();
        GenerateNewPuzzle();

        // ��������� ����������� �������
        submitButton.onClick.AddListener(CheckAnswer);
        difficultyDropdown.onValueChanged.AddListener(delegate { UpdateDifficulty(); });
        lightToggle.onValueChanged.AddListener(delegate { ToggleLight(); });
    }

    void UpdateDifficulty()
    {
        // ����������� �������� ����� � ����������� �� ��������� ���������
        switch (difficultyDropdown.value)
        {
            case 0: // ������
                minRange = 1;
                maxRange = 50;
                break;
            case 1: // �������
                minRange = 1;
                maxRange = 100;
                break;
            case 2: // �������
                minRange = 1;
                maxRange = 200;
                break;
        }

        // ��������� ���������
        GenerateNewPuzzle();
    }

    void GenerateNewPuzzle()
    {
        // ��������� �����, ������� ������� �� 5
        correctAnswer = Random.Range(minRange / 5, maxRange / 5 + 1) * 5;
        infoText.text = $"������ ����� �� {minRange} �� {maxRange}. ���������: ��� ������� �� 5.";
    }

    void CheckAnswer()
    {
        // �������� �������� �����
        string userInput = keyInput.text;

        // ���������, ������� �� �����
        if (int.TryParse(userInput, out int userNumber))
        {
            // ���������� � ���������� �������
            if (userNumber == correctAnswer)
            {
                resultText.text = "���������! �� ������� �����!";
                backgroundPanel.color = Color.green; // ������ ��� �� ������
                GenerateNewPuzzle();                // ��������� ����� �������
            }
            else
            {
                resultText.text = "�����������. ���������� ��� ���!";
                backgroundPanel.color = Color.red;  // ������ ��� �� �������
            }
        }
        else
        {
            resultText.text = "������� �����!";
        }
    }

    void ToggleLight()
    {
        // �������� ��� ��������� ���� � ����������� �� ��������� �������������
        if (lightToggle.isOn)
        {
            sceneLight.enabled = true;
        }
        else
        {
            sceneLight.enabled = false;
        }
    }
}
