using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject playerObj;
    private Player player;
    private GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        player = playerObj.GetComponent<Player>();
        self = this.gameObject;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !other.isTrigger)
        {
            Debug.Log("!");
            self.SetActive(false);
            player.GetKey();
        }
    }

}
