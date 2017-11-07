using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFService.Model;

namespace WCFService.Database.StorageManage
{
    public class LocationDB
    {
        public List<Location> GetLocations(string sceneName,int locationId, List<int> states, List<int> ifCargos, int areaId,string sUpdTime,string eUpdTime)
        {          
            var db = new PetaPoco.Database("ccs");
            PetaPoco.Sql querySql = new PetaPoco.Sql();
            querySql.Append("SELECT location.* FROM location location");           
            querySql.Append("  WHERE 1=1 ");
            if (locationId>0)
            {
                querySql.Append(new PetaPoco.Sql(" AND location.id=@0",
                                             locationId));
            }
            if (!string.IsNullOrEmpty(sceneName)) 
            {
                querySql.Append(new PetaPoco.Sql(" AND scene_name=@0",
                                             sceneName));
            }
            if (!string.IsNullOrEmpty(sUpdTime))
            {
                querySql.Append(new PetaPoco.Sql(" AND update_time>=@0",
                                             sUpdTime));
            }
            if (!string.IsNullOrEmpty(eUpdTime))
            {
                querySql.Append(new PetaPoco.Sql(" AND update_time<=@0",
                                             eUpdTime));
            }
            if(areaId>0)
            {
                querySql.Append(new PetaPoco.Sql(" AND location.area_ids like '%"+areaId + "%'"));
            }
            
            if (states!=null&&states.Count()>0)
            {
                querySql.Append(new PetaPoco.Sql(" AND location.status IN(@0)", states));
            }
            if (ifCargos!=null&&ifCargos.Count>0) 
            {
                querySql.Append(new PetaPoco.Sql(" AND location.if_cargo IN(@0)", ifCargos));
            }

            querySql.Append(" order by id asc");
            var locationDyna = db.Query<Location>(querySql);
            //查询记录总数
            return locationDyna.ToList();
        }

        public void LocationLock(string scenenName, int locationId)
        {
            var db = new PetaPoco.Database("ccs");
            db.Execute("update location set status=1 where id=" + locationId+ " and scene_name='" + scenenName + "'");
        }

        public void LocationUnLock(string scenenName, int locationId)
        {
            var db = new PetaPoco.Database("ccs");
            db.Execute("update location set status=0 where id=" + locationId + " and scene_name='" + scenenName + "'");
        }

        public void ClearLocation(string scenenName, int locationId)
        {
            var db = new PetaPoco.Database("ccs");
            try
            {
                db.BeginTransaction();
                db.Execute("update location set if_cargo=0 where id=" + locationId + " and scene_name='" + scenenName + "'");
                db.Execute("DELETE  FROM cargo_material WHERE location_id=@0 and scene_name=@1", locationId,scenenName);
                db.Execute("DELETE  FROM cargo_item WHERE location_id=@0 and scene_name=@1", locationId,scenenName);
                db.CompleteTransaction();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
            }
        }

        public Location GetLocation(string scenenName, int locationId) 
        {
            var db = new PetaPoco.Database("ccs");
            List<Location> locationList = db.Query<Location>("SELECT * FROM location WHERE id=@0 and scene_name=@1", locationId,scenenName).ToList();
            return locationList.Count>0?locationList[0]:null;
        }
    }
}
