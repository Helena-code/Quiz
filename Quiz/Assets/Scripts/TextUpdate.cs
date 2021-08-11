using UnityEngine;
using UnityEngine.UI;


public class TextUpdate : MonoBehaviour
{
    private Text _taskText;


    public void UpdateTaskText(string taskValue)
    {
        _taskText.text = $"Find {taskValue}";
    }

    private void Awake()
    {
        _taskText = GetComponent<Text>();
    }
}
