using UnityEngine;

public class EntityMB : MonoBehaviour
{
    public MeshRenderer HealthBar;
    private Entity _meEntity;
    private static readonly int Charge = Shader.PropertyToID("_Charge");
    public static GameObject EntityPrefab;

    public void Init(Entity e)
    {
        _meEntity = e;
    }

    private void Update()
    {
        if (_meEntity == null)
            return;
        
        HealthBar.material.SetFloat(Charge, ((float) _meEntity.CurrentHealth) / _meEntity.MaxHealth);
    }

    private void OnMouseUp()
    {
        BattleActionManager.Click(_meEntity);
    }
}
