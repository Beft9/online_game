using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class health : NetworkBehaviour {


    public const int max_health = 100;
    [SyncVar(hook ="onChangeHealth")]public int cur_health = max_health;
    public RectTransform healthbar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Take_damage(int amount)
    {
        if (!NetworkServer.active)
        {
            return;
        }
        cur_health -= amount;
        if(cur_health <= 0)
        {
            cur_health = 0;
            Debug.Log("DEAD");
            cur_health = 100;
            RpcRespawn();
        }

        
    }
    void onChangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health, healthbar.sizeDelta.y);
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }
}
