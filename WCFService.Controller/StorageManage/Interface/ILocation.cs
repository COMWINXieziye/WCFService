using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFService.Controller.StorageManage.Interface
{
    public interface ILocation
    {

        public string GetLocations(string sceneName, int locationId, string statusJsonArray, string ifCargoJsonArray, int areaId, string sUpdTime, string eUpdTime);

        public string LocationLock(string scenenName, int locationId);

        public string LocationUnLock(string scenenName, int locationId);

    }
}
