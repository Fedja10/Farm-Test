using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Movement _player;
    [SerializeField] private float _delay;
    [SerializeField] private float _ofset;

    private Vector3 _cameraPlayer;
    private void OnEnable()
    {
        _cameraPlayer = new Vector3();
        _player.Track += CamerMove;
    }
    private void OnDisable()
    {
        _player.Track -= CamerMove;
    }
    private void CamerMove()
    {
        _cameraPlayer = _player.transform.position;
        _cameraPlayer.y = transform.position.y;
        _cameraPlayer.z = _player.transform.position.z - _ofset;
        transform.position = Vector3.Lerp(_cameraPlayer, transform.position, _delay * Time.deltaTime);
    }
}
