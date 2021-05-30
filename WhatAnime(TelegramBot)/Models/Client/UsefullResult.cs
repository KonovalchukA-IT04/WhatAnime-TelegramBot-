using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatAnime_TelegramBot_.Models
{
    public class ShortData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }
    public class UsefullResult
    {
        public List<ShortData> dataList { get; set; }
        public UsefullResult()
        {
            dataList = new List<ShortData>();
        }
    }
    public class UsefulAnimeData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string title_en { get; set; }
        public string url { get; set; }
        public string synopsis { get; set; }
        public int? episodes { get; set; }
        public double? score { get; set; }
        public string premiered { get; set; }
        public string genres { get; set; }
        public string img_url { get; set; }
    }
    public class ImgData
    {
        public int id { get; set; }
        public string title { get; set; }
        public string title_en { get; set; }
    }
    public class UsefullImgData
    {
        public List<ImgData> imgDataList { get; set; } 
        public UsefullImgData()
        {
            imgDataList = new List<ImgData>();
        }
    }
    public class Quotes
    {
        public string anime { get; set; }
        public string character { get; set; }
        public string quote { get; set; }
    }
    public class UsefullNewsData
    {
        public string title { get; set; }
        public string body { get; set; }
        public string url_ById { get; set; }
    }
    public class News
    {
        public List<UsefullNewsData> newsList { get; set; }
        public News()
        {
            newsList = new List<UsefullNewsData>();
        }
    }
}
