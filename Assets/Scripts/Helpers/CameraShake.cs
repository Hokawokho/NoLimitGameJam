using System.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

namespace Helpers
{
    public class CameraShake : MonoBehaviour
    {
        private static CinemachineCamera _virtualCamera;
        private static CinemachineBasicMultiChannelPerlin _noise;
        private static float _shakeTimer;

        public static void Init(CinemachineCamera virtualCamera)
        {
            _virtualCamera = virtualCamera;

            var baseComp = _virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Noise);
            var noise = baseComp as CinemachineBasicMultiChannelPerlin;

            _noise.AmplitudeGain = 0;
        }

        public static void ShakeCamera(float intensity = 3f ,float duration = 0.2f)
        {
            _noise.AmplitudeGain = 1;
            _noise.FrequencyGain = intensity;
            _shakeTimer = duration;
        }
        
        void Update()
        {
            if (!(_shakeTimer > 0)) return;
            _shakeTimer -= Time.deltaTime;

            if (_shakeTimer <= 0f)
            {
                _noise.AmplitudeGain = 0;
            }
        }
    }

}