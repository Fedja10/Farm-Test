using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Pool _pool;

    private bool _canPlant;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Patch>(out _))
        {
            _canPlant = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<LifeCycle>(out _))
        {
            _canPlant=false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Patch>(out _))
        {
            _canPlant = false;
        }
        if (other.TryGetComponent<LifeCycle>(out _))
            _canPlant = true;
    }
    public void PlantSmt()
    {
        if (_canPlant)
        {
            foreach (Transform obj in _pool.GetComponentInChildren<Transform>())
            {
                if(!obj.gameObject.active)
                {
                    obj.position = transform.position;
                    obj.rotation = Quaternion.Euler(-90, Random.Range(0,180), 0);
                    obj.gameObject.SetActive(true);
                    break;
                }
            }
        }  
    }
}
