using UnityEngine;
using UnityEngine.Events;

public class SaleZone : MonoBehaviour
{
    [SerializeField] private Pool _returnPool;
    [SerializeField] private Storage _storage;
    [SerializeField] private float _stepTime;

    public event UnityAction<int> AddMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Backpack>(out Backpack backpack))
        {
            if(backpack.transform.childCount > 0)
            {
                float delay = backpack.transform.childCount * _stepTime;
                foreach (Transform obj in backpack.GetComponentInChildren<Transform>())
                {
                    delay -= _stepTime;
                    obj.GetComponent<Haystack>().MoveObject(_storage.transform.position, delay, _returnPool.transform, AddMoney);
                }
            }
        }
    }
}
