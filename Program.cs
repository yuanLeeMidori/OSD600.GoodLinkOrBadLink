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
                
                bool option = CLIUsage.isOption(args[0]);
                bool version = CLIUsage.Version(args[0]);
                bool wayback = CLIUsage.WayBack(args[0]);
                bool json = CLIUsage.JSON(args[0]);
                bool filter = CLIUsage.Filter(args[0]);
                bool globalPattern = CLIUsage.GlobalPattern(args[0]);
                bool ignoreURL = CLIUsage.Ignore(args[0]);

                if(!option){

                    Console.WriteLine("The input option \"" + args[0] + "\" is invalid. Try" +  
                                      "\n\n --v to get version," + 
                                      "\n --w to get Wayback," +
                                      "\n --j to get JSON format output" +
                                      "\n --good to return URLs with 200 status code," +
                                      "\n --bad to return URLs with 400 or 404 status code" +
                                      "\n --all to return all URLs" +
                                      "\n -i or --ignore or \\i to ignore links and paste them in another .txt file");
                    Environment.Exit(0);

                }

                if (version){

                    var versionString = Assembly.GetEntryAssembly()
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                        .InformationalVersion
                                        .ToString();

                    Console.WriteLine($"OSD600.GoodLinkOrBadLink v{versionString}");


                }else{
                          
                    try{
                        string[] ignoreUrls = args.Length > 2 ? File.ReadAllLines(args[1]) : null;  // to ignore the urls in this file
                        string filePath = args.Length == 1 ? args[0] : null;
                        string ignoreFilePath = "";
                        List<string> globalPat = new List<string>();

                            if (wayback) {

                                try {

                                    filePath = args[1];

                                } catch(Exception) {

                                    Console.WriteLine("Missing file input");
                                    System.Environment.Exit(1);

                                }

                            }

                            if(json){

                                try{

                                    filePath = args[1];

                                }catch(Exception){

                                    Console.WriteLine("Missing file input");
                                    System.Environment.Exit(1);
                                }

                            }

                            if (filter) {

                                try {

                                    filePath = args[1];

                                } catch(Exception) {

                                    Console.WriteLine("Missing file input");
                                    System.Environment.Exit(1);
                                    
                                }
                            }

                            if (globalPattern) {

                                try{

                                    string path = Directory.GetCurrentDirectory();

                                    foreach (var file in Directory.GetFiles(path, args[0])){

                                        Console.WriteLine("Reading \"{0}\"...", file.Split("/").Last());

                                        foreach (var i in File.ReadAllLines(file)){
                                    
                                            globalPat.Add(i);

                                        }

                                    }
                                }
                                catch (Exception){

                                    Console.WriteLine("Missing file(s)...");

                                }

                            }

                            if(ignoreURL && args.Length == 3) {

                                try
                                {
                                    for (int i = 0; i < ignoreUrls.Length; i++)
                                    {
                                        if (!ignoreUrls[i].StartsWith("http") && !ignoreUrls[i].StartsWith("#"))
                                        {
                                            Console.WriteLine($"{ignoreUrls[i]} is an invalid link. All links in the ignore file must starts with 'http' or 'https'.");
                                            System.Environment.Exit(1);
                                        }
                                    }

                                    // The last argument will be the file to check in question
                                    filePath = args.Last();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Missing file input");
                                    System.Environment.Exit(1);
                                }
                            
                            }else if((ignoreURL && args.Length > 3) || (ignoreURL && args.Length < 3)) { 

                                Console.WriteLine($"{args[0]} can only be passed with exactly two more arguments");
                                System.Environment.Exit(1);

                            }

                            string[] fileContent = (globalPattern) ? null : File.ReadAllLines(filePath);
                          
                            if (globalPat.Count < 1 && (fileContent == null || fileContent.Length < 1)){
                                
                                Console.WriteLine("\"{0}\" is empty, there is nothing to test", filePath);
                            
                            }else{
                                
                                Regex rx = new Regex(@"https?://[a-zA-Z0-9@:%._\+~#=]");
                                string[] urls = (globalPat.Count > 1) ? globalPat.ToArray() : File.ReadAllLines(filePath);
                                List<string> lines = new List<string>();
                                
                                foreach(String line in urls){       
                                   
                                    if(rx.IsMatch(line)){
                
                                        try{

                                            if (wayback) {

                                                var jsonString = new WebClient().DownloadString("http://archive.org/wayback/available?url=" + line);
                                                dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                                                var archived = x.archived_snapshots;
                                                dynamic available;

                                                try {

                                                    var closest = archived.closest;
                                                    available = closest.available;

                                                }catch(Exception){

                                                    available = false;

                                                }

                                                if ((bool)available) {

                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("[Available] ");
                                                    Console.ResetColor();
                                                    Console.WriteLine(line);

                                                } else {

                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.Write("[Not Available] ");
                                                    Console.ResetColor();
                                                    Console.WriteLine(line);

                                                }   

                                            }else if(json){

                                                    HttpResponseMessage response = await client.GetAsync(line);
                                                    Console.WriteLine("{ \"url\": '" + line + "' , \"status\": " + (int)response.StatusCode + " }");
                                            
                                            } /*if (ignoreURL){
                                                try
                                                {   
                                                
                                                    for(int i = 0; i < ignoreUrls.Length; i++) {
                                                        if (!ignoreUrls[i].StartsWith("http") && !ignoreUrls[i].StartsWith("#")) { 
                                                            Console.WriteLine($"{ignoreUrls[i]} is an invalid link. All links in the ignore file must starts with 'http' or 'https'.");
                                                            System.Environment.Exit(1);
                                                        }
                                                    }

                                                }
                                                catch (Exception)
                                                {

                                                    Console.WriteLine($"{ignoreUrls}");
                                                }

                                            }*/ else {
                                                // check if the url exists in the ignorelink list
                                                if (ignoreUrls != null && !ignoreUrls.Contains(line)) {
                                                    HttpResponseMessage response = await client.GetAsync(line);

                                                    if ((int)response.StatusCode == 200) {

                                                        if (args[0] == "--bad") {

                                                        } else {

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.Write("[Good] ");
                                                            Console.ResetColor();
                                                            Console.WriteLine(line);

                                                        }

                                                    } else if ((int)response.StatusCode == 400 || (int)response.StatusCode == 404) {

                                                        if (args[0] == "--good") {


                                                        } else {

                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.Write("[Bad] ");
                                                            Console.ResetColor();
                                                            Console.WriteLine(line);

                                                        }
                                                    }
                                                }
                                                else if(args.Length == 1) {
                                                    HttpResponseMessage response = await client.GetAsync(line);

                                                    if ((int)response.StatusCode == 200) {

                                                        if (args[0] == "--bad") {

                                                        } else {

                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.Write("[Good] ");
                                                            Console.ResetColor();
                                                            Console.WriteLine(line);

                                                        }

                                                    } else if ((int)response.StatusCode == 400 || (int)response.StatusCode == 404) {

                                                        if (args[0] == "--good") {


                                                        } else {

                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.Write("[Bad] ");
                                                            Console.ResetColor();
                                                            Console.WriteLine(line);

                                                        }
                                                    }
                                                }
                                                
                                            }
                                   
                                        }catch(HttpRequestException){

                                            if(json){

                                                Console.WriteLine("{ \"url\": '" + line + "': \"status\": 'unknown' }");

                                            }else{

                                                if (args[0] == "--good" || args[0] == "--bad"){

                                                } else {

                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                    Console.Write("[Unknown] ");
                                                    Console.ResetColor();
                                                    Console.WriteLine(line);   
                                                }       

                                            }
                                                                               
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
