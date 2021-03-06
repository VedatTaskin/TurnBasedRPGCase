using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
using System;

public class DefaultCharacterControl : StateManager, IDamagable 
{
    protected Slider slider;
    protected int sliderMaxValue;
    protected Text text;
    protected BoxCollider2D boxCollider2D;

    public int AP;
    public int HP;

    public override void OnEnable()
    {
        base.OnEnable();
        SetSliderAndText();
    }

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }

        slider.value = (float)HP / sliderMaxValue;

        transform.DOShakePosition(0.5f, 1, 10, 30); // we give some shake
        StartCoroutine(CloseColliderLittleTime(1.5f));
    }

    public virtual void Die(){}

    public virtual void SetSliderAndText()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<Text>();
        sliderMaxValue = HP;
        slider.value = (float) HP / sliderMaxValue;
        text.text = gameObject.name;
    }

    // we close colider some time to prevent double hit
    public IEnumerator CloseColliderLittleTime(float t)
    { 
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(t);
        boxCollider2D.enabled = true;
    }

}
