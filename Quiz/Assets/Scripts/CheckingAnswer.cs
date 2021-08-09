using UnityEngine;

public class CheckingAnswer : MonoBehaviour
{
    private Cell _cellScript;
    private AnimationEffect _animationEffectScript;
    private TaskUpdate _taskUpdateScript;


    public void CheckAnswer()
    {
        if (_taskUpdateScript.CheckingCorrectAnswer(_cellScript.ÑurrentCellIdentifier))
        {
            _animationEffectScript.PlayRightAnswerAnimation();
        }
        else
        {
            _animationEffectScript.PlayWrongAnswerAnimation();
        }
    }

    private void Start()
    {
        _cellScript = GetComponent<Cell>();
        _animationEffectScript = GetComponent<AnimationEffect>();
        _taskUpdateScript = Camera.main.GetComponent<TaskUpdate>();
    }
}
