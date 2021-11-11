1. 整体框架<br>
主要思路是通过Animator控制角色动画播放，使用碰撞器判断箭矢碰撞扣血<br>
2. 流程图<br>
主流程
<img width="152" alt="企业微信截图_55030b5c-d9f8-49fa-bc33-c6779032a7b9" src="https://user-images.githubusercontent.com/93114635/141040525-25c8b4cd-65a5-444e-9058-202f5988430e.png">
角色动画播放流程
<img width="518" alt="企业微信截图_16b65bcc-dbcb-4e07-99ad-d692a754f8c4" src="https://user-images.githubusercontent.com/93114635/141233620-dbe133e8-dee4-4683-a815-8936c5c05143.png">
箭飞行流程
<img width="329" alt="企业微信截图_ab96f78a-9af8-41ab-b7cd-b53be39c0c2e" src="https://user-images.githubusercontent.com/93114635/141234687-84bbb656-ef0d-4128-baa9-917e5cf572cf.png">
道具池流程：
<img width="520" alt="企业微信截图_35aab0f4-de64-4f2e-a287-d12e33036d0b" src="https://user-images.githubusercontent.com/93114635/141236079-f65c4815-da7f-4c38-8155-47519f177f39.png">
<img width="419" alt="企业微信截图_10ae7695-1df8-4e3f-9955-cc5883692fd5" src="https://user-images.githubusercontent.com/93114635/141236081-2b3ce06b-1eec-4199-9782-4ec12bfcc823.png">

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
