using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject DragonEggPrefab;
    public float Speed = 1;
    public float TimeBetweenEggDrops = 1;
    public float LeftRightDistance = 10;
    public float ChanceDirection = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropEgg", 2);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x += Speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftRightDistance || pos.x > LeftRightDistance)
        {
            Speed *= -1;
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < ChanceDirection)
        {
            Speed *= -1;
        }
    }

    void DropEgg()
    {
        var egg = Instantiate(DragonEggPrefab);
        egg.transform.position = transform.position + new Vector3(0, 5, 0);
        Invoke("DropEgg", TimeBetweenEggDrops);
    }
}
