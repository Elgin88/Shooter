using System.Collections;
using UnityEngine;

namespace Shooter.Camera
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Quaternion _startMainCameraCuaternion = new Quaternion(65, 0, 0, 180);
        private Coroutine _cameraFollowingThePlayer;
        private float _deltaFromPlayerPositionX = 0;
        private float _deltaFromPlayerPositionY = 11;
        private float _deltaFromPlayerPositionZ = -11;

        internal void StartCameraFollowingThePlayer()
        {
            if (_cameraFollowingThePlayer == null)
            {
                _cameraFollowingThePlayer = StartCoroutine(CameraFollowingThePlayer());
            }
        }

        internal void StopCameraFollowingThePlayer()
        {
            StopCoroutine(_cameraFollowingThePlayer);
            _cameraFollowingThePlayer = null;
        }

        private void Start()
        {
            gameObject.transform.rotation = _startMainCameraCuaternion;

            StartCameraFollowingThePlayer();
        }

        private IEnumerator CameraFollowingThePlayer()
        {
            while (true)
            {
                gameObject.transform.position = new Vector3(_player.transform.position.x + _deltaFromPlayerPositionX, _player.transform.position.y + _deltaFromPlayerPositionY, _player.transform.position.z + _deltaFromPlayerPositionZ);

                yield return null;
            }
        }
    }
}