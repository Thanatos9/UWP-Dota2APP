using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2App.Models {

    //Max+
    public class Imgs {
        public string mjia_all { get; set; }
        public string topic_all { get; set; }
    }

    public class TagInfo {
    }

    public class Result {
        public int click { get; set; }
        public int content_type { get; set; }
        public string create_at { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string detail_json { get; set; }
        public bool favour { get; set; }
        public int img_type { get; set; }
        public IList<string> imgs { get; set; }
        public string myImg { get; set; }
        public int is_large_img { get; set; }
        public int is_partition_top { get; set; }
        public int is_rotate { get; set; }
        public bool is_supported { get; set; }
        public int linkid { get; set; }
        public string newUrl { get; set; }
        public IList<int> news_topic_type { get; set; }
        public string newsid { get; set; }
        public string os_type { get; set; }
        public string share_url { get; set; }
        public string source { get; set; }
        public string tag { get; set; }
        public TagInfo tag_info { get; set; }
        public double timestamp { get; set; }
        public string title { get; set; }
        public bool top { get; set; }
        public int topic_id { get; set; }
        public int up { get; set; }
        public string url { get; set; }
    }

    public class MaxjiaNewsWrapper {
        public Imgs imgs { get; set; }
        public string msg { get; set; }
        public int reply_timestamp { get; set; }
        public IList<Result> result { get; set; }
        public string status { get; set; }
    }

    //buff 
    public class Hero {
        public string category { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class Rarity {
        public string category { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class Slot {
        public string category { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class Type {
        public string category { get; set; }
        public string internal_name { get; set; }
        public string localized_name { get; set; }
    }

    public class Tags {
        public Hero hero { get; set; }
        public Rarity rarity { get; set; }
        public Slot slot { get; set; }
        public Type type { get; set; }
    }

    public class Info {
        public Tags tags { get; set; }
    }

    public class GoodsInfo {
        public string icon_url { get; set; }
        public Info info { get; set; }
        public int? item_id { get; set; }
        public string original_icon_url { get; set; }
        public string steam_price { get; set; }
        public string steam_price_cny { get; set; }
    }

    public class Item {
        public int appid { get; set; }
        public bool bookmarked { get; set; }
        public string buy_max_price { get; set; }
        public int buy_num { get; set; }
        public string game { get; set; }
        public GoodsInfo goods_info { get; set; }
        public bool has_buff_price_history { get; set; }
        public int id { get; set; }
        public string market_hash_name { get; set; }
        public string name { get; set; }
        public string quick_price { get; set; }
        public string sell_min_price { get; set; }
        public int sell_num { get; set; }
        public string sell_reference_price { get; set; }
        public string steam_market_url { get; set; }
        public int transacted_num { get; set; }
    }

    public class Data {
        public IList<Item> items { get; set; }
        public int page_num { get; set; }
        public int page_size { get; set; }
        public int total_count { get; set; }
        public int total_page { get; set; }
    }

    public class BuffDataWrapper {
        public string code { get; set; }
        public Data data { get; set; }
        public object msg { get; set; }
    }

}
