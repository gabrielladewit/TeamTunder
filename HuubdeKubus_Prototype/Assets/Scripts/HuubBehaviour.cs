using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuubBehaviour : MonoBehaviour {
    Pause pause;
    Vector3 startPos;
    GameObject playerObj, camCtrl;
    public float speed;
    public float dist, xDist;
    public float realSpeed, xSpeed;
    public Animator ani;
    public HuubAnimationEvent aniEvent;

    // Use this for initialization
    void Start () {
        speed = 6;
        pause = GameObject.Find("UI").GetComponent<Pause>();
        startPos = this.transform.position;
        playerObj = GameObject.Find("PlayerSphere");
        camCtrl = GameObject.Find("Main Camera Parent");
	}

    // Update is called once per frame
    void Update()
    {
        if(camCtrl != null)
        {
            if (playerObj != null && !pause.isPaused && camCtrl.GetComponent<CameraBehaviour>().initiated)
            {
                //Get vertical distance between player and huub
                dist = Mathf.Abs((playerObj.transform.position - this.transform.position).y);

                //Set speed depending on distance
                if (dist > 15)
                    realSpeed = speed + (dist * 0.1f);
                else
                    realSpeed = speed;

                //Get currentPos on same height
                Vector3 currentPos = this.transform.position;
                currentPos.z = playerObj.transform.position.z;

                //Get direction between player and huub
                Vector3 dirVec = playerObj.transform.position - currentPos;
                dirVec = dirVec.normalized;

                //Move huub in player direction
                transform.Translate(dirVec * realSpeed * Time.deltaTime);
            }
        }

        //Check if huub can grab the player
        if (Vector2.Distance(new Vector2(playerObj.transform.position.x, playerObj.transform.position.y), new Vector2(transform.position.x, transform.position.y)) <= 20f)
        {
            realSpeed = 0;
            ani.SetInteger("State", 1);
        }
    }

    public void SetCamera()
    {
        camCtrl = GameObject.Find("Main Camera Parent");

        if(pause == null)
            pause = GameObject.Find("UI").GetComponent<Pause>();
        pause.setOnClick();
    }
}
