1. 整体框架<br>
主要思路是通过Animator控制角色动画播放，使用碰撞器判断箭矢碰撞扣血<br>
2. 流程图<br>
<img width="322" alt="企业微信截图_100d63d2-4be0-4598-9331-49047817fe32" src="https://user-images.githubusercontent.com/93114635/140698842-91fd3991-ea17-4b66-95f7-a81473738c82.png">

<img width="428" alt="企业微信截图_2639a5dd-af0f-4279-b013-84b17c888afe" src="https://user-images.githubusercontent.com/93114635/140698883-86330e75-17e5-4772-914e-96bcb3974e66.png">

<img width="474" alt="企业微信截图_cf0ef82b-58e2-4373-941e-827fd42c48d4" src="https://user-images.githubusercontent.com/93114635/140698930-edb86681-c16d-4f4e-99a6-713143652f14.png">

3. 目录结构<br>

<img width="410" alt="企业微信截图_cd6ab10c-cb24-4c44-ad58-663435ef8a47" src="https://user-images.githubusercontent.com/93114635/140698991-1664374c-6280-41bc-bd51-27b66197f866.png">

4. 代码逻辑分层

| 类名 |  分类 | 主要职责|
|-----|-------|-------|
| ActorActive |  Controller | Player和Enemy的共有基类，提供了两者共有的行为和属性|
| Arrow |  Controller | 控制箭的移动和销毁，包括箭的碰撞检测，碰撞到敌人就对敌人进行扣血|
| EnemyController |  Controller | 敌人控制类，控制敌人的动画播放和扣血等行为|
| PlayerController |  Controller | 玩家控制类，控制角色的动画播放和攻击等行为|
| GameManager |  Controller | 单例模式，提供实例化的物体与物体初始化数据的印射和敌人扣血的统一方法|
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
