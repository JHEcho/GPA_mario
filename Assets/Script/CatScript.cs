﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    public GameObject Cha;
    public GameObject Cat;
    public GameObject footprint;

    int disx;
    int disy;
    float speed = 0.5f; // 게임 테스트 후 속도 조정 필요
    float k = 4; // 회피 거리 상수

    private float dist(GameObject Cha, GameObject Cat) // 거리 계산
    {
        Vector3 a = Cha.transform.position;
        Vector3 b = Cat.transform.position;

        disx = (int)((a.x - b.x)*100);
        disy = (int)((a.y - b.y)*100);
        float dis = (disx*disx + disy*disy) / 10000f ;
        

        return dis;
    }

    //충돌검사 함수

    private int abs(int x)
    {
        int a;
        if (x < 0)
            a = -x;
        else
            a = x;

        return a; 
    }

    IEnumerator FootPrint() // 발자국 생성 함수
    {
        Instantiate(footprint, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
    }

	// Use this for initialization
	void Start () {

        StartCoroutine(FootPrint()); // 발자국 생성 시작 코루틴
	}
	
	// Update is called once per frame
	void Update () {

        if (dist(Cha,Cat) > k) // 일정거리 밖 랜덤 이동
        {
            int x = Random.Range(0, 100);

            if (x < 20)
                this.transform.Translate(speed * Time.deltaTime, 0, 0);

            else if (20 <= x && x < 40)
                this.transform.Translate(-speed * Time.deltaTime, 0, 0);

            else if (40 <= x && x < 60)
                this.transform.Translate(0, speed * Time.deltaTime, 0);

            else if (60 <= x && x < 80)
                this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        else // 일정거리 안 회피
        {

            if(abs(disx) > abs(disy))
            {

                if (disx > 0)
                    this.transform.Translate(-speed * Time.deltaTime, 0, 0);
                else
                    this.transform.Translate(speed * Time.deltaTime, 0, 0);

            }
            else
            {
                if (disy > 0)
                    this.transform.Translate(0, -speed * Time.deltaTime, 0);
                else
                    this.transform.Translate(0, speed * Time.deltaTime, 0);
            }

        }

    }
}
