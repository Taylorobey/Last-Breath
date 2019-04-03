using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followenemy : MonoBehaviour
{
    #region Variables
    public Transform Player;
    public float WalkSpeed = 3f;
    GameObject player;
    #endregion

    #region Methods
    void FixedUpdate()
    {
        transform.LookAt(Player.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        if (Vector3.Distance(transform.position, Player.position) > 1f)
        {
            transform.Translate(new Vector3(WalkSpeed * Time.deltaTime, 0, 0));
        }
    }
    #endregion
}
