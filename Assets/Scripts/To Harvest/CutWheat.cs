using System.Collections;
using UnityEngine;

public class CutWheat : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _durationAnimation = 2f;
    [SerializeField] private Sickle _sickleComp;
    [SerializeField] private Pool _hatstack;

    private GameObject _sicleGameObj;
    private Animator _animator;
    private Movement _movement;
    
    private bool _canMow;

    void OnTriggerStay(Collider other)
    {
        if (_canMow && other.TryGetComponent<LifeCycle>(out LifeCycle harvest))
        {
            Debug.Log(harvest.gameObject.name);
            _canMow = !_canMow;
            foreach(Transform obj in _hatstack.GetComponentInChildren<Transform>())
            {
                Debug.Log(obj.name);
                if(!obj.gameObject.active)
                {
                    harvest.Mow(obj.gameObject);
                    break;
                }
                    
            }
            
        }
    }
    private void Start()
    {
        _animator = _player.gameObject.GetComponent<Animator>();
        _movement = _player.gameObject.GetComponent<Movement>();
        _sicleGameObj = _sickleComp.gameObject;
        _sicleGameObj.SetActive(false);
    }
    public void Cut()
    {
        _movement.CanPlayerMove(false);
        _animator.SetBool("Mow", true);
        _sicleGameObj.SetActive(true);
        _canMow = true;
        StartCoroutine(MowWheat(_durationAnimation));
    }

    private IEnumerator MowWheat(float time)
    {
        
        float timer = 0f;
        while (timer < time)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
        }
        _canMow = false;
        _sicleGameObj.SetActive(false);
        _movement.CanPlayerMove(true);
    }
    
}

