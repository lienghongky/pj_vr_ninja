using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class objact : MonoBehaviour
{

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0)*2);
            // 오른쪽 방향키 공 오른쪽으로 이동
        if (Input.GetKey(KeyCode.RightArrow))
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0)* 2);
            // 위 방향키 공 앞으로 이동
        if (Input.GetKey(KeyCode.UpArrow))
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * 2);
            // 아래 방향키→공 뒤로 이동 
        if (Input.GetKey(KeyCode.DownArrow))
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1)* 2);
            // Space 키 누를시 점프 
        if (Input.GetKey(KeyCode.Space))
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0)* 3);
            // Esc 키 누르면 해당 scene 다시 실행 
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}
