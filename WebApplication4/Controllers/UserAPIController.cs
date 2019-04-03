using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication4.Models;

using WebApplication4.Models.Entities;


namespace WebApplication4.Controllers
{
    public class UserAPIController : ApiController
    {


        //Novos
        private IGenericRepository<Portao> repository_portao = null;
        private IGenericRepository<Camera> repository_camera = null;

        public UserAPIController()
        {


            //novos
            this.repository_portao = new GenericRepository<Portao>();
            this.repository_camera = new GenericRepository<Camera>();

        }


        //********************   FUNCIONALIDADES PORTAO **********************************


        // INFORMA SE  O PORTAO ESTA ABERTO OU FECHADO
        [ResponseType(typeof(Portao))]
        [Route("api/UserAPI/EstadoPortao/{id}")]
        [HttpGet]
        public string EstadoPortao(int id)
        {
            var dados = repository_portao.SelectByID(id);
            var estado = dados.Estado;

            Portao p = new Portao();
            return p.TipoEstado(estado);
            
        }


        
        // LIGAR E DESLIGAR PORTAO
        [ResponseType(typeof(Portao))]
        [Route("api/UserAPI/Power/{id}/{opcao}")]
        [HttpGet]
        public string  Power(int id, int opcao)
        {
            var dados = repository_portao.SelectByID(id);
            var estado = dados.Status;

            Portao p = new Portao();
            return  p.LigaDesliga(opcao.ToString());
        
        }

        //LISTAR TODOS PORTAO
        [ResponseType(typeof(Portao))]
        [HttpGet]
        public IEnumerable<Portao> Get()
        {
            var dados = from p in repository_portao.SelectAll()
                        select new Portao()
                        {
                            PortaoId = p.PortaoId,
                            Ip = p.Ip,
                            Mac = p.Mac,
                            Status = p.Status
                         };

                 return dados;
           
        }


        //LISTAR PORTAO POR ID
        [ResponseType(typeof(Portao))]
        [Route("api/UserAPI/PortaoId/{id}")]
        [HttpGet]
        public Portao GetPortaoID(int id)
        {
            var dados = repository_portao.SelectByID(id);
            return dados;

        }



        //Gravar dados,Portao no banco: ip,mac,status
        // POST: api/UserAPI
        [ResponseType(typeof(Portao))]
        [HttpPost]
        public void Post([FromBody] Portao portao)
        {
            if (ModelState.IsValid)
            {

                repository_portao.Insert(portao);
                repository_portao.Save();

                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                throw new HttpResponseException(resp);

            } 
            
     
        }




        //********************   FUNCIONALIDADES CAMERA **********************************

        //LISTAR TODOS CAMERA
        [ResponseType(typeof(Camera))]
        [Route("api/UserAPI/GetAllCamera/")]
        [HttpGet]
        public IEnumerable<Camera> GetAllCamera()
        {
            var dados = from c in repository_camera.SelectAll()
                        select new Camera()
                        {
                            CameraId = c.CameraId,
                            Ip = c.Ip,
                            Mac = c.Mac,
                            Status = c.Status
                        };

            return dados;

        }




        //LISTAR CAMERA POR ID
        [ResponseType(typeof(Camera))]
        [Route("api/UserAPI/CameraId/{id}")]
        [HttpGet]
        public Camera GetCameraID(int id)
        {
            var dados = repository_camera.SelectByID(id);
            return dados;

        }




        // LIGAR E DESLIGAR CAMERA
        [ResponseType(typeof(Camera))]
        [Route("api/UserAPI/PowerCamera/{id}/{opcao}")]
        [HttpGet]
        public string PowerCamera(int id ,int opcao)
        {
            var dados = repository_camera.SelectByID(id);
           // var estado = dados.Status;

            Camera p = new Camera();
            return p.LigaDesliga(opcao.ToString());

        }




        //Gravar dados,Camera no banco: ip,mac,status
        // POST: api/UserAPI
        [ResponseType(typeof(Camera))]
        [Route("api/UserAPI/GravarCamera/")]
        [HttpPost]
        public void GravarCamera([FromBody] Camera camera)
        {
            if (ModelState.IsValid)
            {

                repository_camera.Insert(camera);
                repository_camera.Save();

                var resp = new HttpResponseMessage(HttpStatusCode.Created);
                throw new HttpResponseException(resp);

            }


        }


        // VERIFICAR ATIVACAO
        [ResponseType(typeof(Camera))]
        [Route("api/UserAPI/Ativacao/{id}/{ativa}")]
        [HttpGet]
        public string Ativacao(int id, int ativa)
        {
            var dados = repository_camera.SelectByID(id);
         
            Camera p = new Camera();
            return p.SensorMov(ativa.ToString());

        }


        




    }
}
