using System;
using System.Collections.Generic;
using System.Text;
using mshtml;
using System.Web; // for server
using System.Net; // for client
using System.IO;
//using System.Collections.Generic;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Collections;

namespace downloadSongtasteMusic
{
    class songtaste
    {
        public struct albumInfo
        {
            public string url;
            public string name;
            public string author;
        };

        //public struct songInfo
        public class songInfo
        {
            public string id;       // 2224853
            public string url;      // http://www.songtaste.com/song/2224853/
            public string realAddr; // http://m6.songtaste.com/201204131040/90ee3460a764e82816d5233fe2acaccc/6/62/625c4102d5a2f89f614d874b2c2ca402.mp3
            public string artist;   // DJ OKAWARI
            public string title;    // Flower Dance
            public string suffix;   // .mp3
            public string storedName; //Flower Dance - DJ OKAWARI.mp3

            //public string recommender;// loveqian1314
            //public string recommenderId;// 3334687
            //public string recommenderUrl;// http://songtaste.com/user/3334687/
            
            public songInfo()
            {
                id = "";
                url = "";
                realAddr = "";
                artist = "";
                title = "";
                suffix = "";
                storedName = "";
            }
        };

        const string stHtmlCharset = "GB18030";
        crifanLib crl = null;

        public songtaste()
        {
            crl = new crifanLib();

            AppDomain.CurrentDomain.AssemblyResolve +=new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

            byte[] bytes = (byte[])rm.GetObject(dllName);

            return System.Reflection.Assembly.Load(bytes);
        }

        /* get the IE sub tab/page of current playing songtaste music, whose title is "songtaste——播放器" */
        public HTMLDocument getMultiPlayingPage()
        {
            HTMLDocument stPlayingPage = null;

            /* 获得所有ie进程。因为windows下资源窗口使用ie内核，所以不光是我们通常指的web浏览器，它还包括你打开'我的电脑'这样的窗口 */
            SHDocVw.ShellWindows sws = new SHDocVw.ShellWindows();
            
            /*遍历ie进程*/
            foreach (SHDocVw.InternetExplorer iw in sws)
            {
                string iePlayStMusicTitle = "songtaste——播放器";
                //string playingStMusic360se = "songtaste——播放器";
                //string iePlayStMusicTitle = "Legend－气势磅礴的电影配乐 Two steps from hell 试听 -- SongTaste 用音乐倾听彼此";
                if (iw.LocationName == iePlayStMusicTitle)
                {
                    //string testStr = "";
                    //testStr = iw.Path;
                    //testStr = iw.Type;
                    //Object objTest = iw.Application;
                    //bool isAddrBar = iw.AddressBar;
                    //Object app = iw.Application;

                    // 找到标题为"songtaste——播放器"的IE子页面
                    stPlayingPage = (HTMLDocument)iw.Document;
                    break;
                }
            }

            return stPlayingPage;
        }

        public bool getCurPlayingSongId(out string curSongId)
        {
            bool getCurPlayingOk = false;

            curSongId = "";

            HTMLDocument stPlayingPage = getMultiPlayingPage();
            
            if (stPlayingPage != null)
            {
                //Note:
                //following line of code, previously can work, but can not work in another Win7+IE9/360Se environment !
                //so use follow stPlayingPage.getElementsByTagName("div"); instead

                //IHTMLElement songIdElement = stPlayingPage.getElementById("songid");
                ////IHTMLElement songIdElement = stPlayingPage.getElementById("SongID");
                //curSongId = ((HTMLInputTextElement)songIdElement).value;
                //if ((curSongId != null) && (curSongId != ""))
                //{
                //    getCurPlayingOk = true;
                //}

                //IHTMLElement divId = stPlayingPage.getElementById("div");
                //IHTMLElementCollection divName = stPlayingPage.getElementsByName("div");
                IHTMLElementCollection divTagName = stPlayingPage.getElementsByTagName("div");
                foreach (IHTMLElement div in divTagName)
                {
                    //if (div.id == "left_music_div")
                    if (div.className == "songName")
                    {
                        //Object classStr = div.getAttribute("className");
                        string className = div.className;
                        string tagName = div.tagName;
                        //Object objName = div.getAttribute("name");
                        //Object objContent = div.getAttribute("content");

                        //string html = div.outerHTML;
                        string html = div.innerHTML;
                        //<div class="songName">
                        //    <p class="p_tit">歌曲试听：<b><span id="songInfo"><input id="url_2935406" name="+SongName+" value="http://m5.songtaste.com/201204222219/165c63e0bab9d17989f103994215b63c/5/53/53d1bec93f06a5b6df572627454923a7.mp3" type="hidden"><input id="midurl_2935406" value="03513031b0c55b0d9afd6d044dcfcb22d1c0801fddbea0b0fac2a8af690efd1dbfaccb168747497c2f1ced3fe51ffc51" type="hidden"><a class="underline" href="/song/2935406/" target="_blank">准备用这歌做铃声^做铃声^哈哈哈^祭夜醉美推荐   祭夜醉美 </a></span></b></p>
                        //</div>

                        //<P class=p_tit>歌曲试听：<B><SPAN id=songInfo><INPUT id=url_679637 name=+SongName+ value=http://m0.songtaste.com/201204231235/bac2ef6dc0c07661bb22c38059661648/0/04/047975dc07ece3645860aa736b5bd779.mp3 type=hidden><INPUT id=midurl_679637 value=4ff1803d387e63205322d3c576af2f08d540f57465c3bb5c72c9cc8211b7cae878eac5de4eca588a2f1ced3fe51ffc51 type=hidden><A class=underline href="http://www.songtaste.com/song/679637/" target=_blank>一首经典的歌清晨咖啡的味道 忍不住跟着哼唱 gotta have you </A></SPAN></B></P>

                        //string songNameP = @"<div class=""songName"">\s+?<p class=""p_tit"">歌曲试听：<b><span id=""songInfo""><input id=""url_(?<songid>\d+)""";
                        //string songNameP = @"<p class=""p_tit"">歌曲试听：<b><span id=""songInfo""><input id=""url_(?<songid>\d+)""";
                        string songNameP = @"p_tit.+?歌曲试听：.+?songInfo.+?url_(?<songid>\d+)";
                        Regex songNameRx = new Regex(songNameP, RegexOptions.IgnoreCase);
                        Match foundCurSong = songNameRx.Match(html);
                        if (foundCurSong.Success)
                        {
                            curSongId = foundCurSong.Groups["songid"].Value;
                            getCurPlayingOk = true;
                            break;
                        }                       
                    }
                }
            }

            return getCurPlayingOk;
        }

        public bool getCurSongInfo(out songInfo curSongInfo)
        {
            bool getInfoOk = false;

            curSongInfo = new songInfo();

            if (getCurPlayingSongId(out curSongInfo.id))
            {
                string errStr = "";
                if (getSongInfo(curSongInfo.id, out curSongInfo, out errStr))
                {
                    getInfoOk = true;
                }
            }

            return getInfoOk;
        }
        

        public string extractIdFromUrl(string songUrl)
        {
            string songId = "";

            //http://songtaste.com/song/3015123
            //http://songtaste.com/song/3015123/
            //http://www.songtaste.com/song/955407
            //http://www.songtaste.com/song/955407/
            string songidP = @"http://(www\.)?songtaste\.com/song/(?<songId>\d+)/?";
            Regex songidRx = new Regex(songidP);
            Match foundSongid = songidRx.Match(songUrl);
            if (foundSongid.Success)
            {
                songId = foundSongid.Groups["songId"].Value;
            }

            return songId;
        }

        public string genSongUrlFromId(string songId)
        {
            //return "http://songtaste.com/song/" + songId + "/";
            return "http://www.songtaste.com/song/" + songId + "/";
        }
        
        //955407
        //http://www.songtaste.com/song/955407
        //http://www.songtaste.com/song/955407/
        public bool isValidIdOrUrl(string idOrUrl, out string songId, out string songUrl)
        {
            bool isValid = false;
            songId = "";
            songUrl = "";

            bool isId = false;
            bool isUrl = false;

            string idP = @"^(?<songId>\d+)$";
            Match matchId = (new Regex(idP)).Match(idOrUrl);
            if (matchId.Success)
            {
                songId = matchId.Groups["songId"].Value;
                songUrl = genSongUrlFromId(songId);
                isId = true;
            }
            else
            {
                //http://www.songtaste.com/song/955407
                //http://www.songtaste.com/song/955407/
                //http://songtaste.com/song/955407
                //http://songtaste.com/song/955407/
                string urlP = @"^(?<songUrl>http://(www\.)?songtaste\.com/song/(?<songId>\d+))/?$";
                Match matchUrl = (new Regex(urlP)).Match(idOrUrl);
                if (matchUrl.Success)
                {
                    songId = matchUrl.Groups["songId"].Value;
                    // must be like this: http://www.songtaste.com/song/955407/
                    songUrl = matchUrl.Groups["songUrl"].Value + "/";
                    isUrl = true;
                }
            }

            if (isId || isUrl)
            {
                isValid = true;
            }

            return isValid;
        }

        // idOrUrl : 955407 or http://www.songtaste.com/song/955407 or http://www.songtaste.com/song/955407/
        // songInfo: the ST song info: title, artist, realAddr, ...
        // errStr: error reason string
        public bool getSongInfo(string idOrUrl, out songInfo songInfo, out string errStr)
        {
            bool getInfoOk = false;
            errStr = "未知错误！";
            songInfo = new songInfo();

            string songId = "";
            string songUrl = "";
            if (!isValidIdOrUrl(idOrUrl, out songId, out songUrl))
            {
                errStr = "无法识别的Songtaste的Id或Url：" + idOrUrl + " ！";
                return getInfoOk;
            }
            else
            {
                songInfo.id = songId;
                songInfo.url = songUrl;
            }

            // here must clear previous cookies
            // otherwise access html with previous cookies will get fault html:
            //信息提示: 　 对不起，该用户不存在！ 3 秒钟以后系统将自动跳转！ 
            crl.clearCurCookies();

            string respHtml = "";
            respHtml = crl.getUrlRespHtml(songInfo.url, stHtmlCharset);
            if (respHtml != "")
            {
                //note: some song is illegal:
                //http://songtaste.com/song/3029002/
                //return invalid html content
                //following can not found valid info

                // 1. get song title and artist
                //<p class="mid_tit">╰.很多人都在找的一首伤感韩文丶最近很火﹀淑熙（啦啦啦）丶</p><p></p>
                string titleP = @"<p\s+?class=""mid_tit"">(?<title>.+?)</p>";
                Match foundTitle = (new Regex(titleP)).Match(respHtml);
                if (foundTitle.Success)
                {
                    songInfo.title = foundTitle.Groups["title"].Value;
                    songInfo.title = crl.removeInvChrInPath(songInfo.title);
                    songInfo.title = songInfo.title.Trim();

                    //<h1 class="h1singer">1956.烟蒂</h1>
                    //<h1 class="h1singer">Rie fu</h1>
                    //<h1 class="h1singer"></h1>
                    string singerP = @"<h1\s+?class=""h1singer"">(?<singer>.*?)</h1>";
                    Match foundSinger = (new Regex(singerP)).Match(respHtml);
                    if (foundSinger.Success)
                    {
                        songInfo.artist = foundSinger.Groups["singer"].Value;
                        //special: http://www.songtaste.com/song/809103/, no singer
                        if (songInfo.artist == "")
                        {
                            songInfo.artist = "Unknown Singer";
                        }
                        songInfo.artist = crl.removeInvChrInPath(songInfo.artist);
                        songInfo.artist = songInfo.artist.Trim();

                        // 2. get song real address
                        //<a href="javascript:playmedia1('playicon','player', '5bf271ccad05f95186be764f725e9aaf07e0c7791a89123a9addb2a239179e64c91834c698a9c5d82f1ced3fe51ffc51', '355', '68', 'b3a7a4e64bcd8aabe4cabe0e55b57af5', 'http://m3.', '3015123',0);ListenLog(3015123, 0);">
                        //http://www.songtaste.com/song/2428041/ contain:
                        //<a href="javascript:playmedia1('playicon','player', 'cachefile33.rayfile.com/12f1/zh-cn/download/d1e8d86a0a9880f697aee789f27383db/preview', '355', '68', 'b3a7a4e64bcd8aabe4cabe0e55b57af5', 'http://224.', '2428041',0);ListenLog(2428041, 0);">
                        //string songP = @"javascript:playmedia1\('playicon','player', '(?<str>\w+)', '\d+', '\d+', '\w+', '.+?', '(?<sid>\d+)',\d+\);";
                        string songP = @"javascript:playmedia1\('playicon','player', '(?<str>[^']+)', '\d+', '\d+', '(?<keyStr>\w+)', '(?<urlPref>.+?)', '(?<sid>\d+)',\d+\);";
                        Regex songRx = new Regex(songP);
                        Match foundSong = songRx.Match(respHtml);
                        if (foundSong.Success)
                        {
                            string str      = foundSong.Groups["str"].Value;
                            string urlPref  = foundSong.Groups["urlPref"].Value;
                            string keyStr   = foundSong.Groups["keyStr"].Value;
                            string sid      = foundSong.Groups["sid"].Value;

                            if (str.Contains("/"))
                            {
                                //cachefile33.rayfile.com/12f1/zh-cn/download/d1e8d86a0a9880f697aee789f27383db/preview
                                //to get the suffix
                                string suffix = "";
                                string mainJsUrl = "http://image.songtaste.com/inc/main.js";
                                string respHtmlMainJs = crl.getUrlRespHtml(mainJsUrl);
                                //		case "b3a7a4e64bcd8aabe4cabe0e55b57af5":
			                    //          return ".mp3";
                                string suffixP = @"""" + keyStr + @""":.+?return\s+""(?<suffix>\.\w+)"";";
                                Regex suffixRx = new Regex(suffixP, RegexOptions.Singleline);
                                Match foundSuffix = suffixRx.Match(respHtmlMainJs);
                                if (foundSuffix.Success)
                                {
                                    suffix = foundSuffix.Groups["suffix"].Value;
                                    songInfo.realAddr = urlPref + str + suffix;
                                }
                            }
                            else 
                            {
                                //5bf271ccad05f95186be764f725e9aaf07e0c7791a89123a9addb2a239179e64c91834c698a9c5d82f1ced3fe51ffc51

                                Dictionary<string, string> headerDict = new Dictionary<string, string>();
                                headerDict.Add("x-requested-with", "XMLHttpRequest");
                                // when click play
                                // access http://songtaste.com/time.php, post data:
                                //str=5bf271ccad05f95186be764f725e9aaf07e0c7791a89123a9addb2a239179e64c91834c698a9c5d82f1ced3fe51ffc51&sid=3015123&t=0
                                Dictionary<string, string> postDict = new Dictionary<string, string>();
                                postDict.Add("str", str);
                                postDict.Add("sid", sid);
                                postDict.Add("t", "0");
                                string getRealAddrUrl = "http://songtaste.com/time.php";
                                songInfo.realAddr = crl.getUrlRespHtml(getRealAddrUrl, headerDict, stHtmlCharset, postDict);    
                            }

                            if (songInfo.realAddr != "")
                            {
                                int lastPoint = songInfo.realAddr.LastIndexOf('.');
                                int strLen = songInfo.realAddr.Length;
                                songInfo.suffix = songInfo.realAddr.Substring(lastPoint);

                                songInfo.storedName = songInfo.title + " - " + songInfo.artist + songInfo.suffix;

                                getInfoOk = true;
                            }
                            else
                            {
                                errStr = "找不到歌曲的真实下载地址！";
                            }
                        }
                        else
                        {
                            errStr = "找不到歌曲的真实下载地址！";
                        }
                    }
                    else
                    {
                        errStr = "找不到歌曲的歌手信息！";
                    }
                }
                else
                {
                    errStr = "找不到歌曲的标题信息！";
                }
            }
            else
            {
                errStr = "无法获取网页信息！";
            }

            return getInfoOk;
        }

        public int getDownloadPercent()
        {
            return crl.getCurDownloadPercent();
        }

        public bool downloadStMusicFile(string musicRealAddr, string fullnameToStore, out string errStr)
        {
            bool downloadOk = false;
            errStr = "未知错误！";

            if (musicRealAddr == null || 
                musicRealAddr == "" ||
                fullnameToStore == null ||
                fullnameToStore == "")
            {
                errStr = "Songtaste歌曲真实的地址无效！";
                return downloadOk;
            }
            
            Dictionary<string, string> headerDict = new Dictionary<string, string>();
            //headerDict.Add("Referer", "http://songtaste.com/music/");
            headerDict.Add("Referer", "http://songtaste.com/");

            //const int maxMusicFileLen = 100 * 1024 * 1024; // 100M
            const int maxMusicFileLen = 300 * 1024 * 1024; // 300M
            Byte[] binDataBuf = new Byte[maxMusicFileLen];
            
            int respDataLen = crl.getUrlRespStreamBytes(ref binDataBuf, musicRealAddr, headerDict, null, 0);
            if (respDataLen < 0)
            {
                errStr = "无法读取歌曲数据！";
                return downloadOk;
            }

            if (crl.saveBytesToFile(fullnameToStore, ref binDataBuf, respDataLen, out errStr))
            {
                downloadOk = true;
            }

            return downloadOk;        
        }


        public List<string> extractSongIdList(string albumUrl)
        {
            string respHtml = "";
            string songId;
            //ArrayList songIdList = new ArrayList();
            List<string> songIdList = new List<string>();

            //parse html to get all song id
            respHtml = crl.getUrlRespHtml(albumUrl, stHtmlCharset);

            //http://www.songtaste.com/album/570665 has 6 songs
            //<script>WS("1","3043511","｛我不是标题党｝来自心灵的哼唱 不来听就后悔吧 ","文文收藏 ");WS("2","3036290","~天空之城 哼唱版 ","文文收藏 ");WS("3","3036284","知道不知道（天下无贼 结尾电影曲） 吟唱的好好听 ","文文收藏 ");WS("4","3036279","我是多么羡慕你（无词 哼唱） ","文文收藏 ");WS("5","3036277","徜徉在哼唱的世界里 ~是多么的幸福~ ","文文收藏 ");WS("6","2928974","听了它感情好复杂·纯音乐中的极品 ","文文收藏 ");</script>

            string wsP = @"WS\(""(?<num>\d+)"",""(?<songId>\d+)"","".+?"","".+?""\);";
            Regex wsRx = new Regex(wsP);
            MatchCollection foundWs = wsRx.Matches(respHtml);
            if (foundWs.Count > 0)
            {
                foreach (Match eachWs in foundWs)
                {
                    songId = eachWs.Groups["songId"].Value;
                    songIdList.Add(songId);
                }
            }

            return songIdList;
        }

        public albumInfo extractAlbumInfo(string albumUrl)
        {
            string respHtml = "";
            albumInfo albumInfo = new albumInfo();
            albumInfo.url = albumUrl;

            respHtml = crl.getUrlRespHtml(albumUrl, stHtmlCharset);

            //http://www.songtaste.com/album/570665
            //<h1 class="h1user">嘟藥婞麸</h1>
            //<p class="mid_tit">文文收藏 聆听纯音<p>

            //http://www.songtaste.com/album/481886
            //<h1 class="h1user">//+Tu.Ren＂娜蒂亚＂</h1>
            //<p class="mid_tit">娜蒂亚回归ST赞歌<p>

            string mid_tit;
            if (crl.extractSingleStr(@"<p\s+?class=""mid_tit"">(?<mid_tit>.+?)<p>", respHtml, out mid_tit))
            {
                albumInfo.name = crl.removeInvChrInPath(mid_tit);
            }

            string h1user;
            if (crl.extractSingleStr(@"<h1\s+?class=""h1user"">(?<h1user>.+?)</h1>", respHtml, out h1user))
            {
                albumInfo.author = crl.removeInvChrInPath(h1user);
            }

            return albumInfo;
        }
        
    }
}
