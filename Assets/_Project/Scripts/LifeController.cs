using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    public enum ON_DEFEAT_BEHAVIOUR { DISABLE = 0, DESTROY = 1,  RESTART_SCENE = 2 }

    [SerializeField] private int _currentHp = 10;
    [SerializeField] private int _maxHp = 10;
    [SerializeField] private bool _fullHpOnStart = true;
    [SerializeField] private ON_DEFEAT_BEHAVIOUR _onDefeatBehaviour = ON_DEFEAT_BEHAVIOUR.RESTART_SCENE;

    public int GetHp() => _currentHp;
    public int GetMaxHp() => _maxHp;

    // int valore = life.GetHp() + 5;
    // life.SetHp( life.GetHp() + 5 );
    // life.AddHp( 5 );

    public void AddHp(int amount) => SetHp(_currentHp + amount);

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);

        if (_currentHp != hp)
        {
            _currentHp = hp;

            if (_currentHp == 0)
            {
                Debug.Log($"The {gameObject.name} GameObject has been defeated!");
                switch (_onDefeatBehaviour)
                {
                    default:
                        Debug.LogError($"The option {_onDefeatBehaviour} is not recognized!");
                        break;
                    case ON_DEFEAT_BEHAVIOUR.DISABLE:
                        gameObject.SetActive(false);
                        break;
                    case ON_DEFEAT_BEHAVIOUR.DESTROY:
                        Destroy(gameObject);

                        gameObject.GetComponent<EnemyBase>().DropWeapon();
                        break;
                    case ON_DEFEAT_BEHAVIOUR.RESTART_SCENE:
                        //TODO: Restart the scene
                        break;
                }
            }
        }
    }

    public void SetMaxHp(int maxHp)
    {
        _maxHp = Mathf.Max(1, maxHp);
        SetHp(_currentHp);
    }



    private void Start()
    {
        if (_fullHpOnStart)
        {
            SetHp(_maxHp);
        }
    }
}
