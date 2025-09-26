using System;
using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class InGameParticles : MonoBehaviour, IPoolableObjects
    {
        [SerializeField] private nlEnum.InGameParticleType particleType;
        [SerializeField] private ParticleSystem particle;
        private ObjectPooling _pool;

        public void Init(ObjectPooling pool)
        {
            _pool = pool;
        }

        public void BackToPool()
        {
           // _pool.AddBackToList(this , GetPoolTypeByParticleType());
        }

        //private nlEnum.PoolObjectTypes GetPoolTypeByParticleType()
        //{
        //    return particleType switch
        //    {
        //        nlEnum.InGameParticleType.BulletHit => nlEnum.PoolObjectTypes.BulletHitParticle,
        //        nlEnum.InGameParticleType.EnemyHit => nlEnum.PoolObjectTypes.EnemyHitParticle,
        //        _ => throw new ArgumentOutOfRangeException()
        //    };
        //}

        public void Play(Vector3 newPos, Quaternion rotation = default)
        {
            transform.position = newPos;
            transform.rotation = rotation;
            gameObject.SetActive(true);
            particle.Play();
            Invoke(nameof(BackToPool) , particle.main.duration);
        }
    }
}