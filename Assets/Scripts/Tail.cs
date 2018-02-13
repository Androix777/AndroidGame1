using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {
    bool st=false;
    Vector3 start,end;
    public float force;
    public ParticleSystem ps;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	/*void Update ()
    {if (st){
        
        ParticleSystem.EmissionModule emission=ps.emission;
        ParticleSystem.MainModule main= ps.main;
        

        emission.rateOverTime =50f;
        main.gravityModifier =0f;

    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
        ps.GetParticles(particles);
     for (int i = 0; i < particles.Length; i++)
    {

        ParticleSystem.Particle particle = particles[i];
        Vector3 particleWurldPosition;
        particleWurldPosition = transform.TransformPoint(particle.position);
        Vector3 directionToTarget = (end - start).normalized; 
        Vector3 seekForce = (directionToTarget * force) * Time.deltaTime;
        particle.velocity = seekForce; 
        particles[i] = particle;
    }
    ps.SetParticles(particles,particles.Length);
    }
	}*/
    private void FixedUpdate()
    {
        if (!Statsgame.GetTestMode())
        {      
        if (transform.position.x <= -60f) { Destroy(gameObject, 0); }      
        transform.Translate(Vector3.left * Statsgame.Getspeed() * Time.deltaTime,Space.World); }
    }

    public void setTail (Vector3 starts , Vector3 ends){
        start=starts;
        st=true;
        end=ends;
        
        transform.rotation = Quaternion.Euler(0,0,SetDirRot(Vector3.Normalize(end-start)));

      
       // force=force*Vector3.Distance(start,end);

    }
    
     public static float Angle(Vector3 start, Vector3 end)
    {
        float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * 180 / Mathf.PI;
        if (0.0f > angle)
            angle += 360.0f;
        return angle;
    }

    float SetDirRot(Vector3 to)
    {
        Vector3 heading = to ;
        Vector3 direction = heading / heading.magnitude;
        float angle = Angle(Vector3.zero, heading);
        return angle - 180;
    }
}
