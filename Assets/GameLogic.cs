using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    // Поля для ввода и управления
    public TMP_InputField keyInput;           // Поле для ввода текста
    public Toggle lightToggle;               // Переключатель света
    public Button submitButton;              // Кнопка "Проверить"
    public TextMeshProUGUI resultText;       // Текст результата
    public TextMeshProUGUI infoText;         // Текст с подсказкой
    public TMP_Dropdown difficultyDropdown;  // Dropdown для выбора сложности
    public Image backgroundPanel;            // Панель для смены цвета
    public Light sceneLight;                 // Источник света

    private int correctAnswer;               // Загаданное число
    private int minRange;                    // Минимальное значение
    private int maxRange;                    // Максимальное значение

    void Start()
    {
        // Настраиваем начальные значения
        UpdateDifficulty();
        GenerateNewPuzzle();

        // Назначаем обработчики событий
        submitButton.onClick.AddListener(CheckAnswer);
        difficultyDropdown.onValueChanged.AddListener(delegate { UpdateDifficulty(); });
        lightToggle.onValueChanged.AddListener(delegate { ToggleLight(); });
    }

    void UpdateDifficulty()
    {
        // Настраиваем диапазон чисел в зависимости от выбранной сложности
        switch (difficultyDropdown.value)
        {
            case 0: // Легкий
                minRange = 1;
                maxRange = 50;
                break;
            case 1: // Средний
                minRange = 1;
                maxRange = 100;
                break;
            case 2: // Сложный
                minRange = 1;
                maxRange = 200;
                break;
        }

        // Обновляем подсказку
        GenerateNewPuzzle();
    }

    void GenerateNewPuzzle()
    {
        // Генерация числа, которое делится на 5
        correctAnswer = Random.Range(minRange / 5, maxRange / 5 + 1) * 5;
        infoText.text = $"Угадай число от {minRange} до {maxRange}. Подсказка: оно делится на 5.";
    }

    void CheckAnswer()
    {
        // Получаем введённый текст
        string userInput = keyInput.text;

        // Проверяем, введено ли число
        if (int.TryParse(userInput, out int userNumber))
        {
            // Сравниваем с правильным ответом
            if (userNumber == correctAnswer)
            {
                resultText.text = "Правильно! Вы угадали число!";
                backgroundPanel.color = Color.green; // Меняем фон на зелёный
                GenerateNewPuzzle();                // Генерация новой загадки
            }
            else
            {
                resultText.text = "Неправильно. Попробуйте ещё раз!";
                backgroundPanel.color = Color.red;  // Меняем фон на красный
            }
        }
        else
        {
            resultText.text = "Введите число!";
        }
    }

    void ToggleLight()
    {
        // Включаем или выключаем свет в зависимости от состояния переключателя
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
