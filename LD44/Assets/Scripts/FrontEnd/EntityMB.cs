using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class EntityMB : MonoBehaviour
{
    private static readonly int Charge = Shader.PropertyToID("_Charge");
    public static GameObject EntityPrefab;
    private Entity _meEntity;
    public MeshRenderer HealthBar;
    private TMP_Text _text;
    private Material _spriteMat;

    private Vector3 _startPos;
    private float _hurtTime;
    private float _attackTime;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _spriteMat = GetComponentInChildren<SpriteRenderer>().material;
    }

    public void Init(Entity e)
    {
        _meEntity = e;
        e.MeEntityMB = this;
        GetComponentInChildren<SpriteRenderer>().sprite = e.EntityArt;
        _text = GetComponent<TMP_Text>();
        _startPos = transform.localPosition;
        
        UpdateHealth();
    }

    private void Update()
    {
        if (_meEntity == null)
            return;
        
        UpdateHealth();

        if (_hurtTime > 0)
        {
            _hurtTime -= Time.deltaTime;
            Color c = new Color(1, 1, 1, 1 + 10 * (_hurtTime * 5 % 2));
            _spriteMat.color = c;
        }
        if (_attackTime > 0)
        {
            Vector3 newPos = _startPos;
            float x = 4.2f * _attackTime - 1.4f;
            // This is a formula for the y position, created by trial and error
            newPos.y += x * x * x * x - 3 * x * x + 2.04f;
            transform.localPosition = newPos;
            _attackTime -= Time.deltaTime;
        }
    }

    private void UpdateHealth()
    {
        float currentHealthFrac = (float) _meEntity.CurrentHealth / _meEntity.MaxHealth;
        HealthBar.material.SetFloat(Charge, currentHealthFrac);
        _text.text = _meEntity.CurrentHealth + " / " + _meEntity.MaxHealth;
    
        if (_meEntity.CurrentHealth <= 0)
        {
            _meEntity.Die();
            if (_hurtTime <= 0)
                Destroy(gameObject);
        }
    }

    private void OnMouseUp()
    {
        BattleActionManager.Click(_meEntity);
    }

    // Don't call me directly
    public void TakeDamage()
    {
        _hurtTime = 1;
    }

    // Don't call me directly
    public void Attack()
    {
        _attackTime = 0.6666f;
    }
}
