using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metrics.InputMachine
{
    class Program
    {

        public class CreateIngestion
        {
            public long SeqNum { get; set; }
            public int PickedLayers { get; set; }
            public int MachineId { get; set; }
            public long InitDate { get; set; }

            internal void Exec()
            {
                lock (this)
                {
                    try
                    {
                       
                        WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings.Get("ApiUrl").ToString());
                        request.Method = "POST";

                        byte[] byteArray = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this));

                        request.ContentType = "application/json";
                        request.ContentLength = byteArray.Length;

                        Stream dataStream = request.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();

                        WebResponse response = request.GetResponse();
                        Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                        response.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Machine id {MachineId} not working {ex.Message}");
                    } 
                    
                }
            }

        }

        public static int ContextSeqNum { get; set; }

        public static void ExecuteMachine()
        {
            while (true)
            {
                ContextSeqNum++;

                var createIngestion = new CreateIngestion
                {
                    InitDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                    MachineId = int.Parse(Thread.CurrentThread.Name),
                    PickedLayers = new Random().Next(1, 50),
                    SeqNum = ContextSeqNum
                };

                createIngestion.Exec();
                Thread.Sleep(5000);
            }
        }

        static void Main(string[] args)
        {

            ContextSeqNum = 0;
            List<Thread> inputMachineList = new List<Thread>();

            for(var i =0; i < int.Parse(ConfigurationManager.AppSettings.Get("InputMachineAmount").ToString()); i++)
            {

                Thread inputMachine = new Thread(new ThreadStart(ExecuteMachine));
                inputMachine.Name = (i + 1).ToString(); 
                inputMachineList.Add(inputMachine);

            }

            foreach (var item in inputMachineList)
                item.Start();

            Console.ReadLine();

        }
    }
}
