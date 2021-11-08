using System;
using System.Collections.Generic;
using Model;
using TableConfig;
using UnityEngine;

namespace Model
{
    public class GameModelManager : MonoBehaviour
    {
        public static GameModelManager instance;

        private void Awake()
        {
            instance = this;
        }

        #region ActorModel

        private ITable2Data<ActorModel> actorModelTable;
        private List<ActorModel> actorModel;

        private ITable2Data<ActorModel> actorModelTableList => actorModelTable ?? (actorModelTable = new TableManager<ActorModel>());

        public List<ActorModel> GetActorModel()
        {
            return actorModel ?? (actorModel = actorModelTableList.GetAllModel());
        }

        public ActorModel GetActorModel(int id)
        {
            var actorModelDic = GetActorModelDic();

            if (actorModelDic != null && actorModelDic.ContainsKey(id))
            {
                return actorModelDic[id];
            }

            return null;
        }

        private Dictionary<int, ActorModel> ActorModelDic;

        public Dictionary<int, ActorModel> GetActorModelDic()
        {
            if (ActorModelDic == null)
            {
                ActorModelDic = new Dictionary<int, ActorModel>();
                List<ActorModel> list = GetActorModel();
                foreach (var item in list)
                {
                    ActorModelDic.Add(item.id, item);
                }
            }

            return ActorModelDic;
        }

        #endregion
    }
}