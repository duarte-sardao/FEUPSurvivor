using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthController
{
    public GameObject fade;
    public AudioSource healSound;
    public RandomSoundPlayer hurtSound;
    public override void DoDamage(float val, Vector3 pos)
    {
        base.DoDamage(val, pos);
        if (!hurtSound.IsPlaying())
            hurtSound.Play();
    }
    public override bool DoHeal(float val)
    {
        var bol = base.DoHeal(val);
        if(bol)
            healSound.Play();
        return bol;
    }
    protected override void Die()
    {
        fade.SetActive(true);
        base.Die();
    }
}
