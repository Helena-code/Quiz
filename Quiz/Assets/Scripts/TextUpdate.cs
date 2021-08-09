using UnityEngine;
using UnityEngine.UI;


public class TextUpdate : MonoBehaviour
{
    private Text _taskText;


    public void UpdateTaskText(string taskValue)
    {
        // метод DOTween DoFade применяется только для материала и не распознает цвет текста
        // в связи с этим плавное появление текста не реализовано

        _taskText.text = $"Find {taskValue}";
    }

    private void Awake()
    {
        _taskText = GetComponent<Text>();
    }
}
