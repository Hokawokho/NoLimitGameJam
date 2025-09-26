using System;
using System.Collections.Generic;
using Enums;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class SoundData
{
    public AudioClip AudioClip;
    public nlEnum.GameSounds gameSounds;
}

[CreateAssetMenu(fileName = "GameAudios", menuName = "Scriptable Objects/GameAudios")]
public class SoundsHolder : ScriptableObject
{
    [SerializeField] List<SoundData> soundDatas = new List<SoundData>();    

    public AudioClip GetAudioClip(nlEnum.GameSounds gameSounds)
    {
        foreach (var s in soundDatas)
        {
            if (s.gameSounds == gameSounds) return s.AudioClip;
        }
        return null;
    }
}
