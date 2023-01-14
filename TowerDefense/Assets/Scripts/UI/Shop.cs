using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;
    }

    public void PurchaseBasicTurret()
    {
        print("Basic turret selected!");
        buildManager.SetTurretToBuild(buildManager.basicTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        print("Missile launcher selected!");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
