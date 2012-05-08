using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using InflectorNet = Inflector.Net.Inflector;
using Couchbase;
using Enyim.Caching.Memcached;

namespace TapMapDataLoader
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var client = new CouchbaseClient();
                foreach (var file in Directory.GetFiles(Environment.CurrentDirectory, "*.txt"))
                {
                    var type = InflectorNet.Singularize(new FileInfo(file).Name.Replace(".txt", "").ToLower());
                    using (var sr = new StreamReader(file))
                    {
                        var keys = sr.ReadLine().Split('|');
                        var dict = new Dictionary<string, object>() { { "type", type } };
                        
                        string line = null;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var values = line.Split('|');
                            for (var i = 0; i < values.Length; i++)
                            {
                                var keyData = keys[i].Split(':');
                                object value = null;
                                switch(keyData[0])
                                {
                                    case "i":
                                        value = int.Parse(values[i]);
                                        break;
                                    case "d":
                                        value = double.Parse(values[i]);
                                        break;
                                    default:
                                        value = values[i];
                                        break;
                                }

                                dict[keyData[1]] = value;
                                var json = JsonConvert.SerializeObject(dict);
                                Console.WriteLine(json);
                                var key = string.Concat(type, "_", dict["name"].ToString().ToLower().Replace(" ", "_"));
                                client.Store(StoreMode.Set, key, json);

                            }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
