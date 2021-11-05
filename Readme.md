# 排行榜技术文档

1. 整体框架

    使用SimpleJson从Json文件读取数据，使用快排算法进行排序，通过OSA插件将数据处理并展示在UI界面
    
    
2. 流程图

    主程序流程图
<img width="289" alt="截图" src="https://user-images.githubusercontent.com/93114635/140287410-43543413-8b93-42f4-a557-de0a7275abe4.png">
    OSA插件
<img width="279" alt="企业微信截图_33bd60f2-36f7-409d-a3a4-a0d81e7a10f2" src="https://user-images.githubusercontent.com/93114635/140287732-8b789722-b59e-4ba6-a675-c2ca3d2a48d9.png">
    倒计时功能：
<img width="232" alt="企业微信截图_05317721-9801-4209-8f20-4ff440bf1add" src="https://user-images.githubusercontent.com/93114635/140287871-0952ca18-0154-48bc-916c-5dfaa6b0644e.png">

3. 目录结构

<img width="503" alt="企业微信截图_d12ace09-024d-449e-817a-21efb51106c1" src="https://user-images.githubusercontent.com/93114635/140288005-55eda923-7494-430b-b973-31d043320ff3.png">

4. 代码逻辑分层

类名| 分类 |主要职责
-------- | -----| ----
GameManager  | Controller|单例模式，提供继承自MonoBehaviour的操作如协程，提供公用或其他地方无法 (获取比较复杂) 获取的资源
BasicListAdapter  | Controller|OSA插件，提供滑动和更新数据功能
JsonRead  | Controller|从文件读取解析数据并存下来，方便之后获取; 同时提供根据奖杯数量排序的方法
ActorModel  | Model|角色信息
Event  | Model|事件的声明
GameMessageModel  | Model|信息类，管理并储存时间数据类和对象信息类
TimeModel  | Model|时间类，提供将string类型的数据转为天:时:分:秒 提供时间倒计时和时间刷新事件
PlayerMesssageUIShow  | View|玩家排行信息的显示
RankingListPanel  | View|排行榜界面类，提供排行榜相关的操作如打开和关闭
TimeUIShow  | View|倒计时显示，注册时间刷新事件刷新UI显示
ToastShowMessage  | View|显示某一个玩家的名称和奖杯数量

5. 关卡结构

关卡中主要的物体为:GameManager，RankingListPanel，OpenButton

    GameManager:身上挂有GameManager脚本，储存了很多其他对象无法获取或者获取方法比较复杂的方法和资源，在使用上非常方便快捷，可以通过该脚本获取想要获得的方法和资源
    
    OpenButton:打开RankingListpanel界面，并开启计时器 
    
    RankingListPanel:主要有Time，Banner，ToastUIShowItem，CloseButton，
    
    RankingListShow 
    
        Time:计时器显示的UI
        
        Banner:玩家的数据显示
        
        ToastUIShowItem:显示某一个玩家的名称和奖杯数量
        
        CloseButton:关闭排行榜界面并关闭计时器
        
        RankingListShow:OSA插件，提供滑动框，动态修改模块的信息显示和 减少模块的使用
    
6. 优化方案

    ● GameManager脚本应当放在DontDestroyOnLoad下
    
    ● 奖杯排序算法可以使用多种排序，现在为快排算法，如果数据量非常大，
递归的深度会不可想像，可以该用堆排序等对于大数据的排序算法
