using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Net;
using System.Net.NetworkInformation;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
        
            ConsumeEventSync objsync = new ConsumeEventSync();

            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            Console.WriteLine("Local Machine's Host Name: " + strHostName);
            //IP
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
                     //  for (int i = 0; i < addr.Length; i++)
                    //    {
                    //        Console.WriteLine("IP Address {0}:{1} ",i, addr[i].ToString());
                    //    }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("IP Address {0} ", addr[3].ToString());
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("MAC Address {0} ", GetMACAddress().ToString());
            Console.WriteLine("------------------------------------------------------------");

           
            //****************  FUNCIONALIDADES PORTAO  ********************
            
            
            
            //RETORNA LISTA de dados Portao 
             objsync.GetAllDadosPortao();

            //RETORNA Dados Portao POR ID . ex: 1,2,3
           // objsync.GetDadosPortaoID(1);

            //ADICIONA Dados(ip,mac,status) da app no BANCO
            //objsync.AddDadosPortao();

            //Metodo Liga/Desliga Portao POR ID . param1 => ex:1,2,3   param2 =>  ex: 1 = Ligar, 2 = Desligar
            //Nesse metodo chama o portaoId = 1 , passando 2 = desligar 
            //objsync.GetLigaDesligaPortaoID(1,2);


            //****************  FUNCIONALIDADES CAMERA  ********************


            //lista todas cameras
            //objsync.GetAllDadosCamera();

            //ADICIONA Dados(ip,mac,status) da app no BANCO
            // objsync.AddDadosCamera();

            //Metodo Liga/Desliga Portao POR ID . param1 => ex:1,2,3   param2 =>  ex: 1 = Ligar, 2 = Desligar
            //Nesse metodo chama o portaoId = 1 , passando 2 = desligar 
            //objsync.GetLigaDesligaCameraID(1,2);


            //RETORNA Dados camera POR ID . ex: 1,2,3
            //objsync.GetDadosCameraID(1);

            // param1 é o id da camera => ex:1,2,3   e  param2 =>  ex: 1 = Ativar, 2 = Desativar
            // objsync.GetAivacao(1,2);

            Console.ReadLine();
        }


        public static  string GetMACAddress()
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
