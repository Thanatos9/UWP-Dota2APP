using Dota2App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dota2App.ViewModels {
    public class JsonManage {

        private static async Task<MaxjiaNewsWrapper> GetMaxjiaNewsAsync() {

            string url = string.Format("http://news.maxjia.com/maxnews/app/list/?&actual_game_type=dota2&offset=0&limit=20");

            HttpClient http = new HttpClient();

            var response = await http.GetAsync(url);
            var jsonMessage = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(MaxjiaNewsWrapper));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonMessage));

            var result = (MaxjiaNewsWrapper)serializer.ReadObject(ms);

            return result; 

        }

        public static async Task MaxjiaDataManageAsync(ObservableCollection<Result> newsData) {
            var Data = await GetMaxjiaNewsAsync();
            var news = Data.result;
            foreach (var n in news) {
                UnicodeToString(n.title);
                n.myImg = n.imgs[0].ToString();
                newsData.Add(n);
            }


        }

        private static async Task<BuffDataWrapper> GetBuffDataAsync(int pageNum) {

            string goods_id = "756655";
            string page_num = "";
            string page_size = "";

            //https://buff.163.com/api/market/goods?game=dota2&page_num=2&hero=npc_dota_hero_dragon_knight
            //string url = string.Format("https://buff.163.com/api/market/goods/sell_order?game=dota2&goods_id={0}&page_num=1&page_size=5", goods_id);
            string url = string.Format("https://buff.163.com/api/market/goods?game=dota2&page_num={0}&page_size=60", pageNum);

            HttpClient http = new HttpClient();

            var response = await http.GetAsync(url);
            var jsonMessage = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(BuffDataWrapper));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonMessage));

            var result = (BuffDataWrapper)serializer.ReadObject(ms);

            return result;
        }

        public static async Task BuffDataManageAsync(ObservableCollection<Item> dotaItems, int pageNum) {
            var buffData = await GetBuffDataAsync(pageNum);
            var buffItem = buffData.data.items;
            foreach(var bI in buffItem) {
                UnicodeToString(bI.name);
                dotaItems.Add(bI);
            }


        }

        public static string UnicodeToString(string source) {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase).Replace(
              source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
    }
}
