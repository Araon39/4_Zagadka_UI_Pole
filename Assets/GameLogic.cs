using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    // Ссылки на UI-элементы
    public TMP_InputField keyInput;
    public Toggle lightToggle;
    public Button submitButton;
    public TextMeshProUGUI resultText;

    // Правильные ответы
    private string correctKeyColor = "красный";
    private bool isLightOn = true;

    void Start()
    {
        // Привязываем кнопку к методу проверки
        submitButton.onClick.AddListener(CheckAnswers);
    }

    void CheckAnswers()
    {
        // Получаем введенные данные
        string enteredKeyColor = keyInput.text.ToLower();
        bool lightState = lightToggle.isOn;

        // Проверяем условия
        if (enteredKeyColor == correctKeyColor && lightState == isLightOn)
        {
            resultText.text = "Дверь открыта! Вы выиграли!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Неверные данные. Попробуйте ещё раз.";
            resultText.color = Color.red;
        }
    }
}
