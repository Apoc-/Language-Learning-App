using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;
using Newtonsoft.Json;
using UnityEngine;
using Vuforia;

namespace DataAccess.DataHelpers
{
    public class JsonGenerator
    {
        public static void GenerateVocabJsonFromSource()
        {
            var entries = 20;
            var categoryId = "locations";
            string sourceFile = "Dictionary/source";
            
            
            var asset = Resources.Load<TextAsset>(sourceFile);
            var text = asset.text;
            var lines = text.Split('\n').ToList();
            var dataList = new List<Vocabulary>();
            
            for (int i = 0; i < entries; i++)
            {
                var v = new Vocabulary();
                v.Category = DAOFactory.CategoryDAO.LoadCategories().Find(c => c.Id == categoryId);
                
                dataList.Add(v);
            }

            lines = lines.Select(line => line.Trim()).ToList();
            
            var ids = lines.Take(entries).ToList();
            var de = lines.Skip(entries).Take(entries).ToList();
            var tw = lines.Skip(2 * entries).Take(2 * entries).ToList();

            var twHan = tw.Where((s, i) => i % 2 == 0).ToList();
            var twBopo = tw.Where((s, i) => i % 2 != 0).ToList();
            
            for (var i = 0; i < dataList.Count; i++)
            {
                var voc = dataList[i];
                voc.Id = ids[i];
                
                voc.Translation = new Dictionary<Language, string>();
                voc.Translation[Language.German] = de[i];
                voc.Translation[Language.Taiwanese] = twHan[i];
                voc.Bopomofo = twBopo[i];
                
                voc.Image = new ImageData();
                voc.Image.Path = "Images/" + voc.Id;
                
                voc.Audio = new Dictionary<Language, AudioData>();
                voc.Audio[Language.German] = new AudioData();
                voc.Audio[Language.German].Path = "Audio/" + voc.Id + "_de";
                voc.Audio[Language.Taiwanese] = new AudioData();
                voc.Audio[Language.Taiwanese].Path = "Audio/" + voc.Id + "_tw";
            }

            var json = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText("generated.json", json, System.Text.Encoding.UTF8);
        }
    }
}