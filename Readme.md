1. 整体框架<br>
  使用UGUI搭建显示面板，通过事件更新UI显示
  
2. 流程图<br>
  主流程图
  <img width="157" alt="企业微信截图_c404fb2d-3090-402b-bdcf-f67b44dcb372" src="https://user-images.githubusercontent.com/93114635/141046357-c3f04044-3dd2-41d9-83c8-03e52bd377d9.png">
  分数类
  <img width="140" alt="企业微信截图_8d880e18-0de0-4ebb-a867-918a8065b593" src="https://user-images.githubusercontent.com/93114635/141046672-ae5df979-149e-4b7c-8150-89fbf267653e.png">
  赛季更新
  <img width="334" alt="企业微信截图_872373a5-6ac1-4693-9293-1cd638baa3ab" src="https://user-images.githubusercontent.com/93114635/141047122-7bc501ce-65aa-402e-9a77-7f92a8214147.png">

3. 目录结构

<img width="506" alt="企业微信截图_bd1b3794-a59f-4e2d-b62f-639cd0aa6aeb" src="https://user-images.githubusercontent.com/93114635/140717060-7f06281a-885c-425c-be01-56a107990405.png">

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
