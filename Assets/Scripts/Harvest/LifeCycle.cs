using System.Collections;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _size = 10;
    [SerializeField] private Haystack _stack;

    private Vector3 scale;

    public float Duration;
    public int Reward;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        StartCoroutine(GrowUp(Duration));
    }
    public void Mow(GameObject obj)
    {
        StartCoroutine(StartMowAnimation(1f, 0.8f, obj));
    }

    private IEnumerator StartMowAnimation(float delay, float animationDuration, GameObject obj)
    {
        
        yield return new WaitForSeconds(delay);
        _animator.SetTrigger("Mow");
        yield return new WaitForSeconds(animationDuration);
        gameObject.SetActive(false);
        obj.transform.position = transform.position + Vector3.up;
        obj.SetActive(true);
    }
    private IEnumerator GrowUp(float seconds)
    {
        scale = new Vector3(_size / seconds, _size / seconds, _size / seconds);
        var second = new WaitForSeconds(1f);
        for (int i = 0; i < seconds; i++)
        {
            transform.localScale += scale;
            yield return second;
        }
    }

}
