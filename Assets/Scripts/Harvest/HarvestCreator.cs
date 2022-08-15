using UnityEngine;

public class HarvestCreator : MonoBehaviour
{
    [SerializeField] private Harvest _harvest;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        for (int i = 0; i < _gameManager.CountOfSeeds; i++)
        {
            var wheat = Instantiate(_harvest.Model, transform.position, Quaternion.Euler(-90, Random.Range(0, 180), 0),transform);
            wheat.GetComponent<LifeCycle>().Duration = _harvest.GrouUpTime;
            wheat.SetActive(false);
        }
    }
}
