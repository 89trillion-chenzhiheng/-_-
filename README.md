# HTTP排行榜技术文档

1. 整体框架

    通过HTTP请求获取数据，使用SimpleJson解析Json，使用快排算法进行排序
    
    
2. 流程图

    主程序流程图：
<img width="166" alt="企业微信截图_2cbe31c4-93f4-45ca-a6d5-d21b5c0c5375" src="https://user-images.githubusercontent.com/93114635/141043820-87f7dd71-a0af-4a1f-bfd9-8ae201b1c7b0.png">
    OSA插件：
<img width="171" alt="企业微信截图_cb92ba90-5d01-4dbc-9ef7-40ea434a8b8b" src="https://user-images.githubusercontent.com/93114635/141044291-905eb96e-36d2-4236-b50a-e5e556a5fc7b.png">
    倒计时功能：
<img width="171" alt="企业微信截图_e14dd6bb-3e66-43b8-bfa6-87f0099ab190" src="https://user-images.githubusercontent.com/93114635/141044709-668ad876-a341-4919-938c-9a86c6152745.png">
    HTTP请求：
    <img width="310" alt="企业微信截图_5a9b6e25-e7a3-4a8e-bde7-537efdab496e" src="https://user-images.githubusercontent.com/93114635/141045951-a1e3a299-90cb-4c55-ada6-f5e5c9bf1b5c.png">


3. 目录结构

<img width="384" alt="企业微信截图_94a856c8-6c02-4c9e-9372-f36b94ccb31d" src="https://user-images.githubusercontent.com/93114635/140716037-46f0ba5e-8503-4cff-9242-7dc7caed97f6.png">


4. 代码逻辑分层

类名| 分类 |主要职责
-------- | -----| ----
GameManager  | Controller|单例模式，提供继承自MonoBehaviour的操作如协程，提供公用或其他地方无法 (获取比较复杂) 获取的资源
BasicListAdapter  | Controller|OSA插件，提供滑动和更新数据功能
JsonRead  | Controller|从文件读取解析数据并存下来，方便之后获取; 同时提供根据奖杯数量排序的方法
RankAPIManager | Controller  |  创建新的HTTP请求，注册请求成功的回调函数，并发送请求
GetHTTPData | Controller | 获取HTTP数据，创建HTTP请求，发送HTTP请求
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
