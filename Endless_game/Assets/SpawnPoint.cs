using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    internal void spawnItem(GameObject item, Vector3 pos)
    {
        Instantiate(item, pos, Quaternion.identity);
    }

}
