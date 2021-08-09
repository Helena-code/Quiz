using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField]
    private List<CellBundleData> _cellBundles;

    [SerializeField]
    private List<CellData> _cellSettings;

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private GameObject _cellPanel;

    [SerializeField]
    private List<GameObject> _currentCells;

    [SerializeField]
    private int _poolCount;

    public Dictionary<GameObject, Cell> Cells;

    private CellBundleData _cellBundle;
    private Transform _cellPanelTransform;
    private TaskUpdate _taskUpdate;
    private List<GameObject> _tasks;

    // метод выбора случайного набора предметов для игры
    public void ChooseBundle()
    {
        int rand = Random.Range(0, _cellBundles.Count);
        _cellBundle = _cellBundles[rand];

        CreateCells();
        GetCellSettins();
        SpawnCells();
    }

    // метод очистки перед новой playmode
    public void CleaneAllCell()
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            _tasks[i] = null;
        }
        _tasks.RemoveAll(x => x == null);

        Cells.Clear();

        for (int i = 0; i < _currentCells.Count; i++)
        {
            GameObject go = _currentCells[i];
            _currentCells[i] = null;
            Destroy(go);
        }
        _currentCells.RemoveAll(x => x == null);

        ChooseBundle();
    }

    private void Awake()
    {
        _cellPanelTransform = _cellPanel.transform;
        _taskUpdate = GetComponent<TaskUpdate>();
        _tasks = new List<GameObject>();
        // словарь создан для того, чтобы каждый раз не использовать GetComponent для получения скрипта
        Cells = new Dictionary<GameObject, Cell>();
        _currentCells = new List<GameObject>();
    }

    private void CreateCells()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            var prefab = Instantiate(_cellPrefab);
            Cell script = prefab.GetComponent<Cell>();
            prefab.SetActive(false);
            Cells.Add(prefab, script);
            _currentCells.Add(prefab);
        }
    }

    private void SpawnCells()
    {
        for (int i = 0; i < _currentCells.Count; i++)
        {
            var cell = _currentCells[i];
            Cell script = Cells[cell];
            int rand = Random.Range(0, _cellSettings.Count);
            script.Init(_cellSettings[rand]);
            _cellSettings.RemoveAt(rand);
        }

        SetTaskValue();

        for (int i = 0; i < _currentCells.Count; i++)
        {
            var cell = _currentCells[i];
            cell.transform.SetParent(_cellPanelTransform);
            cell.transform.localScale = Vector3.one;
            cell.SetActive(true);
        }
    }

    // метод получения настроек для ячейки
    private void GetCellSettins()
    {
        if (_cellSettings.Count != 0)
        {
            int cellSettingCount = _cellSettings.Count;

            for (int i = 0; i < _cellSettings.Count; i++)
            {
                _cellSettings[i] = null;
            }
            _cellSettings.RemoveAll(x => x == null);
        }

        for (int i = 0; i < _cellBundle.CellData.Length; i++)
        {
            _cellSettings.Add(_cellBundle.CellData[i]);
        }
    }

    // метод установки целевого значения
    private void SetTaskValue()
    {
        int rand = Random.Range(0, _currentCells.Count);
        _tasks.Add(_currentCells[rand]);
        _taskUpdate.UpdateTask(_currentCells[rand].GetComponent<Cell>().СurrentCellIdentifier);
    }
}
