using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.Entities
{
    public class Camera : Base
    {
        public int CameraId { get; set; }

       
        public string SensorMov(string valor)
        {
            if (valor == "1")
            {
                return "Ativado";
            }
            else
            {
                return "Desativado";
            }

        } 
    }
}