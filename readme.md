Tower Defense
開發筆記
Unity版本: 2021.3.2f1
最後更新日: 2023-01-15
開發時數: 27
暫計: https://www.youtube.com/watch?v=VW90z41gd8Y&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=12
從19:17繼續, 缺少放置砲塔時的粒子效果

程式API使用查詢: https://docs.unity3d.com/ScriptReference/index.html
使用介面查詢: https://docs.unity3d.com/Manual/index.html
教學影片: https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=5

起點是藍色, 終點是綠色


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
4.1 簡單來說把建模跟旋轉功能分開, 當想要旋轉建模時, 不更動原先建模的數值, 而是建立新的空Game Object, 然後調整那個空的Game Object,
轉動他的方向軸
5. 要設置輸入或查看 axisName(Input.GetAxis()) 的選項，請轉到Edit > Project Settings > Input Manager。
具體使用查看Script API: Input.GetAxis()
6. 使用Animation控制燈光時, 要先按Preview右邊的紅色按鈕才會記錄變更點

額外補充
關於四元數(Quaternion)
https://douduck08.wordpress.com/2016/06/26/usage-of-unity-quaternion/
中文輸出TextMesh Pro
https://cindyalex.pixnet.net/blog/post/238930883-unity-textmeshpro-%E4%B8%AD%E6%96%87%E5%AD%97%E9%AB%94
https://www.cg.com.tw/UnityTextMeshPro/

2023
01-15
增加貨幣機制跟重構部分程式碼
改善UI
01-14
製作商店頁面, 匯進來的圖片需先在Unity編輯器中變更, Texture Type設置成Sprite
設定Button的OnClick()時, 先把需要的物件拉進來再選擇函數
光線在Animator controller沒有被正常關閉, 後續要花時間處理(經測試後發現只是預覽問題, 實際狀態是正常的)

01-13
製作鏡頭移動, 滑鼠滾輪的滾動不同於點擊左右鍵或按下鍵盤, 滾動不是布林值, 而是一個數值持續增加或減少
而滾動速度會影響數值的增加或減少速度
01-12
利用單例模式(Sigleton pattern)來設計建築管理員
01-10
解決發射後只會出現一次的BUG, 原因是Turret.cs的update method中
程式沒有進入
if (fireCountdown <= 0f)
{
    Shoot();
    fireCountdown = 1f / fireRate;
}
VScode中設置fireRate = 1, 但是unity編輯器(編譯器?)中的fireRate設置成0
1除以0是不合理的, 實際上用print或Debug.log()檢查fireCountdown
會發現fireCountdown會回傳Infinty, Infinty不等於0
所以你的砲塔只會發射第一次的子彈(因為fireRate = 1)
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