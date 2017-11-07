using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WCFService.Model
{
    [PetaPoco.TableName("location")]
    public class Location
    {
        [PetaPoco.Column("id")]
        public int Id { get; set; }

        [PetaPoco.Column("x")]
        public double X { get; set; }

        [PetaPoco.Column("y")]
        public double Y { get; set; }

        [PetaPoco.Column("status")]
        public int Status { get; set; }

        [PetaPoco.Column("if_cargo")]
        public int IfCargo { get; set; }

        [PetaPoco.Column("scene_name")]
        public string SceneName { get; set; }

        [PetaPoco.Column("update_time")]
        public DateTime UpdateTime { get; set; }

        [PetaPoco.Column("area_ids")]
        public string AreaIds { get; set; }

    }
}
