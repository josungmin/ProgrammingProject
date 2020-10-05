using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRenderer : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 direction = (Player.transform.position - transform.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            // 2.맞았으면 Renderer를 얻어온다.
            Renderer Obstacle = hit.collider.gameObject.GetComponentInChildren<Renderer>();

            if (Obstacle != null)
            {
                // 3. Metrial의 Aplha를 바꾼다.
                Material Mat = Obstacle.material;
                Color matColor = Mat.color;
                matColor.a = 0.5f;
                Mat.color = matColor;
            }
        }
    }
}
