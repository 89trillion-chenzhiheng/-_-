1. 整体框架<br>
主要思路是通过Animator控制角色动画播放，使用碰撞器判断箭矢碰撞扣血<br>
2. 流程图<br>
主流程
<img width="152" alt="企业微信截图_55030b5c-d9f8-49fa-bc33-c6779032a7b9" src="https://user-images.githubusercontent.com/93114635/141040525-25c8b4cd-65a5-444e-9058-202f5988430e.png">
角色动画播放流程
<img width="263" alt="企业微信截图_32114d68-a2f8-4bc0-b6ba-1ac518b56a84" src="https://user-images.githubusercontent.com/93114635/141048232-88be3618-03c7-496f-8264-116c777b8fbf.png">

<img width="253" alt="企业微信截图_6fa00a37-635e-401b-be5c-05fae0920211" src="https://user-images.githubusercontent.com/93114635/141048237-dea641b2-c740-4e8b-9af1-55216f547c8d.png">
箭飞行流程
<img width="281" alt="企业微信截图_fff748f5-56fe-404f-beb2-c78daca8da25" src="https://user-images.githubusercontent.com/93114635/141048342-058a2170-522f-42c6-8ff7-d18e95b7316d.png">


3. 目录结构<br>

<img width="404" alt="企业微信截图_94f722f1-a58f-4f60-937d-043de548db28" src="https://user-images.githubusercontent.com/93114635/140709190-0183f256-d753-4089-83ce-d203d5a1e258.png">

<img width="386" alt="企业微信截图_e728ed01-7276-4cc4-bb91-346f666192f4" src="https://user-images.githubusercontent.com/93114635/140709201-04496804-c373-4afc-a7e0-81c201164a50.png">

4. 代码逻辑分层

| 类名 |  分类 | 主要职责|
|-----|-------|-------|
| ActorActive |  Controller | Player和Enemy的共有基类，提供了两者共有的行为和属性|
| Arrow |  Controller | 控制箭的移动和销毁，包括箭的碰撞检测，碰撞到敌人就对敌人进行扣血|
| EnemyController |  Controller | 敌人控制类，控制敌人的动画播放和扣血等行为|
| PlayerController |  Controller | 玩家控制类，控制角色的动画播放和攻击等行为|
| GameManager |  Controller | 单例模式，提供实例化的物体与物体初始化数据的印射和敌人扣血的统一方法|
| PoolManager |  Controller | 道具池，提供物体的取出和存入方法，内部维护物体的物理位置，提供存放物体的数据空间 |
| ActorModel |  Model | Player和Enemy的信息类，提供了两者的数据信息，从CSV文件中动态读取|
| ActorUIMessageShow |  View | UI控制类，Player和Enemy共用，提供了刷新血量的UI显示|

5. 关卡结构

场景中主要的物体有Ground，GameModelManager，IceArrows，Player，Enemy

    Ground:场景中的地板
    
    GameModelManager:提供GameModelManager脚本，用于获取CSV文件解析后的数据

    IceArrows:用于收纳创建的箭
    
    Player:玩家控制的角色
    
    Enemy:敌人控制的角色
    
    Player与Enemy的物体基本一样:
        由FrostArcher和Canvas组成: 
            FrostArcher是FBX文件，提供角色的模型Canvas用来显示角色的血条，主要有文本显示和滑动条显示
