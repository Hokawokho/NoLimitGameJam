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


        private List<IngiObj> ingredientListPoolCheese = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolOnion = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBadEgg = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBadFish = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBadSteak = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBeetroot = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolEyeball = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolRat = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolSpaghetti = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBoot = new List<IngiObj>();
        private List<AudioObject> audioObjectPool = new List<AudioObject>();
       

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
                    ingredientListPoolCheese.Add(enemy);
                    break;

                case nlEnum.PoolObjectTypes.Onion:
                    var onion = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(onion);
                    break;
                case nlEnum.PoolObjectTypes.BadEgg:
                    var bEgg = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(bEgg);
                    break;
                case nlEnum.PoolObjectTypes.BadFish:
                    var bFish = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(bFish);
                    break;
                case nlEnum.PoolObjectTypes.Beetroot:
                    var beetroot = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(beetroot);
                    break;
                case nlEnum.PoolObjectTypes.Boot:
                    var boot = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(boot);
                    break;
                case nlEnum.PoolObjectTypes.Broccoli:
                    var broco = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(broco);
                    break;
                case nlEnum.PoolObjectTypes.Eyeball:
                    var eyeball = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(eyeball);
                    break;
                
                case nlEnum.PoolObjectTypes.Rat:
                    var rat = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(rat);
                    break;
                
                case nlEnum.PoolObjectTypes.Spaghetti:
                    var spaghetti = (IngiObj)poolObject;
                    ingredientListPoolOnion.Add(spaghetti);
                    break;

                    

                case nlEnum.PoolObjectTypes.AudioObject:
                    var audio = (AudioObject)poolObject;
                    audioObjectPool.Add(audio);
                    break;
            }
        }

        public IPoolableObjects GetObjectFromPool(nlEnum.PoolObjectTypes poolObjectType)
        {
            switch (poolObjectType)
            {
                case nlEnum.PoolObjectTypes.Cheese:
                    if (ingredientListPoolCheese.Count < 2)
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Cheese);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var enemy = ingredientListPoolCheese[0];
                    ingredientListPoolCheese.Remove(enemy);
                    enemy.SetParent(null);
                    return enemy;
                    //default:
                    //return null;


                case nlEnum.PoolObjectTypes.Onion:
                    if (ingredientListPoolOnion.Count < 2)
                        //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Onion);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var onion = ingredientListPoolOnion[0];
                    ingredientListPoolOnion.Remove(onion);
                    onion.SetParent(null);
                    return onion;

                    case nlEnum.PoolObjectTypes.AudioObject:
                    if (audioObjectPool.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.AudioObject);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var audio = audioObjectPool[0];
                    audioObjectPool.Remove(audio);
                    audio.SetParent(null);
                    return audio;
                default:
                    return null;
            }

        }

        public AudioObject GetAudioObject()
        {
            return (AudioObject)GetObjectFromPool(nlEnum.PoolObjectTypes.AudioObject);
        }


        public IngiObj GetIngiPrefab(nlEnum.PoolObjectTypes ingiType)
        {
            return (IngiObj)GetObjectFromPool(ingiType);
        }

       
        public void AddBackToList(IPoolableObjects poolable , nlEnum.PoolObjectTypes poolObjectTypes)
        {
            switch (poolObjectTypes)
            {
                case nlEnum.PoolObjectTypes.Cheese:
                    var enemy = (IngiObj)poolable;
                    ResetObjects(enemy.gameObject , nlEnum.PoolObjectTypes.Cheese);
                    ingredientListPoolOnion.Add(enemy);
                    break;

                case nlEnum.PoolObjectTypes.AudioObject:
                    var audio = (AudioObject)poolable;
                    ResetObjects(audio.gameObject, nlEnum.PoolObjectTypes.Cheese);
                    audioObjectPool.Add(audio);
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