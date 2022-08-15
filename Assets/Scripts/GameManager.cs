using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _countOfSeeds;
    [SerializeField] private int _countOfHaystack;


    public int CountOfSeeds => _countOfSeeds;
    public int CountOfHaystack => _countOfHaystack;
}
