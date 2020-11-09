using System;
using System.Threading;
using System.Net.Http;
using System.Collections.Generic;
using TaskBeater.Models;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskBeater
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static int i = 0;
        static void Main(string[] args)
        {
            var taskNum = 10000;

            while(true){                    
                BulkyRequest(taskNum);                            
            }

        }

        public static void BulkyRequest(int taskNum){

            Action[] actions = new Action[taskNum];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int ii = 0; ii < taskNum; ii++)           
            {
                actions[ii] = new Action(()=>{NewBeat(ii,taskNum);});         
            }

            Parallel.Invoke(actions);

            sw.Stop();
            TimeSpan timespan = sw.Elapsed;   
            timespan = sw.Elapsed;                
            Console.WriteLine("Request time for every '{0}' query: '{1}'", taskNum, timespan);

        }
        private static void NewBeat(int id, int taskNum)
        {   
            BeatVM vm = new BeatVM();
            Random random = new Random(); 
            vm.BeaterId = "Mr.Robot_"+taskNum+"_t"+id+"_"+(i++);
            var intVal = random.Next(0, 10);
            decimal rDec = (decimal)System.Math.Round(random.NextDouble(),2);            
            //vm.Price = LastBeat()+rDec;
            vm.Price = intVal+rDec;

            var json = JsonConvert.SerializeObject(vm, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync("https://localhost:5001/api/v1/beats", content);
            //var createResponse = await response.Content.ReadAsStringAsync();
            
        }


    }
}
