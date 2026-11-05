using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    public float cooldownTime = 3f;
    private float cooldownCounter = 0f;
    void Update()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }
    }
}
