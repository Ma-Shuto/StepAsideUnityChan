using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
  
    //
    private float goalPos;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //この下から課題
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    //Unityちゃんと障害物発生の距離
    private float posObject = 25.0f;

    //Unityちゃんの現在地
    private float posCurrent;

    //Unityちゃんの過去の位置
    private float posPast;

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        posPast = this.unitychan.transform.position.z;
    }
    // Update is called once per frame
    void Update() {

        posCurrent = this.unitychan.transform.position.z;
  

        //一定の距離ごとにアイテムを生成

        if ((posCurrent-posPast)>posObject&&posCurrent<340)
        {
            goalPos = posCurrent + posObject;
            Debug.Log(goalPos);

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);

            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, goalPos);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 20);
                   
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, goalPos + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, goalPos + offsetZ);
                    }
                }
            }
            posPast = this.unitychan.transform.position.z;
        }   
        
    }

    }


