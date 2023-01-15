using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint basicTurret;
    public TurretBlueprint missileTurret;
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectBasicTurret()
    {
        print("Basic turret selected!");
        buildManager.SelectTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher()
    {
        print("Missile launcher selected!");
        buildManager.SelectTurretToBuild(missileTurret);
    }
}
