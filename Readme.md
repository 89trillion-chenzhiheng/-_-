1. 整体框架<br>
  使用UGUI搭建显示面板，通过事件更新UI显示
  
2. 流程图<br>
  主流程图
<img width="140" alt="企业微信截图_cce07065-e665-4485-a676-84ed68ca9fe8" src="https://user-images.githubusercontent.com/93114635/140472625-ccc8ad7a-820f-4d21-9630-6a0817567cfe.png">
  分数类
  <img width="147" alt="企业微信截图_0e3a8f9b-cae9-428b-a851-349576df85f6" src="https://user-images.githubusercontent.com/93114635/140473294-628fdc2b-9edb-4456-a87d-6e42ac2485b5.png">
  赛季更新
  <img width="356" alt="企业微信截图_dcae4270-d40f-4e28-96b0-391787c43c43" src="https://user-images.githubusercontent.com/93114635/140473754-fc2696b9-1bcf-49e5-ba12-348267575043.png">

3. 目录结构

<img width="371" alt="企业微信截图_ae73a55f-71de-4362-bc5e-6ce26323f3f3" src="https://user-images.githubusercontent.com/93114635/140474126-4997ab77-8d15-4539-bb58-d1c11515d300.png">

4. 代码逻辑分层

| 类名  | 分类 | 主要职责|
|-------|-----|-------|
| CoinModel  | Model | 金币类，封装金币的相关操作如加上金币触发金币刷新事件等|
| Event | Model |委托类，创建委托|
| ScoreModel | Model | 分数类，封装分数的相关操作如分数更新触发分数刷新事件，分数隔一段时间进行增加等 |
|LadderOnHighBuildingsPanel |View | 冠军联盟信息展示面板类，提供该面板的相关操作如增加金币，刷新段位 |
| RewardItem | View | 奖励模块，提供奖励的领取操作 |

5. 关卡结构

关卡内主要的有LadderOnHighBuildingsPanel界面
    
    LadderOnHighBuildingsPanel界面主要组成部分有：三个Button(AddScoreBtn，SeasonRefreshBtn，ViewSegmentBtn)，MessageShowItem，RewardScrollRect
    
    三个Button：分别对应 加分，赛季刷新，显示段位操作
    
    MessageShowItem：提供信息的UI显示：段位显示，赛季显示，金币显示，分数显示
    
    RewardScrollRect：奖励显示列表，提供滑动框
