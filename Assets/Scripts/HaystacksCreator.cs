using UnityEngine;

public class HaystacksCreator : MonoBehaviour
{
    [SerializeField] private Haystack _haystack;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        for (int i = 0; i < _gameManager.CountOfSeeds; i++)
        {
            var obj = Instantiate(_haystack.transform.gameObject, transform.position, Quaternion.Euler(-90, Random.Range(0, 180), 0), transform);
            obj.SetActive(false);
        }
    }
}
