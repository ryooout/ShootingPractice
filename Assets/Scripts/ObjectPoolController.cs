using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    public GameObject poolObject;
    /// <summary>オブジェクトを番号順で保存</summary>
    public List<GameObject> listPoolObjects = new List<GameObject>();
    void Start()
    {
        for(int i = 0;i<20;i++)
        {
            GameObject obj = Instantiate(poolObject,this.transform);//this.transformを加えると、弾がObjectPoolの子オブジェクトとして生成される。
            obj.SetActive(false);
            listPoolObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPooledObject()//データの用意
    {
        for(int i = 0;i<listPoolObjects.Count;i++)
        {　　　　　　　　　　　　//アクティブ化されているか否か
            if(listPoolObjects[i].activeInHierarchy ==false)
            {
                return listPoolObjects[i];//データを返したら終了
            }
        }
        return null;//弾が全てアクティブになった場合
    }
}
