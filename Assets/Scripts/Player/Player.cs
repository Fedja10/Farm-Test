using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;
    [SerializeField] private int _countHaystack;
    [SerializeField] private TMP_Text _stackLimit;

    private bool _canAdd = true;

    private void Start()
    {
        ResetStackDisplay();
    }
    private void OnTriggerEnter(Collider other)
    {
        _canAdd = _backpack.CountOfCildren >= _countHaystack ? false : true;
            
        if (_canAdd)
        {
            if (other.TryGetComponent<Haystack>(out Haystack haystack))
            {
                haystack.transform.gameObject.GetComponent<Animator>().enabled = false;
                haystack.transform.position = _backpack.transform.position;
                haystack.transform.parent = _backpack.transform;
                haystack.transform.position += new Vector3(0, _backpack.CountOfCildren * 0.5f + 0.2f, 0);
            }
            ResetStackDisplay();
        }
    }
    public void ResetStackDisplay()
    {
        _stackLimit.text = _backpack.CountOfCildren.ToString() + " / " + _countHaystack.ToString();
    }
}
