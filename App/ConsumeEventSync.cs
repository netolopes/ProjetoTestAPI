using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Models.Entities;

namespace App
{
   public  class ConsumeEventSync
    {


        //liga / desliga
        public void GetLigaDesligaPortaoID(int id, int opcao)
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/Power/"+id+"/"+opcao); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }

        //Portao por id
        public void GetDadosPortaoID(int id) 
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/PortaoId/" + id); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }


        //todos portao
        public void GetAllDadosPortao() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/"); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }

        //adiciona portao no banco
        public void AddDadosPortao() 
        {
            using (var client = new WebClient()) //WebClient  
            {

                var dados = new NameValueCollection();

                //IP
                String strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;


                dados.Add("Ip", addr[3].ToString());
                
                dados.Add("Mac", GetMACAddress().ToString());
                dados.Add("Status", "1");
                dados.Add("Estado", "1");


                var result = client.UploadValues("http://localhost:61251/api/UserAPI/", "POST",dados); //URI  
                Console.WriteLine(Environment.NewLine + result);
                Console.Read();



            }
        }


        //----------------------------------- funcionalidades Camera -------------------------------



        //todos portao
        public void GetAllDadosCamera() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/GetAllCamera"); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }




        //camera por id
        public void GetDadosCameraID(int id)
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/CameraId/" + id); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }



        // adiciona camera no banco
        public void AddDadosCamera()
        {
            using (var client = new WebClient()) //WebClient  
            {

                var dados = new NameValueCollection();

                //IP
                String strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;


                dados.Add("Ip", addr[3].ToString());

                dados.Add("Mac", GetMACAddress().ToString());
                dados.Add("Status", "1");
                

                var result = client.UploadValues("http://localhost:61251/api/UserAPI/GravarCamera/", "POST", dados); //URI  
                Console.WriteLine(Environment.NewLine + result);
                Console.Read();



            }
        }


        //liga/ desliga
       public void GetLigaDesligaCameraID(int id, int opcao)
       {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/PowerCamera/" + id + "/" + opcao); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }



        //verifica ativacao camera  Ativacao/{id}/{ativa}
        public void GetAivacao(int id, int ativa)
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:61251/api/UserAPI/Ativacao/" + id + "/" + ativa); //URI  
                Console.WriteLine(Environment.NewLine + result);
                //Console.Read();
            }
        }




        //------------  fim  metodos camera -------------------------------------

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;

        }




    }
}
