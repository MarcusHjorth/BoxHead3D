using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform muzzle; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(prefab, position, rotation)
            Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
            
            RaycastShooting();
        }
    }

    void RaycastShooting()
    {
        Vector3 direction = muzzle.forward;
        RaycastHit hit;
        
        if (Physics.Raycast(muzzle.position, direction, out hit, 1000))
        {
            //Destroy(hit.transform.gameObject);
            
            GameObject obj = hit.transform.gameObject;
            Animator animator = obj.GetComponentInParent<Animator>();

            if (!animator) return;
            
            animator.SetTrigger("OpenGate");
        }
    }
    
    void ProjectileShooting()
    {
        Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
    }
}