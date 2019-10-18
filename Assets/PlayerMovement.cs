using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        { 
            return;
        }

        float y = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.F))
        {
            CmdSpawner();
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    [Command]
    public void CmdSpawner()
    {
        GameObject n_spawn = Instantiate(spawned, transform.position, Quaternion.identity);
        NetworkServer.Spawn(n_spawn);
    }
}
