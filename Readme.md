1. 整体框架 <br>
  使用按钮时间实现UI反馈，Dotween实现UI动态效果
  
2. 流程图<br>
  UI逻辑
  <img width="280" alt="企业微信截图_c90e325a-7373-4524-823a-e319b447d258" src="https://user-images.githubusercontent.com/93114635/141048504-3ca9da8e-34a9-4bca-bb1f-4a4d91f3685e.png">
  卡片逻辑
  <img width="149" alt="企业微信截图_c1377f8d-8cac-4dec-984f-f66c5217fddc" src="https://user-images.githubusercontent.com/93114635/141038192-df4dd484-8522-4131-b36f-d4d1bb190714.png">
  宝箱逻辑
  <img width="281" alt="企业微信截图_7ccbe6da-1da3-490b-b4ec-a502dabffe6d" src="https://user-images.githubusercontent.com/93114635/141048704-6a5140b7-572a-4f94-874f-d79f955ffa42.png">
  金币池逻辑
<img width="198" alt="企业微信截图_8dc4d88b-475c-43df-a27f-84002a248e24" src="https://user-images.githubusercontent.com/93114635/141039750-00bcddf3-defb-4eec-ab34-05856b8de342.png">
3. 目录结构
<img width="460" alt="企业微信截图_f8095868-0b13-48f0-8652-7d1b535d1599" src="https://user-images.githubusercontent.com/93114635/140706974-0aa0791f-11bf-40f6-a498-69841e86fc96.png">
<img width="382" alt="企业微信截图_97fd372c-0608-4a83-96e2-d35aba01e4be" src="https://user-images.githubusercontent.com/93114635/140706994-abe83cea-772c-4fdb-a096-42163d22efb6.png">



4. 代码逻辑分层

| 类名 | 所属文件 | 主要职责 |
|-----|---------|--------|
| AnalysisJson | Controller | 解析Json数据 |
|GameManager | Controller | 单例模式，提供实例化的物体与物体初始化数据的印射 |
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
