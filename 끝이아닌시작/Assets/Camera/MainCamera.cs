using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float offsetX = 68.4f;
    [SerializeField]
    private float offsetY = 62.2f;
    [SerializeField]
    private float offsetZ = -68.1f;
    [SerializeField]
    private float followSpeed = 1f;

    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }

    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            this.transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + this.transform.localPosition;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = this.transform.localPosition;
    }
}
