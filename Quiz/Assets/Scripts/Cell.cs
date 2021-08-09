using UnityEngine;
using UnityEngine.UI;


public class Cell : MonoBehaviour
{
    public string ÑurrentCellIdentifier
    {
        get { return _currentCellIdentifier; }
    }

    [SerializeField]
    private GameObject _imageElement;

    private CellData _currentCellData;
    private Image _spriteImage;
    private string _currentCellIdentifier;

    public void Init(CellData _cellData)
    {
        _currentCellData = _cellData;
        _spriteImage = _imageElement.GetComponent<Image>();
        _spriteImage.sprite = _currentCellData.Sprite;
        _spriteImage.preserveAspect = true;
        _currentCellIdentifier = _currentCellData.Identifier;
    }
}
