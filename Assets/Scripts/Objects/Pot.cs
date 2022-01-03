
using UnityEngine;
using System.Collections;

public class Pot : Collectable
{
    private Animator anim;
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void OnCollect()
    {
        if(!collected){
            collected = true;
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy(){
        anim.SetBool("Destroy",true);
        yield return null;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
