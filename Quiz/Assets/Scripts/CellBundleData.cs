using UnityEngine;


[CreateAssetMenu(fileName = "New CellBundleData", menuName = "Cell Bundle Data")]
public class CellBundleData : ScriptableObject
{
    [SerializeField]
    private CellData[] _cellData;

    public CellData[] CellData
    {
        get { return _cellData; }
    }
}



