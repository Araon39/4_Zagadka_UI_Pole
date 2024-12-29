using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    // ������ �� UI-��������
    public TMP_InputField keyInput;
    public Toggle lightToggle;
    public Button submitButton;
    public TextMeshProUGUI resultText;

    // ���������� ������
    private string correctKeyColor = "�������";
    private bool isLightOn = true;

    void Start()
    {
        // ����������� ������ � ������ ��������
        submitButton.onClick.AddListener(CheckAnswers);
    }

    void CheckAnswers()
    {
        // �������� ��������� ������
        string enteredKeyColor = keyInput.text.ToLower();
        bool lightState = lightToggle.isOn;

        // ��������� �������
        if (enteredKeyColor == correctKeyColor && lightState == isLightOn)
        {
            resultText.text = "����� �������! �� ��������!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "�������� ������. ���������� ��� ���.";
            resultText.color = Color.red;
        }
    }
}
