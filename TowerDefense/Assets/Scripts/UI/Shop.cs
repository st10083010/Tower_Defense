using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint basicTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserBeamer;
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void SelectBasicTurret()
    {
        // 基本砲塔
        print("Basic turret selected!");
        buildManager.SelectTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher()
    {
        // 導彈發射器
        print("Missile launcher selected!");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserBeamer()
    {
        // 雷射砲塔
        print("Laser beamer selected!");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
