﻿using TMPro;
using UnityEngine;

public class EntityMB : MonoBehaviour
{
    private static readonly int Charge = Shader.PropertyToID("_Charge");
    public static GameObject EntityPrefab;
    private Entity _meEntity;
    public MeshRenderer HealthBar;
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void Init(Entity e)
    {
        _meEntity = e;
        GetComponentInChildren<SpriteRenderer>().sprite = e.EntityArt;
        
        float currentHealthFrac = (float) _meEntity.CurrentHealth / _meEntity.MaxHealth;
        HealthBar.material.SetFloat(Charge, currentHealthFrac);
        _text = GetComponent<TMP_Text>();
        _text.text = _meEntity.CurrentHealth + " / " + _meEntity.MaxHealth;
    }

    private void Update()
    {
        if (_meEntity == null)
            return;

        float currentHealthFrac = (float) _meEntity.CurrentHealth / _meEntity.MaxHealth;
        HealthBar.material.SetFloat(Charge, currentHealthFrac);
        _text.text = _meEntity.CurrentHealth + " / " + _meEntity.MaxHealth;
        
        if (_meEntity.CurrentHealth <= 0)
        {
            _meEntity.Die();
            Destroy(gameObject);
        }
    }

    private void OnMouseUp()
    {
        BattleActionManager.Click(_meEntity);
    }
}
