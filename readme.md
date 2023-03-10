# Tower Defense
## 開發筆記
Unity版本: 2021.3.2f1  
最後更新日: 2023-01-29  

## 操作說明
`WSAD`或游標貼邊可以移動鏡頭, 滾輪可以縮放鏡頭  
左`Ctrl`鎖定鏡頭  
  
## 影片Demo
[Tower Defense Demo](https://www.youtube.com/watch?v=HoWZv0go3so)

## 遊戲載點

## 注意事項
1. UI的text已棄用, 改成`TMPro(TextMesh Pro)`
具體使用參考: 
 > (https://gamedevtraum.com/en/game-and-app-development-with-unity/basic-unity-engine-management/how-to-write-a-text-mesh-pro-text-from-script-in-unity/)
 > (https://www.cg.com.tw/UnityTextMeshPro/)
2. 使用模型時, 須將錨點從`Center`改成`Pivot`, 從`Global`改成`Local`
3. Scene視窗右上角的`Shading mode`可以切換Scene中的物件渲染方式
4. 如果需要讓建模旋轉, 可以建立空的`Game Object`在交接處, 讓建模成為他的子物件, 然後旋轉那個空的`Game Object`
 > 要讓空`Game Object`跟建模的方向一樣, 不然旋轉時畫面會很奇怪
 > 簡單來說把建模跟旋轉功能分開, 當想要旋轉建模時, 不更動原先建模的數值, 而是建立新的空`Game Object`, 然後調整那個空的`Game Object`,
轉動他的方向軸
5. 要設置輸入或查看 `axisName(Input.GetAxis())` 的選項，請轉到`Edit > Project Settings > Input Manager`。
具體使用查看`Script API: Input.GetAxis()`
6. 使用Animation控制燈光時, **要先按Preview右邊的紅色按鈕才會記錄變更點**
7. 光暈也可以用粒子(Particle System)製作, 停止粒子的移動速度再調整細節就行
 > 粒子特效(Particle System)搭配`Color Over Lifetime`調整透明度, 可以達到閃爍效果
8. 製作遊戲結束畫面時, 先將畫面設為禁用, 再透過程式, 當條件符合遊戲結束時, 啟用遊戲結束畫面
9. 使用`UnityEngine.SceneManagement`進行場景跳轉或重新載入的相關操作
10. 砲塔升級/販售UI: 建立一個空的`Game Object`, 放入UI(Canvas), 座標設定為當前砲塔座標, 接著把`Render Mode`設定成`World Space`, 最後切回`World`視角, 調整成符合遊戲視角且想要的角度
11. 可以利用HTML5 tags給文字基本變化(Rich Text)
12. 當使用`Time.timeScale`控制時間時, 會連動畫一起控制。所以如果要在暫停畫面時繼續動畫, 要把對應動畫(此處是暫停畫面)的`Animator`中的`Update Mode`改成`Unscale Time`
13. 如果UI的Button要做成動畫, 可以將`Transition`改成`Animation`, 點擊`Auto Generate Animation`產生並製作想要的動畫
14. `Canvas`的`Sort order`可以變更疊圖順序(圖層概念)
15. 點選`Main Camera`, 切到`Scene`視窗, 按下`Ctrl + Shift + F`, 可以迅速將`Game`視窗的鏡頭切到當前畫面
16. 利用`Scroll Rect`可以製作滾動的關卡選擇畫面
17. 在關卡選擇中, 在`Content`物件上增加`Canvas Renderer`跟`Image`的Component, 並把`Image`的透明度調到0, 就可以解決在滾動時不觸碰按鈕才能滾動的問題
18. 利用UI中的`Scrollbar`製作側邊滾動條
19. 使用`PlayerPrefs`儲存玩家進度或資訊時, 並不需要也不會加密, 所以不要儲存機密資訊

## 額外補充
 - 關於四元數(Quaternion)  
(https://douduck08.wordpress.com/2016/06/26/usage-of-unity-quaternion/)  
 - 中文輸出TextMesh Pro  
(https://cindyalex.pixnet.net/blog/post/238930883-unity-textmeshpro-%E4%B8%AD%E6%96%87%E5%AD%97%E9%AB%94)  
(https://www.cg.com.tw/UnityTextMeshPro/)  
 - 函式執行順序  
(https://kendevlog.wordpress.com/2018/09/26/unity%E9%96%8B%E7%99%BC%E7%AD%86%E8%A8%98%EF%BC%9A%E8%85%B3%E6%9C%AC%E7%9A%84%E9%A0%86%E5%BA%8F-execution-order/)
 - 物件池(Object pool)  
(https://learn.unity.com/tutorial/introduction-to-object-pooling#)  
(https://tedsieblog.wordpress.com/2016/07/10/object-pool/)  

## 預計新增/修改
1. [ ] 敵人被擊中時, 會閃紅光
2. [ ] 敵我雙方生命值, 倒數計時會隨著歸零的幅度換色(綠 -> 黃 -> 紅)
3. [ ] 考慮在UI上增加更為明確的金錢、倒數計時等數值, 而不是要拉到最大才看的到, 但不移除地圖上的UI
4. [ ] 平衡性調整: 價格、掉落金幣、砲塔射速、起始金額、波次時間、砲塔範圍等等
5. [ ] 變更雷射砲塔的雷射(要花時間研究)
6. [ ] 考慮使用`Quaternion.RotateTowards`而不是`Quaternion.Lerp`來旋轉砲塔。
 > 如果你將一個不動的敵人放在砲塔的範圍內並記錄砲塔的旋轉，你會發現它永遠不會停止轉動！
 > 儘管它在這裡並不那麼重要，但它是一種資源的巨大浪費，因為我們需要在每一幀中一遍又一遍地計算 lerp 的東西，並且永遠不會完成 lerp！
 >（想像一下有數千個砲塔同時旋轉並且永遠不會完成）
 > 砲塔在某個時候停止轉動的唯一原因是因為敵人死亡或超出射程。
7. [ ] 升級砲塔特效
8. [ ] 全面性的更換材質或建模(盡可能)
9. [x] 當最後一波產生後幾秒會結束遊戲`WaveSpawner.cs`中的`SpawnWave`有問題, 獲勝條件的檢查項目不對
10. [ ] 第二關重製
11. [ ] 增加音效、背景音樂
12. [ ] 看狀況自架網站說明
  
## 其他
開發時數: 63.8   
暫計:  
起點是藍色718BF0, 終點是粉色F0A089  
  
程式API使用查詢: (https://docs.unity3d.com/ScriptReference/index.html)  
使用介面查詢: (https://docs.unity3d.com/Manual/index.html)  
教學影片: (https://www.youtube.com/watch?v=oqidgRQAMB8&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=1)  
  
## 更新日誌
### 2023  
01-28  
改善UI配色; 調整建造砲塔時的特效  
01-27  
增加獲勝畫面; 修復獲勝條件BUG  
01-26  
增加關卡選單、側邊條、重構重生點程式碼, 現在可以一波多種敵人了  
01-24  
增加暫停介面與特效; 重構部分程式碼  
增加血量條; 設置場景轉換(未完)  
完成場景設置、選單畫面  
01-23  
增加 販售機制; 販售特效  
01-22  
新增 遊戲結束UI; 砲塔升級或選擇UI;  
01-21  
整理程式碼  
增加緩速功能  
01-20  
把Line renderer放在砲塔上(模仿影片)就正常了, 而不使用另外建立game object的方式  
增加雷射碰撞粒子、光線效果  
01-18  
光束有正常追蹤敵人但不顯示, 須找出問題  
01-17  
增加雷射砲塔, 光束設置中  
01-16  
增加敵人死亡效果; 生命值系統  
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
```
if (fireCountdown <= 0f)
{
    Shoot();
    fireCountdown = 1f / fireRate;
}
```
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