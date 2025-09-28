using Enums;
using Gameplay;
using UnityEngine;

namespace Managers
{
    public class SoundsManager : GenericSingleton<SoundsManager>
    {
        SoundsHolder soundsHolderSo;

        public void Init(SoundsHolder soundsHolder)
        {
            soundsHolderSo = soundsHolder; 
        }

        public void PlaySound(nlEnum.GameSoundTypes soundType, nlEnum.GameSounds gameSounds)
        {
            var a = ObjectPooling.Instance.GetAudioObject();
            a.PlaySound(soundsHolderSo.GetAudioClip(gameSounds));
        }
        public void PlaySound(nlEnum.GameSoundTypes soundType, nlEnum.GameSounds gameSounds, int pitch)
        {
            var a = ObjectPooling.Instance.GetAudioObject();
            a.PlaySound(soundsHolderSo.GetAudioClip(gameSounds), pitch);
        }
    }
}