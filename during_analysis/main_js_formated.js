"var UpPath = "http://210.51.2.101/uploadgbk/";

var liveSwitching = true;
 
function $(){
var Var1=new Array();
for(var i=0;i<arguments.length;i++){
var Var2=arguments[i];
if(typeof Var2=="string"){
Var2=document.getElementById(Var2);
}
if(arguments.length==1){
return Var2;
}
Var1.push(Var2);
}
return Var1;
}


var WinLoad={loadfuncs:new Array(),addFunc:function(ref){
 
}

};


function switchSearch(smode) {
    if (!liveSwitching) {
        return true;
        }
    else {
        $("smode").value = smode;
        var stabs = $("taglist").getElementsByTagName("li");
        for (var i=0; i < stabs.length; i++) stabs[i].className = "";
        $("sm_"+smode).className = "selected";
        $("sb").focus();
        return false;
    } 
}



//Media Link
function playmedia(playIcon, strID,strURL,intWidth,intHeight) {

	playIcon.replace(" ","%20");
	strID.replace(" ","%20");
	
	var objDiv=document.getElementById(strID);
	document.getElementById(playIcon).style.display='none';
	
	if (!objDiv) return false;
	if (objDiv.style.display!='none') {
		objDiv.innerHTML='';
		objDiv.style.display='none';
	} else {
		objDiv.innerHTML=makemedia(strURL,intWidth,intHeight);
		objDiv.style.display='block';
	}
}

//Media Build
function makemedia (strURL,intWidth,intHeight) {
	var strHtml;
	
	strHtml ="<object id='MediaPlayer1' width='"+ intWidth +"' height='"+ intHeight +"' classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,5,715' align='baseline' border='0' standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>";
	strHtml+="<param name='invokeURLs' value='0'>";
    	strHtml+="<param name='FileName' value=\\""+ strURL +"\\">";
    	strHtml+="<param name='ShowControls' value='1'>";
    	strHtml+="<param name='ShowPositionControls' value='0'>";
    	strHtml+="<param name='ShowAudioControls' value='1'>";
    	strHtml+="<param name='ShowTracker' value='1'>";
    	strHtml+="<param name='ShowDisplay' value='0'>";
    	strHtml+="<param name='ShowStatusBar' value='1'>";
    	strHtml+="<param name='AutoSize' value='0'>";
    	strHtml+="<param name='ShowGotoBar' value='0'>";
    	strHtml+="<param name='ShowCaptioning' value='0'>";
    	strHtml+="<param name='AutoStart' value='1'>";
    	strHtml+="<param name='PlayCount' value='0'>";
    	strHtml+="<param name='AnimationAtStart' value='0'>";
    	strHtml+="<param name='TransparentAtStart' value='0'>";
    	strHtml+="<param name='AllowScan' value='0'>";
    	strHtml+="<param name='EnableContextMenu' value='1'>";
    	strHtml+="<param name='ClickToPlay' value='0'>";
    	strHtml+="<param name='DefaultFrame' value='datawindow'>";
	
	
	strHtml+="<embed src=\\""+ strURL +"\\" align='baseline' border='0' width='"+ intWidth +"' height='"+ intHeight +"' type='application/x-mplayer2'";
        strHtml+=" pluginspage='http://www.microsoft.com/isapi/redir.dll?prd=windows&amp;sbp=mediaplayer&amp;ar=media&amp;sba=plugin&amp;'";
        strHtml+="name='MediaPlayer' showcontrols='1' showpositioncontrols='0' showaudiocontrols='1' showtracker='1' showdisplay='0' showstatusbar='1' autosize='0' showgotobar='0' showcaptioning='0' autostart='1' autorewind='0'";
        strHtml+="animationatstart='0' transparentatstart='0' allowscan='1' enablecontextmenu='1' clicktoplay='0' defaultframe='datawindow' invokeurls='0'> </embed></object>";
        
     
	return strHtml;
}




//?????д???

function GetSongType(md5code)
{
	switch(md5code)
	{
		case "7d99bb4c7bd4602c342e2bb826ee8777":
			return ".wma";
			break;
		case "25e4f07f5123910814d9b8f3958385ba":
			return ".Wma";
			break;
		case "51bbd020689d1ce1c845a484995c0cce":
			return ".WMA";
			break;
		case "b3a7a4e64bcd8aabe4cabe0e55b57af5":
			return ".mp3";
			break;
		case "d82029f73bcaf052be8930f6f4247184":
			return ".MP3";
			break;
		case "5fd91d90d9618feca4740ac1f2e7948f":
			return ".Mp3";
			break;
	}	
}

//Media Link
function playmedia1(playIcon, strID,strURL,intWidth,intHeight,type, Head,st_songid,t) {
 
	playIcon.replace(" ","%20");
	strID.replace(" ","%20");
	
	var objDiv=document.getElementById(strID);
	document.getElementById(playIcon).style.display='none';
	
	if (!objDiv) return false;
	if (objDiv.style.display!='none') {
		objDiv.innerHTML='';
		objDiv.style.display='none';
	} else {
		if(strURL.indexOf('rayfile')>0) {
			var SongUrl = Head + strURL + GetSongType(type);
			objDiv.innerHTML=makemedia_html(SongUrl,intWidth,intHeight);
			objDiv.style.display='block';
		} else {
			$.ajax({
				type:'POST',
				url:'/time.php',
				cache:false,
				data:'str='+strURL+'&sid='+st_songid+'&t='+t,
				dataType:'html',
				success:function(data){
					//alert(data);
					if(data){
						objDiv.innerHTML=makemedia_html(data,intWidth,intHeight);
						objDiv.style.display='block';
						if(data.indexOf('duomi.com') > 0){
							$("#show_logo").show();	
						}
					}
				},
				error:function(data){
					//alert('error');
				}
				});
		}
		
	}
}

//Media Build
function makemedia_html (SongUrl,intWidth,intHeight) {
	var strHtml ="<object id='MediaPlayer1' width='"+ intWidth +"' height='"+ intHeight +"' classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95' codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,5,715' align='baseline' border='0' standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>";
	strHtml+="<param name='invokeURLs' value='0'>";
		strHtml+="<param name='AutoRewind' value='1'>";
    	strHtml+="<param name='FileName' value=\\""+ SongUrl +"\\">";
    	strHtml+="<param name='ShowControls' value='1'>";
    	strHtml+="<param name='ShowPositionControls' value='0'>";
    	strHtml+="<param name='ShowAudioControls' value='1'>";
    	strHtml+="<param name='ShowTracker' value='1'>";
    	strHtml+="<param name='ShowDisplay' value='0'>";
    	strHtml+="<param name='ShowStatusBar' value='1'>";
    	strHtml+="<param name='AutoSize' value='0'>";
    	strHtml+="<param name='ShowGotoBar' value='0'>";
    	strHtml+="<param name='ShowCaptioning' value='0'>";
    	strHtml+="<param name='AutoStart' value='1'>";
    	strHtml+="<param name='PlayCount' value='100'>";
    	strHtml+="<param name='AnimationAtStart' value='0'>";
    	strHtml+="<param name='TransparentAtStart' value='0'>";
    	strHtml+="<param name='AllowScan' value='0'>";
    	strHtml+="<param name='EnableContextMenu' value='1'>";
    	strHtml+="<param name='ClickToPlay' value='0'>";
    	strHtml+="<param name='DefaultFrame' value='datawindow'>";
	
	
	strHtml+="<embed src=\\""+ SongUrl +"\\" align='baseline' border='0' width='"+ intWidth +"' height='"+ intHeight +"' type='application/x-mplayer2'";
        strHtml+=" pluginspage='http://www.microsoft.com/isapi/redir.dll?prd=windows&amp;sbp=mediaplayer&amp;ar=media&amp;sba=plugin&amp;'";
        strHtml+="name='MediaPlayer' showcontrols='1' showpositioncontrols='0' showaudiocontrols='1' showtracker='1' showdisplay='0' showstatusbar='1' autosize='0' showgotobar='0' showcaptioning='0' autostart='1' autorewind='1'";
        strHtml+="animationatstart='0' transparentatstart='0' allowscan='1' enablecontextmenu='1' clicktoplay='0' defaultframe='datawindow' invokeurls='0' playcount='100'> </embed></object>";
        
     
	return strHtml;
	
}

function wrtSongLink(strURL,intWidth,intHeight,type, Head)
{
	
	SongUrl = Head + strURL + GetSongType(type);
	if(SongUrl.length > 35)
		SongUrl1 = SongUrl.slice(0,24)+"......"+SongUrl.slice(-10)
	else
		SongUrl1 = SongUrl
		
	document.write("?????? <a href='"+SongUrl +"'>"+SongUrl1+"</a>")	
	//document.write("<a href=\\"#\\" onclick=\\"window.open('"+Head + strURL + GetSongType(type) +"','','width=0,height=0,top=0,left=0');\\">???????</a>")
}
//?????д????



var chkArray=document.getElementsByName("chkSongID");

//?????,s 1??,s 0???
function selAll(s){
	if(chkArray.length){
		var sel=true;
		switch(s){
			case 1:
				for(i=0;i<chkArray.length;i++){
					if(!chkArray[i].checked){
						sel=false;
						break;
					}
				}
				for(i=0;i<chkArray.length;i++){
				   chkArray[i].checked=sel?false:true; 
				}
				break;
			case 0:
				for(i=0;i<chkArray.length;i++){
				   chkArray[i].checked=chkArray[i].checked?false:true; 
				}
				break;	
		}
	}

}

//?ж?????м???????
function sel(){
	var sel=false;
	if(chkArray.length){
		for(i=0;i<chkArray.length;i++){
			if(chkArray[i].checked){
				sel=true;
				break;
			}
		}
	}
	return sel;
}


function doMusicList(){
	if(sel())
	{
		var id="";
		for(i=0;i<chkArray.length;i++)
		{
			if(chkArray[i].checked)
			{
				id+=chkArray[i].value+",";
        		}
		}
		id=id.substring(0,id.length-1);
	
		window.open("/playmusic.php?song_id="+id+"","songtaste","menubar=no,location=no,resizable=no,scrollbars=no,status=no,width=50,height=50");
	}
	else
	{
		alert("????????");
	}
}

//??????????????
function delSongBat(pageref){		
	if(sel())
	{
		var id="";
		for(i=0;i<chkArray.length;i++)
		{
			if(chkArray[i].checked)
			{
				id+=chkArray[i].value+",";
        		}
		}
		id=id.substring(0,id.length-1);
	
		if(confirm("??????????б??????????????"))
		{
			window.location="info_oper.php?tag=delsong_bat&songid="+id+"&pageref="+pageref;
		}
		
	}
	else
	{
		alert("????????");
	}
}


function addBoxList(){
	if(sel())
	{
		var id="";
		for(i=0;i<chkArray.length;i++)
		{
			if(chkArray[i].checked)
			{
				id+=chkArray[i].value+",";
        		}
		}
		id=id.substring(0,id.length-1);
	
		window.open("/info_oper.php?tag=addboxlist&song_id="+id+"","songtaste","menubar=no,location=no,resizable=no,scrollbars=no,status=no,width=280,height=150,top=200,left=210");
	}
	else
	{
		alert("????????");
	}
}





function checkall(formname, selnum)   //??л????????????????
{
	if ( document.all("selall").checked ==1  )
	{
	    for ( var i = 0; i < selnum; i++ )
	    	formname.sel[i].checked = 1;
	}
	if ( document.all("selall").checked ==0  )
	{
	    for ( var i = 0; i < selnum; i++ )
	    	formname.sel[i].checked = 0;
	}
}





var liveSwitching = true;
 
function $(){
var Var1=new Array();
for(var i=0;i<arguments.length;i++){
var Var2=arguments[i];
if(typeof Var2=="string"){
Var2=document.getElementById(Var2);
}
if(arguments.length==1){
return Var2;
}
Var1.push(Var2);
}
return Var1;
}


var WinLoad={loadfuncs:new Array(),addFunc:function(ref){
 
}

};


function switchSearch(smode) {
    if (!liveSwitching) {
        return true;
        }
    else {
        $("smode").value = smode;
        var stabs = $("taglist").getElementsByTagName("li");
        for (var i=0; i < stabs.length; i++) stabs[i].className = "";
        $("sm_"+smode).className = "selected";
        $("sb").focus();
        return false;
    } 
}






function delsong(songid, pageref)
{
	if(confirm("??????????б??????????????"))
	{
		window.location="/info_oper.php?tag=delsong&songid="+songid+"&pageref="+escape(pageref);
	}
}



function delfavsong(songid, pageref)
{
	if(confirm("??????????б??????????????"))
	{
		window.location="/info_oper.php?tag=delfavsong&songid="+songid+"&pageref="+escape(pageref);
	}
}


function delfavalbum(aid, pageref)
{
	if(confirm("??????????б??????????????"))
	{
		window.location="/info_oper.php?tag=delfavalbum&aid="+aid+"&pageref="+escape(pageref);
	}
}


function delgrpfav(favid, grpid)
{
	if(confirm("??????С??????б??????????????"))
	{
		window.location="/info_oper.php?tag=grp_delfav&favid="+favid+"&grpid="+grpid;
	}
}


function delfrd(frdid)
{
	if(confirm("??????????б?????????"))
	{
		window.location="/info_oper.php?tag=delfrd&frdid="+frdid;
	}
}

function delfavuser(favid)
{
	if(confirm("??????????б?????????"))
	{
		window.location="/info_oper.php?tag=delfavuser&favid="+favid;
	}
}

function delbad(frdid)
{
	if(confirm("??????????б?????????"))
	{
		window.location="/info_oper.php?tag=delbad&frdid="+frdid;
	}
}

function deltag(tagid)
{
	if(confirm("??????????????"))
	{
		window.location="/info_oper.php?tag=deltag&tagid="+tagid;
	}
}

function delupfile(fileid, pageref)
{
	if(confirm("????????????????ò?????????!"))
	{
		window.location="/info_oper.php?tag=delupfile&fileid="+fileid+"&pageref="+escape(pageref);
	}
}


function delsonggrade(gradeid)
{
	if(confirm("?????????????????????ò?????????!"))
	{
		window.location="/info_oper.php?tag=delsonggrade&gradeid="+gradeid;
	}
}

function delalbumcmt(cmtid)
{
	if(confirm("???????????????????ò?????????!"))
	{
		window.location="/info_oper.php?tag=del_albumcmt&cmtid="+cmtid;
	}
}


function getCookieVal(offset) { 
  var endstr = document.cookie.indexOf (";", offset); 
  if (endstr == -1) { 
    endstr = document.cookie.length; 
  } 
  return unescape(document.cookie.substring(offset, endstr)); 
} 




function getCookie(name) { 
  var arg = name + "="; 
  var alen = arg.length; 
  var clen = document.cookie.length; 
  var i = 0; 
  while (i < clen) { 
    var j = i + alen; 
    if (document.cookie.substring(i, j) == arg) { 
      return getCookieVal(j); 
    } 
    i = document.cookie.indexOf(" ", i) + 1; 
    if (i == 0) break; 
  } 
  return null; 
} 


function GetUInfoBlk()
{
	var icon = getCookie("CookIcon");
	var uid = getCookie("CookID");
	 

	if( uid == null || uid == "" || uid==0)
	{
		document.write("<div id='sign'>");
		document.write("???????????<a href='/signin.php' class='underline white'>???</a><br />");
		document.write("Or ??? <a href='/signup.php' class='underline white'>???</a>");
		document.write("</div>");		
	}
	else
	{
		if( icon == null || icon == "" )
		{
			icon = "default.gif";
		}
		else
			icon = uid.substring(uid.length-2)+"/"+icon;
		
		
		document.write("<div id='user_blk'><ul>");
		document.write("<li class='hb1'><a href='/user/"+uid+"/'>??????????????</a></li>");
		document.write("<li class='hb2'><a href='/home.php'>???????</a>  <a href='/home.php?tag=feed'>???</a></li>");
		document.write("<li class='hb3'><a href='#' onClick=window.open('/play.php?tag=box','popwin_kt','menubar=no,location=no,resizable=no,scrollbars=no,status=no,width=50,height=50'); >?????</a>??<a href='/home.php?tag=fav'>????</a></li>");
		
		
		document.write("<li><img src='http://image.songtaste.com/images/mail.gif'> <a href='/msg.php' id='msgnum'> 0 ??δ??</a> | <a href='/info_oper.php?tag=signout'>???</a></li></ul>");
		document.write("<img src='/images/usericon/s/"+icon+"' style='margin:0;margin-right:2px;margin-bottom:-3px;'>");
		document.write("</div>");
		
		path = document.location.pathname;
		if( path.substring(1,6) == "music")
			GetMsgNum();
	}
}


function GetUInfoLeft()
{
	var uid = getCookie("CookID");
	var name = getCookie("CookName");
	var icon = getCookie("CookIcon");
	
	if( uid != null && uid != "" && uid != 0 && name != null && name != "")
	{
		if( icon == null || icon == "" )
		{
			icon = "default.gif";
		}
		else
			icon = uid.substring(uid.length-2)+"/"+icon;
			
		document.write("<h1 class='h1user'>"+decodeURI(escape(name))+"</h1>");
		document.write("<div class='icon_div'><a href='/home.php'><img src='/images/usericon/l/"+icon+"' border=0 class='icon'></a></div>");
		document.write("<div class='usr_fun'>");
		document.write("<a class='add underline' href='/home.php?tag=add_song'>???????</a> <br />  ");   		
		document.write("<a class='msg underline' href='/umodi.php'>????????</a>");
		document.write("</div>");	
	}
}



function imgcheck()
{
	var imgNum = document.images.length;
	
	for(i=0;i<imgNum;i++)
	{
		if(window.document.images[i].width > 670)
			window.document.images[i].width = 670;
	}
}


function WrtFoot()
{
	//document.write("<div id='footer'><div id='foot_right'><div style='float:right;margin:0 30px 0 0;display:inline'><a href='http://www.miibeian.gov.cn' target=_blank><font color='#ffffff'>??ICP??07025509??</font></a> <font color='#ffffff'> ??????[2011]0173-066??</font> </div>                <ul class='foot_fun'><li><a href='/aboutus.php'>????????</a></li> <li><a href='/copyright.php'>???????</a></li>  <li><a href='/bbs.php?tag=board&bid=09'>??????</a></li><li><a href='/help.php'>SongTaste????</a></li> <li><a href='/sitemap.html'>?????</a></li> <li><a href='/link.php'>????????</a></li> <li><a href='/hotmusic.php'>???????</a></li></ul><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &copy; 2006 - 2011   SongTaste.com  &nbsp; Ver 1.0  &nbsp; LastUpdate: 2011.04.01</p></div></div>");
	document.write("<div id='footer'><ul class='foot_fun'><li><a href='/aboutus.php'>????????</a></li> <li><a href='/copyright.php'>???????</a></li>  <li><a href='/bbs.php?tag=board&bid=09'>??????</a></li><li><a href='/help.php'>SongTaste????</a></li> <li><a href='/sitemap.html'>?????</a></li> <li><a href='/link.php'>????????</a></li> <li><a href='/hotmusic.php'>???????</a></li> <li><a href='/musicians_coop.php'>?????????????</a></li></ul><p></p> <div style='margin:0 20px 0 0;display:inline'><a href='http://www.miibeian.gov.cn' target=_blank><font color='#CCCCCC'>??ICP??11022597??</font></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color='#CCCCCC'>??ICP?110908??</font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color='#CCCCCC'> ????????[2011]0173-066??</font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color='#CCCCCC'> ?????????? 110105005732</font> </div>&copy; 2006 - 2011   SongTaste.com  &nbsp;</div>");
	
}



function imgcheckquote(obj)
{
	if(obj.width > 600)
		obj.width = 600;
}

function codehash(n)
{
	var rnd="";
	for(var i=0;i<n;i++)
	rnd+=Math.floor(Math.random()*10);
	return rnd;
}
"