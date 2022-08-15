using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Haystack : MonoBehaviour
{
    [SerializeField] private Harvest _harvest;

    private void OnEnable()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
    public void MoveObject(Vector3 endPoint, float delay, Transform parent, UnityAction<int> action)
    {
        StartCoroutine(MoveObjectC(transform.position, endPoint, 2f, delay, parent, action));
    }
    private IEnumerator MoveObjectC(Vector3 source, Vector3 target, float overTime, float delay, Transform parent, UnityAction<int> action)
    {
        yield return new WaitForSeconds(delay);
        transform.parent = parent;
        
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        action?.Invoke(_harvest.Reward);
        gameObject.SetActive(false);
    }
}
