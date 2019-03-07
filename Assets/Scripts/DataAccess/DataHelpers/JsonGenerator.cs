using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;
using Newtonsoft.Json;
using UnityEngine;

namespace DataAccess.DataHelpers
{
    public class JsonGenerator
    {
        public static void GenerateAlphabetsJsonFromSource()
        {
            string sourceFile = "Dictionary/source";

            var text = Resources.Load<TextAsset>(sourceFile).text;
            var lines = text.Split('\n').Select(s => s.Trim()).ToList();
            var alphabets = new List<Alphabet>();

            //de 30
            var de = lines.Take(30);
            alphabets.Add(new Alphabet
            {
                Id = "Alphabet", 
                Type = Language.German, 
                Entries = de.Select(GetAlphabetEntryFromLine).ToList()
            });

            //tw 38
            var tw = lines.Skip(30).Take(38);
            alphabets.Add(new Alphabet
            {
                Id = "BoPoMoFo", 
                Type = Language.Chinese, 
                Entries = tw.Select(GetAlphabetEntryFromLine).ToList()
            });
            
            var json = JsonConvert.SerializeObject(alphabets, Formatting.Indented);
            File.WriteAllText("generated.json", json, System.Text.Encoding.UTF8);
        }

        private static AlphabetEntry GetAlphabetEntryFromLine(string line)
        {
            var entry = new AlphabetEntry
            {
                Id = line[0].ToString(), Character = line
            };

            entry.ContextFreeAudio = new AudioData {Path = "Audio/" + entry.Id + "_free"};
            entry.ContextSensitiveAudio = new AudioData {Path = "Audio/" + entry.Id + "_sensitive"};
            entry.ExampleWordAudio = new AudioData {Path = "Audio/" + entry.Id + "_example"};

            return entry;
        }

        public static void GenerateTranslationJsonFromSource()
        {
            var entries = 17;
            string sourceFile = "Dictionary/translation_source";

            var text = Resources.Load<TextAsset>(sourceFile).text;
            var lines = text.Split('\n').ToList();
            var dataList = new List<Translation>();

            for (int i = 0; i < entries; i++)
            {
                var v = new Translation();
                dataList.Add(v);
            }

            lines = lines.Select(line => line.Trim()).ToList();

            var keys = lines.Take(entries).ToList();
            var de = lines.Skip(entries).Take(entries).ToList();
            var tw = lines.Skip(2*entries).Take(entries).ToList();

            for (var i = 0; i < dataList.Count; i++)
            {
                var tr = dataList[i];
                tr.Key = keys[i];
                tr.German = de[i];
                tr.Chinese = tw[i];
            }

            var json = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText("generated.json", json, System.Text.Encoding.UTF8);
        }
        
        public static void GenerateVocabJsonFromSource()
        {
            var entries = 20;
            var categoryId = "locations";
            string sourceFile = "Dictionary/source";

            var text = Resources.Load<TextAsset>(sourceFile).text;
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
                voc.Translation[Language.Chinese] = twHan[i];
                voc.Bopomofo = twBopo[i];

                voc.Image = new ImageData();
                voc.Image.Path = "Images/" + voc.Id;

                voc.Audio = new Dictionary<Language, AudioData>();
                voc.Audio[Language.German] = new AudioData();
                voc.Audio[Language.German].Path = "Audio/" + voc.Id + "_de";
                voc.Audio[Language.Chinese] = new AudioData();
                voc.Audio[Language.Chinese].Path = "Audio/" + voc.Id + "_tw";
            }

            var json = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText("generated.json", json, System.Text.Encoding.UTF8);
        }

        public static void GenerateSayingJsonFromSource()
        {
            var entries = 6;
            string sourceFile = "Dictionary/sayings_source";

            var text = Resources.Load<TextAsset>(sourceFile).text;
            var lines = text.Split('\n').ToList();
            var dataList = new List<Saying>();

            for (int i = 0; i < entries*2; i++)
            {
                var s = new Saying();
                dataList.Add(s);
            }

            lines = lines.Select(line => line.Trim()).ToList();

            var ch1 = lines.Take(entries).ToList();
            var de1 = lines.Skip(entries).Take(entries).ToList();

            for (var i = 0; i < entries; i++)
            {
                var dat = dataList[i];
                dat.Id = "cn" + i;
                dat.Language = Language.Chinese;
                dat.Text = ch1[i];
                dat.Meaning = de1[i];
                dat.Audio = new AudioData();
                dat.Audio.Path = "Audio/Sayings/" + dat.Id;
            }

            var de2 = lines.Skip(2*entries).Take(entries).ToList();
            var ch2 = lines.Skip(3 * entries).Take(entries).ToList();
            

            for (var i = 0; i < entries; i++)
            {
                var dat = dataList[entries+i];
                dat.Id = "de" + i;
                dat.Language = Language.German;
                dat.Text = de2[i];
                dat.Meaning = ch2[i];
                dat.Audio = new AudioData();
                dat.Audio.Path = "Audio/Sayings/" + dat.Id;
            }

            var json = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText("generated.json", json, System.Text.Encoding.UTF8);
        }
    }
}