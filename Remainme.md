1. 整体框架 <br>
  使用按钮时间实现UI反馈，Dotween实现UI动态效果
  
2. 流程图<br>
  UI逻辑
  <img width="470" alt="企业微信截图_71c6d5f6-b9e8-48d7-8a3b-9e5903d12b82" src="https://user-images.githubusercontent.com/93114635/140480933-dc5c68ba-3f01-4fab-a0b2-00dee7feed49.png">
  卡片逻辑
  <img width="547" alt="企业微信截图_9ed71a1f-7a25-4116-9699-fa7f82cf8a2a" src="https://user-images.githubusercontent.com/93114635/140481004-cfe219e4-61a9-435a-80a0-fbba31ae8e7a.png">
  宝箱逻辑
  <img width="251" alt="企业微信截图_552c7bec-8a43-4069-a6bc-ba561bcd5954" src="https://user-images.githubusercontent.com/93114635/140481074-87f30393-bf86-4a80-970f-3e9c3dc5ef65.png">
  金币池逻辑
  <img width="217" alt="企业微信截图_35342efb-d79f-490b-b72c-5fa51884d77b" src="https://user-images.githubusercontent.com/93114635/140481109-3d2cc955-cc34-4733-89e7-0466acbd0aa9.png">
3. 目录结构

<img width="410" alt="企业微信截图_ca5d03c8-ed4e-4015-ab34-b0ff90f50a4d" src="https://user-images.githubusercontent.com/93114635/140481283-659e8a1c-31ad-4720-b5fc-a7303962bddc.png">
<img width="563" alt="企业微信截图_dcf74eab-622a-4642-a00c-e46a7f102dc4" src="https://user-images.githubusercontent.com/93114635/140481287-0d8e389a-ca41-4e18-a632-273d2ec95130.png">

4. 代码逻辑分层

| 类名 | 所属文件 | 主要职责 |
|-----|---------|--------|
| AnalysisJson | Controller | 解析Json数据 |
| BlockMessage | Model | 数据块信息类，用于存储从Json中解析好的数据 |
| BlockBase | View | 卡片块基类，实现卡片购买后UI的反馈 |
| Card | View | 非免费卡片，根据类型改变显示的图标和金额 |
| FreeBlock | View | 免费卡片，根据类型显示金币或者钻石 |
| Rewards | View | 宝箱，实现金币飞行特效 |
| StorePanel | View | 动态控制卡片数量及显示 |
| StoreTitle | View | 实时更新金币数量 |

5. 第三方库<br>

    DoTewwn<br>
    用于UI动画序列<br>
    源代码放在PlugIn/DoTween文件夹下<br>
    
    JsonAnalysis
    用于Json解析
    代码下载路径： https://github.com/Bunny83/SimpleJSON
    源代码放在PlugIn/JsonAnalysis文件夹下
    
6. 关卡结构<br>

    Canvas下放置StorePanel(用于封装该功能)
    
    StorePanel下依次放置CanvasCenter，BG，StoreMenu，StoreTitle，Coins
        
        CanvasCenter：用于快速的获取Canvas正中心
        
        BG：StorePanel背景图
        
        StoreMenu：实现滑动功能，该功能的显示UI基本都为该物体的子物体
        
        StoreTitle：正上方信息显示，显示优先级较高
        
        Coins：用于收纳金币飞行特效，显示优先级最高
