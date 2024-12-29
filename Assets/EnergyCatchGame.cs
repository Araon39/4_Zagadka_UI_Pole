using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyCatchGame : MonoBehaviour
{
    public Slider energySlider;               // �������� �������
    public Button checkButton;                // ������ ��������
    public TextMeshProUGUI targetEnergyText;  // ����� "������� �������"
    public TextMeshProUGUI scoreText;         // ����� �����

    private int targetEnergy;                 // ������� �������� �������
    private int score;                        // ���� ������

    void Start()
    {
        // ������������� ��������� ��������
        GenerateNewTarget();
        score = 0;
        UpdateScore();

        // ��������� ������� ��� ������
        checkButton.onClick.AddListener(CheckEnergy);
        
    }

    void GenerateNewTarget()
    {
        // ���������� ��������� �������� ���� (�� 0 �� 100)
        targetEnergy = Random.Range(0, 101);       
        targetEnergyText.text = "������� �������: " + targetEnergy;
               
    }

    void UpdateScore()
    {
        // ��������� ����� �����
        scoreText.text = "����: " + score;
        
    }

    void CheckEnergy()
    {
        // �������� ������� �������� ��������
        int currentEnergy = (int)energySlider.value;

        // ��������� �������
        int difference = Mathf.Abs(currentEnergy - targetEnergy);

        // ��������� ��������� � UI
        if (difference == 0) score += 10;        
        else if (difference <= 10)  score += 5;
        else score -= 5;

        // ��������� ����
        UpdateScore();

        // ���������� ����� ����
        GenerateNewTarget();
    }
}
