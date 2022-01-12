using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;
using System;

public class DefaultCharacterControl : StateManager, IPointerClickHandler, IDamagable 
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

    public virtual void OnPointerClick(PointerEventData eventData){}

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }

        slider.value = (float)HP / sliderMaxValue;

        transform.DOShakePosition(0.5f, 1, 10, 30); // we give some shake
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

    public virtual void OnTriggerEnter2D(Collider2D collider2D) { }

    // we close colider some time to prevent double hit
    public IEnumerator CloseColliderLittleTime(float t)
    { 
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(t);
        boxCollider2D.enabled = true;
    }

}
