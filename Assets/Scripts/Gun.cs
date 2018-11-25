using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [Header("Gun Configuration")]
    public float damage;
    public float range;
    public float firerate;
    public float waitToFirerate;
    public Camera cam;
    public ParticleSystem ammoParticle;
    public bool hold = false;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            hold = true;

        if (Input.GetButtonUp("Fire1"))
            hold = false;

        if (hold == true)
            waitToFirerate += 1;

        if (waitToFirerate > firerate)
            Shoot();

	}
    void Shoot() {
        waitToFirerate = 0;
        ammoParticle.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) {
            Debug.Log("Mirando em: " + hit.transform.name);
        }

    }
}
