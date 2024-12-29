using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyCatchGame : MonoBehaviour
{
    public Slider energySlider;               // Ползунок энергии
    public Button checkButton;                // Кнопка проверки
    public TextMeshProUGUI targetEnergyText;  // Текст "Целевая энергия"
    public TextMeshProUGUI scoreText;         // Текст очков

    private int targetEnergy;                 // Целевое значение энергии
    private int score;                        // Счёт игрока

    void Start()
    {
        // Устанавливаем начальные значения
        GenerateNewTarget();
        score = 0;
        UpdateScore();

        // Добавляем событие для кнопки
        checkButton.onClick.AddListener(CheckEnergy);
        
    }

    void GenerateNewTarget()
    {
        // Генерируем случайное значение цели (от 0 до 100)
        targetEnergy = Random.Range(0, 101);       
        targetEnergyText.text = "Целевая энергия: " + targetEnergy;
               
    }

    void UpdateScore()
    {
        // Обновляем текст очков
        scoreText.text = "Очки: " + score;
        
    }

    void CheckEnergy()
    {
        // Получаем текущее значение ползунка
        int currentEnergy = (int)energySlider.value;

        // Вычисляем разницу
        int difference = Mathf.Abs(currentEnergy - targetEnergy);

        // Обновляем результат в UI
        if (difference == 0) score += 10;        
        else if (difference <= 10)  score += 5;
        else score -= 5;

        // Обновляем очки
        UpdateScore();

        // Генерируем новую цель
        GenerateNewTarget();
    }
}
