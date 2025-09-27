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
        private List<IngiObj> ingredientListPoolBroccoli = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBunBot = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolBunTop = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolPatty = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolDonut = new List<IngiObj>();
        private List<IngiObj> ingredientListPoolPizza = new List<IngiObj>();
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
                    ingredientListPoolBadEgg.Add(bEgg);
                    break;
                case nlEnum.PoolObjectTypes.BadFish:
                    var bFish = (IngiObj)poolObject;
                    ingredientListPoolBadFish.Add(bFish);
                    break;

                case nlEnum.PoolObjectTypes.BadSteak:
                    var bSteak = (IngiObj)poolObject;
                    ingredientListPoolBadSteak.Add(bSteak);
                    break;

                case nlEnum.PoolObjectTypes.Beetroot:
                    var beetroot = (IngiObj)poolObject;
                    ingredientListPoolBeetroot.Add(beetroot);
                    break;
                case nlEnum.PoolObjectTypes.Boot:
                    var boot = (IngiObj)poolObject;
                    ingredientListPoolBoot.Add(boot);
                    break;
                case nlEnum.PoolObjectTypes.Broccoli:
                    var broco = (IngiObj)poolObject;
                    ingredientListPoolBroccoli.Add(broco);
                    break;
                case nlEnum.PoolObjectTypes.Eyeball:
                    var eyeball = (IngiObj)poolObject;
                    ingredientListPoolEyeball.Add(eyeball);
                    break;
                
                case nlEnum.PoolObjectTypes.Rat:
                    var rat = (IngiObj)poolObject;
                    ingredientListPoolRat.Add(rat);
                    break;
                
                case nlEnum.PoolObjectTypes.Spaghetti:
                    var spaghetti = (IngiObj)poolObject;
                    ingredientListPoolSpaghetti.Add(spaghetti);
                    break; 
                
                case nlEnum.PoolObjectTypes.Bun_bot:
                    var bunBot = (IngiObj)poolObject;
                    ingredientListPoolBunBot.Add(bunBot);
                    break;
                
                case nlEnum.PoolObjectTypes.Bun_top:
                    var bunTop = (IngiObj)poolObject;
                    ingredientListPoolBunTop.Add(bunTop);
                    break;
                
                case nlEnum.PoolObjectTypes.Patty:
                    var patty = (IngiObj)poolObject;
                    ingredientListPoolPatty.Add(patty);
                    break;
                
                case nlEnum.PoolObjectTypes.Donut:
                    var donut = (IngiObj)poolObject;
                    ingredientListPoolDonut.Add(donut);
                    break;
                
                case nlEnum.PoolObjectTypes.Pizza:
                    var pizza = (IngiObj)poolObject;
                    ingredientListPoolPizza.Add(pizza);
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

                case nlEnum.PoolObjectTypes.BadEgg:
                    if (ingredientListPoolBadEgg.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.BadEgg);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var bEgg = ingredientListPoolBadEgg[0];
                    ingredientListPoolBadEgg.Remove(bEgg);
                    bEgg.SetParent(null);
                    return bEgg;

                case nlEnum.PoolObjectTypes.BadFish:
                    if (ingredientListPoolBadFish.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.BadFish);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var bFish = ingredientListPoolBadFish[0];
                    ingredientListPoolBadFish.Remove(bFish);
                    bFish.SetParent(null);
                    return bFish;

                case nlEnum.PoolObjectTypes.Beetroot:
                    if (ingredientListPoolBeetroot.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Beetroot);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var bRoot = ingredientListPoolBeetroot[0];
                    ingredientListPoolBeetroot.Remove(bRoot);
                    bRoot.SetParent(null);
                    return bRoot;

                case nlEnum.PoolObjectTypes.Boot:
                    if (ingredientListPoolBoot.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Boot);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var boot = ingredientListPoolBoot[0];
                    ingredientListPoolBoot.Remove(boot);
                    boot.SetParent(null);
                    return boot;

                case nlEnum.PoolObjectTypes.Broccoli:
                    if (ingredientListPoolBroccoli.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Broccoli);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var broc = ingredientListPoolBroccoli[0];
                    ingredientListPoolBroccoli.Remove(broc);
                    broc.SetParent(null);
                    return broc;

                case nlEnum.PoolObjectTypes.Eyeball:
                    if (ingredientListPoolEyeball.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Eyeball);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var eyeBall = ingredientListPoolEyeball[0];
                    ingredientListPoolEyeball.Remove(eyeBall);
                    eyeBall.SetParent(null);
                    return eyeBall;

                case nlEnum.PoolObjectTypes.Rat:
                    if (ingredientListPoolRat.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Rat);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var rat = ingredientListPoolRat[0];
                    ingredientListPoolRat.Remove(rat);
                    rat.SetParent(null);
                    return rat;

                case nlEnum.PoolObjectTypes.Spaghetti:
                    if (ingredientListPoolSpaghetti.Count < 2)
                    //DO SEPARATE LIST FOR EACH INGRIDIENT
                    {
                        var poolObjectData = GetPoolProjectData(nlEnum.PoolObjectTypes.Spaghetti);
                        Spawn(poolObjectData.prefab, 10, poolObjectData.poolObjectType, poolObjectData.spawnParent);
                    }
                    var spag = ingredientListPoolSpaghetti[0];
                    ingredientListPoolSpaghetti.Remove(spag);
                    spag.SetParent(null);
                    return spag;

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
                    var cheese = (IngiObj)poolable;
                    ResetObjects(cheese.gameObject , nlEnum.PoolObjectTypes.Cheese);
                    ingredientListPoolCheese.Add(cheese);
                    break;

                case nlEnum.PoolObjectTypes.BadEgg:
                    var bEgg = (IngiObj)poolable;
                    ResetObjects(bEgg.gameObject, nlEnum.PoolObjectTypes.BadEgg);
                    ingredientListPoolBadEgg.Add(bEgg);
                    break;
                case nlEnum.PoolObjectTypes.BadFish:
                    var bFish = (IngiObj)poolable;
                    ResetObjects(bFish.gameObject, nlEnum.PoolObjectTypes.BadFish);
                    ingredientListPoolBadFish.Add(bFish);
                    break;
                case nlEnum.PoolObjectTypes.Beetroot:
                    var bRoot = (IngiObj)poolable;
                    ResetObjects(bRoot.gameObject, nlEnum.PoolObjectTypes.Beetroot);
                    ingredientListPoolBeetroot.Add(bRoot);
                    break;
                case nlEnum.PoolObjectTypes.Onion:
                    var onion = (IngiObj)poolable;
                    ResetObjects(onion.gameObject, nlEnum.PoolObjectTypes.Onion);
                    ingredientListPoolOnion.Add(onion);
                    break;
                case nlEnum.PoolObjectTypes.Boot:
                    var boot = (IngiObj)poolable;
                    ResetObjects(boot.gameObject, nlEnum.PoolObjectTypes.Boot);
                    ingredientListPoolBoot.Add(boot);
                    break;
                case nlEnum.PoolObjectTypes.Broccoli:
                    var broc = (IngiObj)poolable;
                    ResetObjects(broc.gameObject, nlEnum.PoolObjectTypes.Broccoli);
                    ingredientListPoolBroccoli.Add(broc);
                    break;

                case nlEnum.PoolObjectTypes.Eyeball:
                    var eyeBall = (IngiObj)poolable;
                    ResetObjects(eyeBall.gameObject, nlEnum.PoolObjectTypes.Eyeball);
                    ingredientListPoolEyeball.Add(eyeBall);
                    break;
                case nlEnum.PoolObjectTypes.Rat:
                    var rat = (IngiObj)poolable;
                    ResetObjects(rat.gameObject, nlEnum.PoolObjectTypes.Rat);
                    ingredientListPoolRat.Add(rat);
                    break;
                case nlEnum.PoolObjectTypes.Spaghetti:
                    var spag = (IngiObj)poolable;
                    ResetObjects(spag.gameObject, nlEnum.PoolObjectTypes.Spaghetti);
                    ingredientListPoolSpaghetti.Add(spag);
                    break;

                case nlEnum.PoolObjectTypes.AudioObject:
                    var audio = (AudioObject)poolable;
                    ResetObjects(audio.gameObject, nlEnum.PoolObjectTypes.AudioObject);
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