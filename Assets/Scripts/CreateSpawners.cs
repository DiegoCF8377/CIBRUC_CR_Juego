using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpawners : MonoBehaviour
{
    public GameObject spawner;
    GameObject obj;
    int[] posX = {-11000,-20000,-30000,-40000,-44800,-44800,-47300,-47100,
                  -46900,-48000,-49000,-45820,-44410,-42675,-38000,-30000,
                  -19000,-9000,-500,4000,10000,18000,24660,27500,34100,28000,
                  16000};
    int[] posY = {430,430,430,430,1000,4000,8000,16000,24000,27660,29400,
                  28900,24900,20000,19350,15060,10800,10800,10800,10800,
                  10800,10800,8000,5700,4000,430,430};
    int posZ = -45;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        for(i=0; i < 27; i++){
            obj = GameObject.Instantiate(spawner,new Vector3(posX[i],posY[i],posZ),Quaternion.identity);
            if(((i >= 4) && (i < 9)) || ((i > 10) && (i < 14)) || (i == 22) || (i == 24)){
                obj.transform.Rotate(new Vector3(0f,0f,-90f));
            }
            obj.transform.parent = GameObject.Find("SpawnPoints").transform;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
