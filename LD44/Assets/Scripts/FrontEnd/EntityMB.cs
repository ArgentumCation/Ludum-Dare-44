using UnityEngine;

public class EntityMB : MonoBehaviour
{
    public SpriteRenderer HealthBar;
    private Material _healthBarMaterial;
    private Entity _meEntity;
    private static readonly int Charge = Shader.PropertyToID("Charge");

    private void Start()
    {
        _healthBarMaterial = HealthBar.material;
    }

    private void Init(Entity e)
    {
        _meEntity = e;
    }

    private void Update()
    {
        if (_meEntity == null)
            return;
        
        _healthBarMaterial.SetFloat(Charge, ((float) _meEntity.CurrentHealth) / _meEntity.MaxHealth);
    }

    private void OnMouseUp()
    {
        BattleActionManager.Click(_meEntity);
    }
}
