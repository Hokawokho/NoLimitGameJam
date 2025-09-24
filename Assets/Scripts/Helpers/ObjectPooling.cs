using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    

    [Serializable]
    public class PoolObjectData
    {
        public GameObject prefab;
        public Transform spawnParent;
        public int initialSpawnCount;
        public nlEnum.PoolObjectTypes poolObjectType;
    }

    public class ObjectPooling : GenericSingleton<ObjectPooling>
    {
    
        [SerializeField] private List<PoolObjectData> poolObjectDataList;

        //private List<Enemy> _enemyListPool = new List<Enemy>();
       

        private void Start()
        {
            foreach (var poolObjectData in poolObjectDataList)
            {
                Spawn(poolObjectData.prefab , poolObjectData.initialSpawnCount , poolObjectData.poolObjectType , poolObjectData.spawnParent);
            }
            // Spawn(bulletPrefab , minBulletCount , PoolObjectTypes.Bullet , bulletSpawnParent);
            // Spawn(enemyPrefab , minEnemyCount , PoolObjectTypes.Enemy , enemySpawnParent);k
        }

        private void Spawn(GameObject poolableObjects, int count , nlEnum.PoolObjectTypes poolObjectType , Transform parent)
        {
            for (int i = 0; i < count; i++)
            {
                var poolObject = Instantiate(poolableObjects , parent);
                poolObject.gameObject.SetActive(false);
            
                var iPoolObject = poolObject.GetComponent<IPoolableObjects>();
                iPoolObject.Init(this);
            
                AddObjectToPool(poolObjectType , iPoolObject);
            }
        }

        private void AddObjectToPool(nlEnum.PoolObjectTypes poolObjectType, IPoolableObjects poolObject)
        {

            switch (poolObjectType)
            {
                case nlEnum.PoolObjectTypes.Enemy:
                    break;
                case nlEnum.PoolObjectTypes.Bullet:
                    break;
                case nlEnum.PoolObjectTypes.Coin:
                    break;
                case nlEnum.PoolObjectTypes.Spell:
                    break;
                case nlEnum.PoolObjectTypes.Bomb:
                    break;
                case nlEnum.PoolObjectTypes.Audio:
                    break;
                case nlEnum.PoolObjectTypes.BulletHitParticle:
                    break;
                case nlEnum.PoolObjectTypes.EnemyHitParticle:
                    break;
                    //case DTMEnum.PoolObjectTypes.Enemy:
                    //    var enemy = (Enemy)poolObject;
                    //    enemy.SetTarget(GameManager.Instance.Player);
                    //    _enemyListPool.Add(enemy);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Bullet:
                    //    _bulletListPool.Add((Bullet)poolObject);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Coin:
                    //    _coinListPool.Add((Collectables)poolObject);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Spell:
                    //    _xpListPool.Add((Collectables)poolObject);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Bomb:
                    //    _bombListPool.Add((Bomb)poolObject);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Audio:
                    //    _positionalAudiosPool.Add((PositionalAudio)poolObject);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.BulletHitParticle:
                    //    _bulletHitParticlePool.Add((InGameParticles)poolObject);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.EnemyHitParticle:
                    //    _enemyHitParticlePool.Add((InGameParticles)poolObject);
                    //    break;
                    //default:
                    //    throw new ArgumentOutOfRangeException(nameof(poolObjectType), poolObjectType, null);
            }
        }

        IPoolableObjects GetObjectFromPool(nlEnum.PoolObjectTypes poolObjectType)
        {
            switch (poolObjectType)
            {
                case nlEnum.PoolObjectTypes.Enemy:
                    break;
                case nlEnum.PoolObjectTypes.Bullet:
                    break;
                case nlEnum.PoolObjectTypes.Coin:
                    break;
                case nlEnum.PoolObjectTypes.Spell:
                    break;
                case nlEnum.PoolObjectTypes.Bomb:
                    break;
                case nlEnum.PoolObjectTypes.Audio:
                    break;
                case nlEnum.PoolObjectTypes.BulletHitParticle:
                    break;
                case nlEnum.PoolObjectTypes.EnemyHitParticle:
                    break;
                default:
                    return null;
                    //case DTMEnum.PoolObjectTypes.Enemy:
                    //    if (_enemyListPool.Count < 2)
                    //    {
                    //        var poolObjectData = GetPoolProjectData(DTMEnum.PoolObjectTypes.Enemy);
                    //        Spawn(poolObjectData.prefab , 10 ,poolObjectData.poolObjectType , poolObjectData.spawnParent);
                    //    }            
                    //    var enemy = _enemyListPool[0];
                    //    _enemyListPool.Remove(enemy);
                    //    enemy.transform.parent = null;
                    //    return enemy;

                    //case DTMEnum.PoolObjectTypes.Bullet:
                    //    if (_bulletListPool.Count < 2)
                    //    {
                    //        var poolObjectData = GetPoolProjectData(DTMEnum.PoolObjectTypes.Bullet);
                    //        Spawn(poolObjectData.prefab , 10 ,poolObjectData.poolObjectType , poolObjectData.spawnParent);
                    //    }            
                    //    var bullet = _bulletListPool[0];
                    //    _bulletListPool.Remove(bullet);
                    //    bullet.transform.parent = null;
                    //    return bullet;

                    //case DTMEnum.PoolObjectTypes.Coin:
                    //    var coin = GetCollectablesObject(_coinListPool , DTMEnum.PoolObjectTypes.Coin);
                    //    coin.SetManager(CollectablesManagerHolder.Instance.GetManager(DTMEnum.CollectablesType.Coins));
                    //    return coin;
                    //case DTMEnum.PoolObjectTypes.Spell:
                    //    var xp = GetCollectablesObject(_xpListPool , DTMEnum.PoolObjectTypes.Spell);
                    //    xp.SetManager(CollectablesManagerHolder.Instance.GetManager(DTMEnum.CollectablesType.Spell));
                    //    return xp;
                    //case DTMEnum.PoolObjectTypes.Bomb:
                    //    if (_bombListPool.Count < 2)
                    //    {
                    //        var poolObjectData = GetPoolProjectData(DTMEnum.PoolObjectTypes.Bomb);
                    //        Spawn(poolObjectData.prefab , 5 ,poolObjectData.poolObjectType , poolObjectData.spawnParent);
                    //    }            
                    //    var bomb = _bombListPool[0];
                    //    _bombListPool.Remove(bomb);
                    //    bomb.transform.parent = null;
                    //    return bomb;
                    //case DTMEnum.PoolObjectTypes.Audio:
                    //    if (_positionalAudiosPool.Count < 2)
                    //    {
                    //        var poolObjectData = GetPoolProjectData(DTMEnum.PoolObjectTypes.Audio);
                    //        Spawn(poolObjectData.prefab , 10 ,poolObjectData.poolObjectType , poolObjectData.spawnParent);
                    //    }            
                    //    var audio = _positionalAudiosPool[0];
                    //    _positionalAudiosPool.Remove(audio);
                    //    audio.transform.parent = null;
                    //    return audio;
                    //case DTMEnum.PoolObjectTypes.BulletHitParticle:
                    //    return GetParticleObject(_bulletHitParticlePool , DTMEnum.PoolObjectTypes.BulletHitParticle);
                    //case DTMEnum.PoolObjectTypes.EnemyHitParticle:
                    //    return GetParticleObject(_enemyHitParticlePool , DTMEnum.PoolObjectTypes.EnemyHitParticle);
            }

            return null;
        }

        private IPoolableObjects GetParticleObject(List<InGameParticles> poolList , nlEnum.PoolObjectTypes particlePoolType)
        {
            if (poolList.Count < 2)
            {
                var poolObjectData = GetPoolProjectData(particlePoolType);
                Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
            }

            var bulletHit = poolList[0];
            poolList.Remove(bulletHit);
            bulletHit.transform.parent = null;
            return bulletHit;
        }



        //public PositionalAudio GetAudioPrefab()
        //{
        //    return (PositionalAudio)GetObjectFromPool(DTMEnum.PoolObjectTypes.Audio);
        //}

       
        public void AddBackToList(IPoolableObjects poolable , nlEnum.PoolObjectTypes poolObjectTypes)
        {
            switch (poolObjectTypes)
            {
                case nlEnum.PoolObjectTypes.Enemy:
                    break;
                case nlEnum.PoolObjectTypes.Bullet:
                    break;
                case nlEnum.PoolObjectTypes.Coin:
                    break;
                case nlEnum.PoolObjectTypes.Spell:
                    break;
                case nlEnum.PoolObjectTypes.Bomb:
                    break;
                case nlEnum.PoolObjectTypes.Audio:
                    break;
                case nlEnum.PoolObjectTypes.BulletHitParticle:
                    break;
                case nlEnum.PoolObjectTypes.EnemyHitParticle:
                    break;
                    //case DTMEnum.PoolObjectTypes.Enemy:
                    //    var enemy = (Enemy)poolable;
                    //    ResetObjects(enemy.gameObject , DTMEnum.PoolObjectTypes.Enemy);
                    //    _enemyListPool.Add(enemy);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Bullet:
                    //    var bullet = (Bullet)poolable;
                    //    ResetObjects(bullet.gameObject, DTMEnum.PoolObjectTypes.Bullet);
                    //    _bulletListPool.Add(bullet);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Coin:
                    //    var coin = (Collectables)poolable;
                    //    ResetObjects(coin.gameObject, DTMEnum.PoolObjectTypes.Coin);
                    //    _coinListPool.Add(coin);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Spell:
                    //    var xp = (Collectables)poolable;
                    //    ResetObjects(xp.gameObject, DTMEnum.PoolObjectTypes.Spell);
                    //    _xpListPool.Add(xp);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Bomb:
                    //    var bomb = (Bomb)poolable;
                    //    ResetObjects(bomb.gameObject, DTMEnum.PoolObjectTypes.Bomb);
                    //    _bombListPool.Add(bomb);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.Audio:
                    //    var audio = (PositionalAudio)poolable;
                    //    ResetObjects(audio.gameObject, DTMEnum.PoolObjectTypes.Audio);
                    //    _positionalAudiosPool.Add(audio);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.BulletHitParticle:
                    //    var bulletHit = (InGameParticles)poolable;
                    //    ResetObjects(bulletHit.gameObject, DTMEnum.PoolObjectTypes.BulletHitParticle);
                    //    _bulletHitParticlePool.Add(bulletHit);
                    //    break;
                    //case DTMEnum.PoolObjectTypes.EnemyHitParticle:
                    //    var enemyHit = (InGameParticles)poolable;
                    //    ResetObjects(enemyHit.gameObject, DTMEnum.PoolObjectTypes.EnemyHitParticle);
                    //    _enemyHitParticlePool.Add(enemyHit);  break;
                    //default:
                    //    throw new ArgumentOutOfRangeException(nameof(poolObjectTypes), poolObjectTypes, null);
            }
        }

        private void ResetObjects(GameObject poolObj , nlEnum.PoolObjectTypes type)
        {
            poolObj.gameObject.SetActive(false);
            poolObj.transform.SetParent(GetPoolProjectData(type).spawnParent);
            poolObj.transform.position = Vector3.zero;
        }

        PoolObjectData GetPoolProjectData(nlEnum.PoolObjectTypes poolObjectType)
        {
            return poolObjectDataList.FirstOrDefault(poolObjectData => poolObjectData.poolObjectType == poolObjectType);
        }
    }
}