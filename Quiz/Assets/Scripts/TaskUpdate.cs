using UnityEngine;


public class TaskUpdate : MonoBehaviour
{
    [SerializeField]
    private GameObject _taskTextField;

    public string ÑurrentTask
    {
        get { return _currentTask; }
    }

    private ChangeLevel _changeLevelScript;
    private TextUpdate _textScript;
    private string _currentTask;


    public void UpdateTask(string newTaskValue)
    {
        _currentTask = newTaskValue;
        _textScript.UpdateTaskText(ÑurrentTask);
    }

    public bool CheckingCorrectAnswer(string cellIdentifier)
    {
        if (_currentTask.Equals(cellIdentifier))
        {
            _changeLevelScript.IncreaseSuccessValue();
            _changeLevelScript.CheckSuccessLimit();
            return true;
        }
        else return false;
    }

    private void Awake()
    {
        _textScript = _taskTextField.GetComponent<TextUpdate>();
        _changeLevelScript = GetComponent<ChangeLevel>();
    }
}
