﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace OSD600.GoodLinkOrBadLink
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                
                CLIUsage.WelcomeManual();

                return;

            }else{
                // TODO: need to add case for wayback WayBack
                bool readArgAsFile = CLIUsage.Version(args[0]);
                bool wayback = CLIUsage.WayBack(args[0]);
                if(readArgAsFile){

                }else{
            

                
                    Console.WriteLine("Is this working??");
                    try{
                        string filePath;
                        if(wayback) {
                            Console.WriteLine(wayback);
                            Console.WriteLine(args[0]);
                            Console.WriteLine(args[1]);
                            filePath = args[1];
                        } else {

                            filePath = args[0];

                        }
                
                        string[] fileContent = File.ReadAllLines(filePath);


                        if(fileContent == null || fileContent.Length < 1){
                            
                            Console.WriteLine("\"{0}\" is empty, there is nothing to test", filePath);
                        
                        }else{

                
                                        Regex rx = new Regex(@"https?://[a-zA-Z0-9@:%._\+~#=]");

                                        
                                        string[] urls = File.ReadAllLines(filePath);

                                    
                            

                                        List<string> lines = new List<string>();
                                    


                                        foreach(String line in urls){

                                            
                                            

                                            if(rx.IsMatch(line)){
                        
                                                try{

                                                    if (wayback) {
                                                        // HttpResponseMessage response = await client.GetAsync("http://archive.org/wayback/available?url=" + line);
                                                        var jsonString = new WebClient().DownloadString("http://archive.org/wayback/available?url=" + line);
                                                        // Console.Write(json);
                                                        dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                                                        var archived = x.archived_snapshots;
                                                        dynamic available;
                                                        try {
                                                            var closest = archived.closest;
                                                            available = closest.available;
                                                        }catch(NullReferenceException){
                                                            available = false;
                                                        }
                                                        Console.WriteLine((bool)available);
  
                                                    } else {
                                                        HttpResponseMessage response = await client.GetAsync(line);
                                                        if((int)response.StatusCode == 200){

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.Write("[Good] ");
                                                            Console.ResetColor();
                                                            Console.WriteLine(line);

                                                        }else if((int)response.StatusCode == 400 || (int)response.StatusCode == 404){
                                                            
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.Write("[Bad] ");
                                                            Console.ResetColor();
                                                            Console.WriteLine(line);
                                                        }
                                                    }

                                                


                                                }catch(HttpRequestException){

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("[Unknown] ");
                                                    Console.ResetColor();
                                                    Console.WriteLine(line);

                                                    

                                                }

                                            }else{

                                                Console.WriteLine("not a URL");
                                            }

                                        }
                        } 

                    }catch(FileNotFoundException e){

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Warning: ");
                        Console.ResetColor();
                        Console.WriteLine(e.Message);
                        

                    }catch(Exception e){

                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Warning: ");
                        Console.ResetColor();
                        Console.WriteLine(e.Message);
                    
                        


                    }

                }

                
            }

      
        }
    }
}
