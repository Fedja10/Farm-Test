using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayCoinAnimation()
    {
        Debug.Log("PlayA");
        _animator.SetTrigger("AddCoin");
    }
}
