using UnityEngine;

[CreateAssetMenu(fileName = "New Herb", menuName ="Herb/Create new herb", order = 51)]
public class Harvest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _reward;
    [SerializeField] private float _growUpTime;
    [SerializeField] private GameObject _3dModel;

    public string Name =>_name;
    public int Reward =>_reward;
    public float GrouUpTime => _growUpTime;
    public GameObject Model => _3dModel;
    
}
