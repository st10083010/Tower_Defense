Tower Defense
開發筆記
Unity版本: 2021.3.2f1
最後更新日: 2023-01-08
開發時數: 14.5
暫計: 

程式API使用查詢: https://docs.unity3d.com/ScriptReference/index.html
使用介面查詢: https://docs.unity3d.com/Manual/index.html
教學影片: https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=5
下次從第5部影片開始

起點是藍色, 終點是綠色

製作流程
1. 先開發地圖, 從小方格開始慢慢擴大, 接著刪除不必要的方格當作敵人的攻擊路線
2. 設置起點與終點, 設置敵人並設成預置物, 製作完成後可先刪除在Hierarchy中的敵人物件, 接著製作導航點(waypoint), 讓敵人沿著導航點前進, 一路前進到終點
3. 開始寫程式, 建立一個長度為導航點總數的陣列, 利用for loop走訪導航點並添加至該陣列中
4. 將敵人預置物移到起點並設置敵人移動的程式
5. 製作敵人重生點, 製作UI

注意事項
0. 需要找時間替換文字樣式而不使用預設
1. UI的text已棄用, 改成`TMPro(TextMesh Pro)`
具體使用參考: 
 > https://gamedevtraum.com/en/game-and-app-development-with-unity/basic-unity-engine-management/how-to-write-a-text-mesh-pro-text-from-script-in-unity/
 > https://www.cg.com.tw/UnityTextMeshPro/
2. 使用模型時, 須將錨點從Center改成Pivot, 從Global改成Local
3. Scene視窗右上角的Shading mode可以切換Scene中的物件渲染方式
4. 如果需要讓建模旋轉, 可以建立空的Game Object在交接處, 讓建模成為他的子物件, 然後旋轉那個空的Game Object
注意, 要讓空Game Object跟建模的方向一樣, 不然旋轉時畫面會很奇怪

額外補充
關於四元數(Quaternion)
https://douduck08.wordpress.com/2016/06/26/usage-of-unity-quaternion/

2023
01-09
子彈發射後只會出現一次, 需要除bug, 從第五部的13:23開始找問題
如果解決, 直接開始第六部
01-08
建立UI時, 使用TextMesh Pro

01-07
利用空的Game Object存放Hierarchy中的物件
每次建立空的Game Object時要記得reset位置(position歸零)
在Project中建立預置物(Prefabs)以確保後續產出的物件都是一樣的
調整Directional Light可以改變場景中的光線, 包含顏色、角度等等
利用空的Game Object並設置3D icon當作導航點(waypoint)