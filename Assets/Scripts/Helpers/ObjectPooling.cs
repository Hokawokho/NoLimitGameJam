using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.EventSystems.EventTrigger;

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

        private List<IngiObj> ingredientListPool = new List<IngiObj>();
       

        private void Start()
        {
            foreach (var poolObjectData in poolObjectDataList)
            {
                Spawn(poolObjectData.prefab , poolObjectData.initialSpawnCount , poolObjectData.poolObjectType , poolObjectData.spawnParent);
            }
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
                case nlEnum.PoolObjectTypes.Cheese:
                    var enemy = (IngiObj)poolObject;
                    ingredientListPool.Add(enemy);
                    break;
            }
        }

        public IPoolableObjects GetObjectFromPool(nlEnum.PoolObjectTypes poolObjectType)
        {
            switch (poolObjectType)
            {
                case nlEnum.PoolObjectTypes.Cheese:
                    if (ingredientListPool.Count < 2)
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Cheese);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var enemy = ingredientListPool[0];
                    ingredientListPool.Remove(enemy);
                    enemy.SetParent(null);
                    return enemy;
                    //default:
                    //return null;


                case nlEnum.PoolObjectTypes.Onion:
                    if (ingredientListPool.Count < 2)
                        //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Onion);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var onion = ingredientListPool[0];
                    ingredientListPool.Remove(onion);
                    onion.SetParent(null);
                    return onion;
                default:
                    return null;
            }

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



        public IngiObj GetIngiPrefab()
        {
            return (IngiObj)GetObjectFromPool(nlEnum.PoolObjectTypes.Cheese);
        }

       
        public void AddBackToList(IPoolableObjects poolable , nlEnum.PoolObjectTypes poolObjectTypes)
        {
            switch (poolObjectTypes)
            {
                case nlEnum.PoolObjectTypes.Cheese:
                    var enemy = (IngiObj)poolable;
                    ResetObjects(enemy.gameObject , nlEnum.PoolObjectTypes.Cheese);
                    ingredientListPool.Add(enemy);
                    break;
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