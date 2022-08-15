using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private Player _player;
    public int CountOfCildren => transform.childCount;

    private void OnTriggerStay(Collider other)
    {
        _player.ResetStackDisplay();
    }
}
