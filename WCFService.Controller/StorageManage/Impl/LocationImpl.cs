using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFService.Controller.StorageManage.Interface;

namespace WCFService.Controller.StorageManage.Impl
{
   public  class LocationImpl:ILocation
    {
        public string GetLocations(string sceneName, int locationId, string statusJsonArray, string ifCargoJsonArray, int areaId, string sUpdTime, string eUpdTime)
        {
           throw new NotImplementedException();
        }

        public string LocationLock(string scenenName, int locationId)
        {
            throw new NotImplementedException();
        }

        public string LocationUnLock(string scenenName, int locationId)
        {
            throw new NotImplementedException();
        }
    }
}
