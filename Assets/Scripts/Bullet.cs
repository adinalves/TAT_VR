using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 velocity;

    float speed = 20f;

    float gravity = 0.5f;

    float wind    = 0;

    BoxCollider collider;


    public int acertosBullet = 0;

    void Start() {

        collider = GetComponent<BoxCollider>();

    }

    void Update() {

        velocity += gravity * Vector3.down * Time.deltaTime;
        velocity += wind * transform.right * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        Collider[] colliders = Physics.OverlapBox(transform.position, collider.size / 2, transform.rotation, LayerMask.GetMask("hittable"));

        if(colliders.Length > 0) {
            
            
            //Debug.Log(transform.position);
           // Debug.Log(typeof(transform.position));
            
            IShotHit hitted = colliders[0].GetComponent<IShotHit>();
            //Debug.Log("Atirou");
            //Debug.Log(transform.position);
           // hitted.Posicao(transform.position);
            if(hitted != null) {
                hitted.Posicao(transform.position);
                acertosBullet++;
                //Debug.Log("Acertou");
               //Debug.Log("Posicao: " + transform.position);
                // hitted.Posicao(transform.position);
                hitted.Hit(velocity.normalized);
            }

            Destroy(gameObject);

        }


    }

    public int getAcertos(){
        //return acertosBullet;
        return acertosBullet;
    }

    public void SetDirection(Vector3 direction) {

        velocity = direction * speed;

    }

}

