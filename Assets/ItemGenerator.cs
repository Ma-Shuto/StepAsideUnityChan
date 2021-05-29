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
  
    //ゴール地点
    private float goalPos;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //この下から課題
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

    }
    // Update is called once per frame
    void Update() {
      
        goalPos = this.unitychan.transform.position.z + 40;



        //一定の距離ごとにアイテムを生成

        if ((goalPos % 40) <= 1 && goalPos < 350)
        {

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
                    int offsetZ = Random.Range(-10, 30);
                   
                    if (1 <= item && item <= 5)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, goalPos + offsetZ);
                    }
                    else if (6 <= item && item <= 8)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, goalPos + offsetZ);
                    }
                }
            }

        }   
        
    }

    }


