using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/EnemyRocket")]
public class EnemyRocket : Rocket
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Player")
            return;

        Destroy(this.gameObject);
    }
}
