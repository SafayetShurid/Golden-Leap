using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject coin;
    public GameObject meteor;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform spawnPointCentre;
    public Transform spawnPointRight2;

    public Transform centreGameObject;

    
    public float r1, r2, r3, r4, r5;

    public float speedLeft;
    public float speedRight;
    public float speedCenter;
    public float speedRight2;


    public Transform meteorSpawnPointLeft;
    public Transform meteorSpawnPointRight;

    public float m_r1, m_r2;

    public float meteorSpeedRight;
    public float meteorSpeedLeft;


    void Start()
    {
        r1 = Random.Range(1f,3f);
        r2 = Random.Range(1f, 3f);
        r3 = Random.Range(1f, 3f);
        r4 = Random.Range(1f, 3f);
        m_r1 = Random.Range(5f, 8f);
        m_r2 = Random.Range(1f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoinCenterPoint();
        SpawnCoinLeftPoint();
        SpawnCoinRightPoint();
        SpawnCoinRight2();
        SpawnMeteorLeft();
        SpawnMeteorRight();
    }

    public void SpawnMeteorRight()
    {
        m_r1 -= Time.deltaTime;
        GameObject _coin = null;
        Vector2 dir;
        
        

        if (m_r1 <= 0)
        {
            _coin = Instantiate(meteor, meteorSpawnPointRight.localPosition, Quaternion.identity);
            Rigidbody2D rb = _coin.GetComponent<Rigidbody2D>();
            dir = centreGameObject.position - _coin.transform.position;
            rb.AddForce(dir * meteorSpeedRight, ForceMode2D.Impulse);
            meteorSpeedRight = Random.Range(2.8f, 3.1f);
            m_r1 = Random.Range(8f, 10f);
            
        }
       
    }

    public void SpawnMeteorLeft()
    {
        m_r2 -= Time.deltaTime;
        GameObject _coin = null;
        Vector2 dir;

        if (m_r2 <= 0)
        {
            _coin = Instantiate(meteor, meteorSpawnPointLeft.localPosition, Quaternion.identity);
            Rigidbody2D rb = _coin.GetComponent<Rigidbody2D>();
            dir = centreGameObject.position - _coin.transform.position;
            rb.AddForce(dir * meteorSpeedLeft, ForceMode2D.Impulse);
            meteorSpeedLeft = Random.Range(2.8f, 3.1f);
            m_r2 = Random.Range(12f, 14f);
        }
    }

    public void SpawnCoinLeftPoint()
    {
       
        r1 -= Time.deltaTime;
        GameObject _coin = null;
        Vector2 dir;

        if (r1<=0)
        {
            _coin = Instantiate(coin, spawnPointLeft.localPosition, Quaternion.identity);
            Rigidbody2D rb = _coin.GetComponent<Rigidbody2D>();
            dir = centreGameObject.position - _coin.transform.position;
            rb.AddForce(dir * speedLeft, ForceMode2D.Impulse);
            speedLeft = Random.Range(1.5f, 2.5f);
            r1 = Random.Range(1f, 2f);
        }

    }

    public void SpawnCoinRightPoint()
    {

        r2 -= Time.deltaTime;
        GameObject _coin = null;
        Vector2 dir;

        if (r2 <= 0)
        {
            _coin = Instantiate(coin, spawnPointRight.localPosition, Quaternion.identity);
            Rigidbody2D rb = _coin.GetComponent<Rigidbody2D>();
            dir = centreGameObject.position - _coin.transform.position;
            rb.AddForce(dir * speedRight, ForceMode2D.Impulse);
            r2 = Random.Range(1f, 3f);
            speedRight = Random.Range(1.5f, 2.5f);
        }

    }

    public void SpawnCoinCenterPoint()
    {

        r3 -= Time.deltaTime;
        GameObject _coin = null;
        Vector2 dir;

        if (r3 <= 0)
        {
            _coin = Instantiate(coin, spawnPointCentre.localPosition, Quaternion.identity);
            Rigidbody2D rb = _coin.GetComponent<Rigidbody2D>();
            dir = centreGameObject.position - _coin.transform.position;
            rb.AddForce(dir * speedCenter, ForceMode2D.Impulse);
            r3 = Random.Range(1f, 2f);
            speedCenter = Random.Range(2.5f, 3.5f);
        }

    }

    public void SpawnCoinRight2()
    {

        r4 -= Time.deltaTime;
        GameObject _coin = null;
        Vector2 dir;

        if (r4 <= 0)
        {
            _coin = Instantiate(coin, spawnPointRight2.localPosition, Quaternion.identity);
            Rigidbody2D rb = _coin.GetComponent<Rigidbody2D>();
            dir = centreGameObject.position - _coin.transform.position;
            rb.AddForce(dir * speedRight2, ForceMode2D.Impulse);
            r4 = Random.Range(1f, 2f);
            speedRight2 = Random.Range(2.5f, 3.5f);
        }

    }
}
