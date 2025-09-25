using Enums;
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

        public void PlaySound(nlEnum.SoundType soundType, nlEnum.GameSounds gameSounds)
        {
            var s = new AudioObject(); // todo : get from pool
            s.PlaySound(soundsHolderSo.GetAudioClip(gameSounds));
        }
    }
}