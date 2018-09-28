using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class MockScheduleFetcher : IScheduleFetcher
	{
        #region LeagueHtml
        private const string LeagueHtml = @"

<!DOCTYPE html>
<html lang=""en"">
<head>
      
      
  <meta name = ""viewport"" content=""width=device-width, initial-scale=1.0, maximum-scale=1"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" ><script type = ""text/javascript"" > window.NREUM || (NREUM ={}),__nr_require=function(e, t, n) { function r(n) { if (!t[n]) { var o = t[n] ={ exports: { } }; e[n][0].call(o.exports, function(t){ var o = e[n][1][t]; return r(o || t)},o,o.exports)}return t[n].exports
}if(""function""==typeof __nr_require)return __nr_require;for(var o=0;o<n.length;o++)r(n[o]);return r}({1:[function(e, t, n){function r(){}function o(e, t, n) { return function(){ return i(e,[f.now()].concat(u(arguments)), t ? null : this, n),t ? void 0:this} }
var i = e(""handle""), a = e(2), u = e(3), c = e(""ee"").get(""tracer""), f = e(""loader""), s = NREUM;""undefined""==typeof window.newrelic&&(newrelic=s);var p =[""setPageViewName"", ""setCustomAttribute"", ""setErrorHandler"", ""finished"", ""addToTrace"", ""inlineHit"", ""addRelease""], d = ""api-"", l = d + ""ixn-""; a(p, function(e, t){ s[t] = o(d + t, !0, ""api"")}),s.addPageAction=o(d+""addPageAction"",!0),s.setCurrentRouteName=o(d+""routeName"",!0),t.exports=newrelic,s.interaction=function() { return (new r).get()}; var m = r.prototype ={createTracer:function(e, t) { var n = { }, r = this, o = ""function"" == typeof t; return i(l + ""tracer"",[f.now(), e, n], r),function(){ if (c.emit((o ? """" : ""no-"") + ""fn-start"",[f.now(), r, o], n),o)try { return t.apply(this, arguments)} catch (e) { throw c.emit(""fn-err"",[arguments, this, e], n),e} finally { c.emit(""fn-end"",[f.now()], n)} } }};a(""setName,setAttribute,save,ignore,onEnd,getContext,end,get"".split("",""),function(e, t) { m[t] = o(l + t)}),newrelic.noticeError=function(e) { ""string"" == typeof e&& (e = new Error(e)),i(""err"",[e, f.now()])}},{}],2:[function(e, t, n){function r(e, t){var n=[],r="""",i=0;for(r in e)o.call(e, r)&&(n[i]=t(r, e[r]),i+=1);return n}var o = Object.prototype.hasOwnProperty; t.exports=r},{}],3:[function(e, t, n){function r(e, t, n){t||(t=0),""undefined""==typeof n&&(n=e?e.length:0);for(var r=-1, o=n-t||0, i=Array(o < 0 ? 0 : o);++r<o;)i[r]=e[t + r];return i}t.exports=r},{}],4:[function(e, t, n){t.exports={exists:""undefined""!=typeof window.performance&&window.performance.timing&&""undefined""!=typeof window.performance.timing.navigationStart}},{}],ee:[function(e, t, n){function r(){}function o(e) { function t(e) { return e && e instanceof r?e: e? c(e, u, i):i()}
function n(n, r, o, i) { if (!d.aborted || i) { e && e(n, r, o); for (var a = t(o), u = m(n), c = u.length, f = 0; f < c; f++) u[f].apply(a, r); var p = s[y[n]]; return p && p.push([b, n, r, a]),a} }
function l(e, t) { v[e] = m(e).concat(t)}
function m(e) { return v[e] ||[]}
function w(e) { return p[e] = p[e] || o(n)}
function g(e, t) { f(e, function(e, n){ t = t || ""feature"",y[n] = t,t in s || (s[t] =[])})}
var v = { }, y = { }, b = { on:l, emit:n, get:w, listeners:m, context:t, buffer:g, abort:a, aborted:!1 };return b}function i() { return new r}
function a() { (s.api || s.feature) && (d.aborted = !0, s = d.backlog ={ })}
var u = ""nr@context"", c = e(""gos""), f = e(2), s = { }, p = { }, d = t.exports = o(); d.backlog=s},{}],gos:[function(e, t, n){function r(e, t, n){if(o.call(e, t))return e[t];var r = n();if(Object.defineProperty&&Object.keys)try{return Object.defineProperty(e, t,{value:r,writable:!0,enumerable:!1}),r}catch(i){}return e[t]=r,r}var o = Object.prototype.hasOwnProperty; t.exports=r},{}],handle:[function(e, t, n){function r(e, t, n, r){o.buffer([e],r),o.emit(e, t, n)}var o = e(""ee"").get(""handle""); t.exports=r,r.ee=o},{}],id:[function(e, t, n){function r(e){var t=typeof e;return!e||""object""!==t&&""function""!==t?-1:e===window?0:a(e, i, function(){return o++})}var o = 1, i = ""nr@id"", a = e(""gos""); t.exports=r},{}],loader:[function(e, t, n){function r(){if(!x++){var e=h.info=NREUM.info, t=d.getElementsByTagName(""script"")[0];if(setTimeout(s.abort,3e4),!(e&&e.licenseKey&&e.applicationID&&t))return s.abort();f(y, function(t, n){ e[t] || (e[t] = n)}),c(""mark"", [""onload"", a()+h.offset],null,""api""); var n = d.createElement(""script""); n.src=""https://""+e.agent,t.parentNode.insertBefore(n, t)}}function o() { ""complete"" === d.readyState && i()}
function i() { c(""mark"",[""domContent"", a() + h.offset], null, ""api"")}
function a() { return E.exists && performance.now ? Math.round(performance.now()) : (u = Math.max((new Date).getTime(), u)) - h.offset}
var u = (new Date).getTime(), c = e(""handle""), f = e(2), s = e(""ee""), p = window, d = p.document, l = ""addEventListener"", m = ""attachEvent"", w = p.XMLHttpRequest, g = w && w.prototype; NREUM.o={ST:setTimeout,SI:p.setImmediate,CT:clearTimeout,XHR:w,REQ:p.Request,EV:p.Event,PR:p.Promise,MO:p.MutationObserver};var v = """" + location, y = { beacon:""bam.nr-data.net"", errorBeacon:""bam.nr-data.net"", agent:""js-agent.newrelic.com/nr-1071.min.js"" }, b = w && g && g[l] && !/ CriOS /.test(navigator.userAgent), h = t.exports ={offset:u,now:a,origin:v,features:{},xhrWrappable:b};e(1),d[l]? (d[l](""DOMContentLoaded"",i,!1),p[l] (""load"",r,!1)):(d[m](""onreadystatechange"",o),p[m] (""onload"",r)),c(""mark"", [""firstbyte"", u],null,""api""); var x = 0, E = e(4)},{}]},{},[""loader""]);</script>

  <link href = ""https://apps.dashplatform.com/dash/share/images/icons/dash/apple-touch-icon.png"" rel=""apple-touch-icon"" size=""180x180"" type=""image/png""/><meta name = ""apple-mobile-web-app-title"" content=""Dash Online""/><meta name = ""apple-mobile-web-app-capable"" content=""yes""/><meta name = ""apple-mobile-web-app-status-bar-style"" content=""black""/><link href = ""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon-32x32.png"" rel=""icon"" size=""32x32"" type=""image/png""/><link href = ""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon-16x16.png"" rel=""icon"" size=""16x16"" type=""image/png""/><link href = ""https://apps.dashplatform.com/dash/share/images/icons/dash/manifest.json"" rel=""manifest""/><link href = ""https://apps.dashplatform.com/dash/share/images/icons/dash/safari-pinned-tab.svg"" rel=""mask-icon"" color=""#2222b5""/><link href = ""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon.ico"" rel=""shortcut icon"" type=""image/x-icon""/><meta name = ""msapplication-config"" content=""dash/browsercongif.xml""/><meta name = ""theme-color"" content=""#ffffff""/><link href = ""//fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,700.css?deployment=1538088402"" rel=""stylesheet"" type=""text/css""/><link href = ""https://apps.dashplatform.com/dash/assets/dash/dist/css/online.min.css?deployment=1538088402"" rel=""stylesheet"" type=""text/css""/><script src = ""https://apps.dashplatform.com/dash/assets/dash/dist/js/online.min.js?deployment=1538088402"" type=""text/javascript""></script><meta property = ""og:title"" content=""WideWorld Sports Center""/><meta property = ""og:description"" content=""Welcome to WideWorld Sports Center WideWorld Sports Center - Schedules, standings, team payment and more!""/><meta property = ""og:image"" content=""https://cdn.pbrd.co/images/Hw7RdP9.jpg""/><meta property = ""og:url"" content=""https://apps.dashplatform.com/dash?cid=wideworldsports""/><meta property = ""og:type"" content=""business.business""/><link rel = ""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/v/bs4/dt-1.10.18/r-2.2.2/datatables.min.css""/>

  <script type = ""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.10.18/r-2.2.2/datatables.min.js""></script>
      <title>Welcome to WideWorld Sports Center WideWorld Sports Center - Schedules, standings, team payment and more!</title>
  
  <script type = ""text/javascript"" >
    $j = jQuery.noConflict();
  </script>

  <script type = ""text/javascript"" >
    $j(function() {
    init_mysam();
});
  </script>

      <!-- Google Analytics -->
    <script type = ""text/javascript"" >
      (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
{
    (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1* new Date(); a=s.createElement(o),
        m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
      })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

      ga('create', 'UA-651856-6', 'auto');

ga('set', 'dimension1', 'wideworldsports' );

ga('send', 'pageview');


      
    </script>
    <!-- End Google Analytics -->
    <script defer src=""https://pro.fontawesome.com/releases/v5.0.13/js/all.js"" integrity=""sha384-d84LGg2pm9KhR4mCAs3N29GQ4OYNy+K+FBHX8WhimHpPm86c839++MDABegrZ3gn"" crossorigin=""anonymous""></script>
</head>
<body>


<div id = ""fb-root"" ></ div >
< script type=""text/javascript"">
  window.fbAsyncInit = function()
{
    FB.init({
        appId: '328419437305840',
      version: 'v3.1',
      cookie: true,
      xfbml: true
    });

    $j(window).trigger('fbInitComplete');
};

(function(d, s, id){
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) {return;}
    js = d.createElement(s); js.id = id;
    // Note we were previously using //connect.facebook.net/en_US/sdk/debug.js on non-production, but facebook seems to have broken it
    js.src = 'https://connect.facebook.net/en_US/sdk.js';
    fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));
</script>
<div id = ""baseWindow"" >
  < !--Adding a container div so that we can easily hide all nav items with javascript -->
<div id = ""navbar-container"" >
  < !--Static navbar -->
  <nav class=""navbar navbar-expand-md navbar-light fixed-top noprint"" role=""navigation"">
    <div class=""container"">

      <div class=""navbar-header d-block d-md-flex col-12 col-md-3 p-0"">
        <button type = ""button"" class=""navbar-toggler float-right"" data-toggle=""collapse"" data-target="".navbar-collapse"">
          <i class=""fas fa-bars fa-2x""></i>
        </button>

        <a class=""navbar-brand"" href=""index.php"" >
        <span class=""d-inline d-sm-none float-left"">
          <i class=""fas fa-home fa-lg""></i>
        </span>
        <span class=""d-none d-sm-inline truncate-text company-title float-left"" >
          WideWorld Sports Center</span>
        </a>
      </div>

      <div class=""navbar-collapse collapse"">
        <ul class=""nav navbar-nav ml-auto align-items-left align-items-md-center"">
        
                      <li class=""nav-item "">
              <a class=""nav-link "" href=""index.php?Action=ProgramFinder/index&company=wideworldsports"">
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-clipboard-check fa-lg""></i>
                </span>
                <span class=""menu-text"">Registration</span>
              </a>
            </li>
                          <li class=""nav-item "">
                <a class=""nav-link "" href=""index.php?Action=Reservation/index&company=wideworldsports"">
                  <span class=""menu-icon d-inline-block d-md-none"">
                    <i class=""fas fa-flag fa-lg""></i>
                  </span>
                  <span class=""menu-text "" >Reservation</span>
                </a>
              </li>
                        <li class=""nav-item "">
              <a class=""nav-link "" href=""index.php?Action=Schedule/location&company=wideworldsports"">
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""far fa-calendar-alt fa-lg""></i>
                </span>
                <span class=""menu-text"">Schedule</span>
              </a>
            </li>
            <li class=""nav-item"" >
              <a class=""nav-link"" href=""https://www.wideworld-sports.com"" target=""_blank"">
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-external-link fa-lg""></i>
                </span>
                <span class=""menu-text"">Website</span>
              </a>
            </li>
            <li class=""nav-item "" >
              <a href = ""?action=support"" class=""nav-link d-none d-md-block""  data-toggle=""tooltip"" title=""Help"" >
                <i class=""fas fa-question fa-lg""></i>
              </a>
              <a href = ""?action=support"" class=""nav-link d-inline d-sm-none"" >
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-question fa-lg""></i>
                </span>
                <span class=""menu-text"">Help</span>
              </a>
            </li>
          

          
        </ul>
      </div><!--/.navbar-collapse -->
    </div>
  </nav>

  <div style = ""height: 75px;"" class=""noprint"">
    <!-- spacer so if top menu is shown it doesn't overlap with content below -->
  </div>
</div><!-- /#navbar-container -->


<script type = ""text/javascript"" >
  (function($j) {
    $j.fn.nameBadge = function(options)
{
    var settings = $j.extend({
        border:
        {
            color: 'transparent',
          width: 0
        },
        text: '#3a3ec1',
        size: 40,
        margin: -7,
        middlename: true,
        uppercase: false
      }, options);
    return this.each(function() {
        var elementText = $j(this).text();
        var initialLetters = elementText.match(settings.middlename ? /\b(\w) / g : /^\w |\b\w(?=\S +$) / g);
        var initials = initialLetters.join('');
        $j(this).text(initials);
        $j(this).css({
            'color': settings.text,
          'background-color': 'white',
          'border': settings.border.width + 'px solid ' + settings.border.color,
          'display': 'inline-block',
          'font-family': 'Arial, \'Helvetica Neue\', Helvetica, sans-serif',
          'font-size': settings.size * 0.4,
          'border-radius': settings.size + 'px',
          'width': settings.size + 'px',
          'height': settings.size + 'px',
          'line-height': settings.size + 'px',
          'margin': settings.margin + 'px',
          'text-align': 'center',
          'text-transform' : settings.uppercase ? 'uppercase' : ''
        });
    });
};
  }(jQuery));

</script>

<script type = ""text/javascript"" >
  (function($j) {
    // must be included
    $j('.name').nameBadge();
  }(jQuery));

</script>


  <div id = ""mainWindow"" class=""container"">
    
    
            
    
<div class=""container-fluid"">
  <h3>Standings</h3>

  <ul class=""flex flex-row nav nav-pills d-none d-sm-flex""><li class=""nav-item""><a class=""nav-link active "" href=""#"">Standings</a></li><li class=""nav-item""><a class=""nav-link"" href=""?Action=Schedule/location"">Location Schedule</a></li></ul><ul class=""flex flex-column nav nav-pills nav-stacked d-flex d-sm-none""><li class=""nav-item""><a class=""nav-link active "" href=""#"">Standings</a></li><li class=""nav-item""><a class=""nav-link"" href=""?Action=Schedule/location"">Location Schedule</a></li></ul>  <br/>

  <div class=""row"">
    <!-- Begin Filter Panel -->
    <div class=""col-md-12 noprint"" id=""filterPanel"" style=""display: none;"">
      <div class=""card-group"" id=""filter-options"" role=""tablist"" aria-multiselectable=""true"">
        <div class=""card card-default mb-4"">
          <div class=""card-header"" role=""tab"" id=""headingOne"" data-toggle=""collapse"" data-parent=""#filter-options""
               href=""#filter-panel"" aria-expanded=""true"" aria-controls=""filter-panel"">
            <h5 class=""card-title""><a><i class=""fa fa-search""></i> Search Options</a></h5>
          </div>
          <div id = ""filter-panel"" class="" card-collapse collapse show"" role=""tabpanel"" aria-labelledby=""filter-panel"">
            <div class=""card-body"">
              <form id = ""standingsFilterForm"" method=""GET""  role=""form"" action=""index.php?Action=League/standings""><input type = ""hidden"" name=""Action"" id=""x5bae3002c4755894947644""  value=""League/standings""/><input type = ""hidden"" name=""_method"" id=""a5bae3002c4792991170037""  value=""GET""/>              <input type = ""hidden"" name=""noheader"" id=""d5bae3002c47db579276909""  value=""""/>              <div class=""row"">
                <div class=""col-md-6"">
                  <div class=""form-group"">
                    <label class=""col-form-label"">Location</label>
                    <select id = ""facilityID"" class=""form-control"" style="""" name=""facilityID""  ><option value = '0' > All Locations</option>
<option value = ""1""  SELECTED >WideWorld Sports Center</option>
</select>
                  </div>
                </div>
                <div class=""col-md-6"">
                  <div class=""form-group"">
                    <label class=""col-form-label"">Program</label>
                    <select id = ""programID"" class=""form-control"" style="""" name=""programID""  ><option value = '0' > All Programs</option>
<option value = ""7"" > SouthEast Michigan Indoor Soccer League</option>
   <option value = ""3"" > WideWorld Arena Flag Football Leagues</option>
<option value = ""5"" > WideWorld Camp Programs</option>
<option value = ""1"" > WideWorld High School and Adult Soccer League</option>
<option value = ""6"" > WideWorld Tournament Registration</option>
<option value = ""4"" > WideWorld Youth Developmental Soccer Classes</option>
<option value = ""2"" > WideWorld Youth Soccer Leagues</option>
   </select>
                  </div>
                </div>
                <div class=""col-md-6"">
                                      <div class=""form-group"">
                      <label class=""col-form-label"">Season</label>
                      <select id = ""seasonID"" class=""form-control"" style="""" name=""seasonID""  ><option value = '0' > All Current Seasons</option>
     <optgroup label = 'Current Seasons' >< option value= ""5""  SELECTED >HS &amp; Adult Soccer Fall 1 2018</option>
<optgroup label = 'Past Seasons' >< option value=""3"" >HS &amp; Adult Soccer Summer 2018</option>
<option value = ""1"" > Adult Soccer - Spring 2018</option>
</select>
                    </div>
                                  </div>
              </div>
              </form>            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- End Filter Panel -->

    <div class=""col-md-12"">
                  <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: O30 Men Monday</th>
        </tr>
        <tr>
          <th>Team</th>
          <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=243"">
                  Tower Inn</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">8</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=178"">
                  Subs</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">6</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=272"">
                  Code Blue</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">6</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=236"">
                  Domino Men</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">5</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=159"">
                  Gasping For Air</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.333</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=264"">
                  Tigers U50 Aluminum</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">-7</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=233"">
                  Motley Brew</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">-13</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: O30 Women Thurs Rec</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=179"">
                  Blast</a>
              </td>
            
            <td class=""numeric"">5</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">26</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">17</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=188"">
                  Kicksy Chicks</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">5</td>
            
            <td class=""numeric"">0.600</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=229"">
                  Hot Flashes</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">-7</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=163"">
                  Third Shift</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">5</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">-15</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">5</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: O30 Women Tues Rec A-B</th>
        </tr>
        <tr>
          <th>Team</th>
          <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=147"">
                  Arriba Amoebas</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">11</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=276"">
                  PaceMakers</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">5</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=144"">
                  Out For Fun</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">7</td>
            
            <td class=""numeric"">0.625</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=143"">
                  Mother Truckers</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">5</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=146"">
                  Group Therapy</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=152"">
                  Just Play</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">5</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=230"">
                  PTO</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">-13</td>
            
            <td class=""numeric"">0.125</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=140"">
                  Drillers</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">-14</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Friday</th>
        </tr>
        <tr>
          <th>Team</th>
          <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=271"">
                  WWSC Friday Coed House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">9</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=223"">
                  Thundercats Friday</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">0</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=224"">
                  E-lemonators</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.167</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=187"">
                  SW Furrawris</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">-6</td>
            
            <td class=""numeric"">0.167</td>
                        <td class=""numeric"">3</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Sunday D4A</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=151"">
                  A^3</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">14</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=261"">
                  Goal Goblins</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=218"">
                  Uncommon Denominators Sunday</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=162"">
                  Soccuronium FC</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=259"">
                  Scott&#039;s Tots</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">26</td>
              <td class=""numeric"">-7</td>
            
            <td class=""numeric"">0.250</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=265"">
                  Party Fouls</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">26</td>
              <td class=""numeric"">-15</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Sunday D4B</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=249"">
                  Sean</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">11</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=208"">
                  Panda</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=279"">
                  Jokers</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">1</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=110"">
                  WWSC Sunday Coed House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">0</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">2</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=220"">
                  The Flying Wanners</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">-5</td>
            
            <td class=""numeric"">0.125</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=278"">
                  Jackdangoals</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">-9</td>
            
            <td class=""numeric"">0.167</td>
                        <td class=""numeric"">3</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Thursday D3</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=250"">
                  Umhlaba</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">31</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">15</td>
            
            <td class=""numeric"">0.800</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=156"">
                  Uncommon Denominators - Thursday</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">31</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">12</td>
            
            <td class=""numeric"">0.800</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=238"">
                  FC Goog</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.600</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=167"">
                  The Bevy Shafters</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">-5</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=169"">
                  The Producers</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">26</td>
              <td class=""numeric"">-11</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=161"">
                  Etbtsstnb</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">5</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">27</td>
              <td class=""numeric"">-14</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">5</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Thursday D4</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=282"">
                  Kicks and Gigs</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">28</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">15</td>
            
            <td class=""numeric"">0.900</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=214"">
                  Enucleation</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.600</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=258"">
                  Search and Rescue - Thursday</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">6</td>
            
            <td class=""numeric"">0.600</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=168"">
                  The Real House Team Thursday</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">-2</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=109"">
                  WWSC Thursday Coed House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">0</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=205"">
                  Barcenal</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">-2</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=149"">
                  Jeremiah&#039;s Dozen</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">-19</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Tuesday D3</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=263"">
                  Thundercats Tuesday</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">27</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">12</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=277"">
                  Suddenly Whales Are Gone</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">7</td>
            
            <td class=""numeric"">0.625</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=136"">
                  Michigan Misfits</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">7</td>
            
            <td class=""numeric"">0.625</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=142"">
                  McCurdy Electric</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">-8</td>
            
            <td class=""numeric"">0.375</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=148"">
                  Maroooon Wolves</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">2</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">-8</td>
            
            <td class=""numeric"">0.250</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=180"">
                  Ragnarok</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">28</td>
              <td class=""numeric"">-10</td>
            
            <td class=""numeric"">0.125</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Coed Tuesday D4</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=248"">
                  RRTRT</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">11</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=141"">
                  Uncommon Denominators Tuesday</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">10</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=275"">
                  ZOLLER Microns</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">9</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=145"">
                  The Real House Team Tuesday</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">8</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=257"">
                  Search and Rescue - Tuesday</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=247"">
                  TTFC Spaceballs</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">25</td>
              <td class=""numeric"">33</td>
              <td class=""numeric"">-8</td>
            
            <td class=""numeric"">0.250</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=107"">
                  WWSC Tuesday Coed House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">-8</td>
            
            <td class=""numeric"">0.250</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=166"">
                  Mad Scientists</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">29</td>
              <td class=""numeric"">-19</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Men Monday</th>
        </tr>
        <tr>
          <th>Team</th>
          <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=287"">
                  Ann Arbor FC</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">12</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=245"">
                  X-Men</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">30</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">10</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=221"">
                  AASC Arsenal</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">10</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=239"">
                  Apex FC</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">-9</td>
            
            <td class=""numeric"">0.333</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=212"">
                  Hot Coffee</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">-9</td>
            
            <td class=""numeric"">0.250</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=106"">
                  WWSC Monday Men House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">26</td>
              <td class=""numeric"">-14</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Men Sunday D3</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=138"">
                  Nerdy Engineers FC</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">10</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=207"">
                  Hangover 96</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">6</td>
            
            <td class=""numeric"">0.625</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=215"">
                  Rusenas FC</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=217"">
                  Galacticos Sunday</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.375</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=262"">
                  TUE Allstars</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">-10</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">3</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Men Sunday D4</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=132"">
                  Big George&#039;s</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">9</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=226"">
                  SouthStreet FC</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">8</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=210"">
                  TTFC Prime Directive</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=150"">
                  Orange Crush</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">-4</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=111"">
                  WWSC Sunday Men House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">5</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=211"">
                  BOGO</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">-4</td>
            
            <td class=""numeric"">0.375</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=139"">
                  Cashmere Lions</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">1</td>
            
            <td class=""numeric"">0.333</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=270"">
                  WOL FAMILY FC</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">-10</td>
            
            <td class=""numeric"">0.250</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=216"">
                  Greys</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">-5</td>
            
            <td class=""numeric"">0.167</td>
                        <td class=""numeric"">3</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Men Wednesday D2</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=256"">
                  Bees Knees FC</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">33</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">10</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">6</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=280"">
                  FC Purchasing</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.700</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=242"">
                  Mug Club FC</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">0</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=219"">
                  AASC Manchester United</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">25</td>
              <td class=""numeric"">-6</td>
            
            <td class=""numeric"">0.300</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=158"">
                  Kicked Out</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">-7</td>
            
            <td class=""numeric"">0.300</td>
                        <td class=""numeric"">5</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Men Wednesday D3</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=157"">
                  PUT IT AWAY!</a>
              </td>
            
            <td class=""numeric"">5</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">31</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">19</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=213"">
                  Atletico Madrid</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">15</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=227"">
                  Gold Team</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.625</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=237"">
                  BarryCuda</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">-2</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=267"">
                  Coyote Logistics</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">25</td>
              <td class=""numeric"">-6</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=155"">
                  Cirrhotics</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">25</td>
              <td class=""numeric"">-12</td>
            
            <td class=""numeric"">0.300</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=268"">
                  Little Green Men</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">29</td>
              <td class=""numeric"">-7</td>
            
            <td class=""numeric"">0.200</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=160"">
                  Mexico</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">15</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">-9</td>
            
            <td class=""numeric"">0.100</td>
                        <td class=""numeric"">5</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: Open Men Wednesday D4</th>
            </tr>
        <tr>
          <th>Team</th>
              <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=209"">
                  POWER Surge</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">32</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">12</td>
            
            <td class=""numeric"">0.900</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=108"">
                  WWSC Wednesday Men House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">29</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">12</td>
            
            <td class=""numeric"">0.900</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=244"">
                  Spirit</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">32</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">16</td>
            
            <td class=""numeric"">0.800</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=222"">
                  Penguins</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">28</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">4</td>
            
            <td class=""numeric"">0.700</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=260"">
                  Ball Hogs</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">25</td>
              <td class=""numeric"">-1</td>
            
            <td class=""numeric"">0.400</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=241"">
                  TTC FC</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">-1</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=228"">
                  Genchi GenBootsyou</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">22</td>
              <td class=""numeric"">-9</td>
            
            <td class=""numeric"">0.200</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=283"">
                  Cahoots</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">1</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">34</td>
              <td class=""numeric"">-18</td>
            
            <td class=""numeric"">0.100</td>
                        <td class=""numeric"">5</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=240"">
                  Clinc</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">5</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">19</td>
              <td class=""numeric"">34</td>
              <td class=""numeric"">-15</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">5</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>    <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan = ""12"" > League Standings: WWSC HS Individual House League</th>
        </tr>
        <tr>
          <th>Team</th>
          <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=112"">
                  WWSC Fr/So High School House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">6</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">-2</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a style = ""color:blue"" href=""index.php?Action=Team/index&company=wideworldsports&teamid=113"">
                  WWSC Jr/Sr High School House Team - Fall 1</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.333</td>
                        <td class=""numeric"">3</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF(Your facility may not adhere to the standing rules above)</div>          </div>
  </div>
</div>

<script type = ""text/javascript"" >
  if (!(SIT_Utils.getQueryVariable('filter') === '0' && !$j('.no-results-found-message').length)) {
    $j('#filterPanel').show();
  }
</script>

    </div>
  </div>
  <div id = ""footerWindow"" class=""text-muted"">
    <div class=""container"">
      <a href = ""http://www.dashplatform.com"" >< img src=""/dash/share/images/Dash-logo-v3-blue.svg"" width=""20"" alt=""Dash Logo"" style=""margin-right:5px;""/></a>
      <div class=""height-30"">
        &#169; 2018 Dash Platform
            </div>
          </div>
  </div>
<div id = ""windowNotice"" >
  < div class=""alert alert-info"" style=""margin-left: auto; margin-right: auto; width:60%""></div>
</div>

<script type = ""text/javascript"" >
  var $form = $j('#standingsFilterForm');
  $form.find('[name=""facilityID""]').change(function() {
    $form.find('[name=""seasonID""]').val(0);
    $form.submit();
});
  $form.find('[name=""seasonID""]').change(function() {
    $form.submit();
});
  $form.find('[name=""programID""]').change(function() {
    $form.submit();
});

</script><script type = ""text/javascript"" > window.NREUM || (NREUM ={});NREUM.info={""beacon"":""bam.nr-data.net"",""licenseKey"":""fceb57b065"",""applicationID"":""57595163"",""transactionName"":""YQRTZEVRWRJRVEVcW1hOZEJeH0ISQhhdWldXDR5DX1FFBB9EWEEbTgVQQ18fRxRSW1hWG1IAQlgYWVkFVU8fRVxG"",""queueTime"":0,""applicationTime"":151,""atts"":""TUNQEg1LShw="",""errorBeacon"":""bam.nr-data.net"",""agent"":""""}</script></body>
</html>
";
        #endregion
        #region TeamHtml
        private const string TeamHtml = @"

<!DOCTYPE html>
<html lang=""en"">
<head>
      
      
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0, maximum-scale=1"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" ><script type=""text/javascript"">window.NREUM||(NREUM={}),__nr_require=function(e,t,n){function r(n){if(!t[n]){var o=t[n]={exports:{}};e[n][0].call(o.exports,function(t){var o=e[n][1][t];return r(o||t)},o,o.exports)}return t[n].exports}if(""function""==typeof __nr_require)return __nr_require;for(var o=0;o<n.length;o++)r(n[o]);return r}({1:[function(e,t,n){function r(){}function o(e,t,n){return function(){return i(e,[f.now()].concat(u(arguments)),t?null:this,n),t?void 0:this}}var i=e(""handle""),a=e(2),u=e(3),c=e(""ee"").get(""tracer""),f=e(""loader""),s=NREUM;""undefined""==typeof window.newrelic&&(newrelic=s);var p=[""setPageViewName"",""setCustomAttribute"",""setErrorHandler"",""finished"",""addToTrace"",""inlineHit"",""addRelease""],d=""api-"",l=d+""ixn-"";a(p,function(e,t){s[t]=o(d+t,!0,""api"")}),s.addPageAction=o(d+""addPageAction"",!0),s.setCurrentRouteName=o(d+""routeName"",!0),t.exports=newrelic,s.interaction=function(){return(new r).get()};var m=r.prototype={createTracer:function(e,t){var n={},r=this,o=""function""==typeof t;return i(l+""tracer"",[f.now(),e,n],r),function(){if(c.emit((o?"""":""no-"")+""fn-start"",[f.now(),r,o],n),o)try{return t.apply(this,arguments)}catch(e){throw c.emit(""fn-err"",[arguments,this,e],n),e}finally{c.emit(""fn-end"",[f.now()],n)}}}};a(""setName,setAttribute,save,ignore,onEnd,getContext,end,get"".split("",""),function(e,t){m[t]=o(l+t)}),newrelic.noticeError=function(e){""string""==typeof e&&(e=new Error(e)),i(""err"",[e,f.now()])}},{}],2:[function(e,t,n){function r(e,t){var n=[],r="""",i=0;for(r in e)o.call(e,r)&&(n[i]=t(r,e[r]),i+=1);return n}var o=Object.prototype.hasOwnProperty;t.exports=r},{}],3:[function(e,t,n){function r(e,t,n){t||(t=0),""undefined""==typeof n&&(n=e?e.length:0);for(var r=-1,o=n-t||0,i=Array(o<0?0:o);++r<o;)i[r]=e[t+r];return i}t.exports=r},{}],4:[function(e,t,n){t.exports={exists:""undefined""!=typeof window.performance&&window.performance.timing&&""undefined""!=typeof window.performance.timing.navigationStart}},{}],ee:[function(e,t,n){function r(){}function o(e){function t(e){return e&&e instanceof r?e:e?c(e,u,i):i()}function n(n,r,o,i){if(!d.aborted||i){e&&e(n,r,o);for(var a=t(o),u=m(n),c=u.length,f=0;f<c;f++)u[f].apply(a,r);var p=s[y[n]];return p&&p.push([b,n,r,a]),a}}function l(e,t){v[e]=m(e).concat(t)}function m(e){return v[e]||[]}function w(e){return p[e]=p[e]||o(n)}function g(e,t){f(e,function(e,n){t=t||""feature"",y[n]=t,t in s||(s[t]=[])})}var v={},y={},b={on:l,emit:n,get:w,listeners:m,context:t,buffer:g,abort:a,aborted:!1};return b}function i(){return new r}function a(){(s.api||s.feature)&&(d.aborted=!0,s=d.backlog={})}var u=""nr@context"",c=e(""gos""),f=e(2),s={},p={},d=t.exports=o();d.backlog=s},{}],gos:[function(e,t,n){function r(e,t,n){if(o.call(e,t))return e[t];var r=n();if(Object.defineProperty&&Object.keys)try{return Object.defineProperty(e,t,{value:r,writable:!0,enumerable:!1}),r}catch(i){}return e[t]=r,r}var o=Object.prototype.hasOwnProperty;t.exports=r},{}],handle:[function(e,t,n){function r(e,t,n,r){o.buffer([e],r),o.emit(e,t,n)}var o=e(""ee"").get(""handle"");t.exports=r,r.ee=o},{}],id:[function(e,t,n){function r(e){var t=typeof e;return!e||""object""!==t&&""function""!==t?-1:e===window?0:a(e,i,function(){return o++})}var o=1,i=""nr@id"",a=e(""gos"");t.exports=r},{}],loader:[function(e,t,n){function r(){if(!x++){var e=h.info=NREUM.info,t=d.getElementsByTagName(""script"")[0];if(setTimeout(s.abort,3e4),!(e&&e.licenseKey&&e.applicationID&&t))return s.abort();f(y,function(t,n){e[t]||(e[t]=n)}),c(""mark"",[""onload"",a()+h.offset],null,""api"");var n=d.createElement(""script"");n.src=""https://""+e.agent,t.parentNode.insertBefore(n,t)}}function o(){""complete""===d.readyState&&i()}function i(){c(""mark"",[""domContent"",a()+h.offset],null,""api"")}function a(){return E.exists&&performance.now?Math.round(performance.now()):(u=Math.max((new Date).getTime(),u))-h.offset}var u=(new Date).getTime(),c=e(""handle""),f=e(2),s=e(""ee""),p=window,d=p.document,l=""addEventListener"",m=""attachEvent"",w=p.XMLHttpRequest,g=w&&w.prototype;NREUM.o={ST:setTimeout,SI:p.setImmediate,CT:clearTimeout,XHR:w,REQ:p.Request,EV:p.Event,PR:p.Promise,MO:p.MutationObserver};var v=""""+location,y={beacon:""bam.nr-data.net"",errorBeacon:""bam.nr-data.net"",agent:""js-agent.newrelic.com/nr-1071.min.js""},b=w&&g&&g[l]&&!/CriOS/.test(navigator.userAgent),h=t.exports={offset:u,now:a,origin:v,features:{},xhrWrappable:b};e(1),d[l]?(d[l](""DOMContentLoaded"",i,!1),p[l](""load"",r,!1)):(d[m](""onreadystatechange"",o),p[m](""onload"",r)),c(""mark"",[""firstbyte"",u],null,""api"");var x=0,E=e(4)},{}]},{},[""loader""]);</script>

  <link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/apple-touch-icon.png"" rel=""apple-touch-icon"" size=""180x180"" type=""image/png""/><meta name=""apple-mobile-web-app-title"" content=""Dash Online""/><meta name=""apple-mobile-web-app-capable"" content=""yes""/><meta name=""apple-mobile-web-app-status-bar-style"" content=""black""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon-32x32.png"" rel=""icon"" size=""32x32"" type=""image/png""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon-16x16.png"" rel=""icon"" size=""16x16"" type=""image/png""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/manifest.json"" rel=""manifest""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/safari-pinned-tab.svg"" rel=""mask-icon"" color=""#2222b5""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon.ico"" rel=""shortcut icon"" type=""image/x-icon""/><meta name=""msapplication-config"" content=""dash/browsercongif.xml""/><meta name=""theme-color"" content=""#ffffff""/><link href=""//fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,700.css?deployment=1538088402"" rel=""stylesheet"" type=""text/css""/><link href=""https://apps.dashplatform.com/dash/assets/dash/dist/css/online.min.css?deployment=1538088402"" rel=""stylesheet"" type=""text/css""/><script src=""https://apps.dashplatform.com/dash/assets/dash/dist/js/online.min.js?deployment=1538088402"" type=""text/javascript""></script><meta property=""og:title"" content=""WideWorld Sports Center""/><meta property=""og:description"" content=""Welcome to WideWorld Sports Center WideWorld Sports Center - Schedules, standings, team payment and more!""/><meta property=""og:image"" content=""https://cdn.pbrd.co/images/Hw7RdP9.jpg""/><meta property=""og:url"" content=""https://apps.dashplatform.com/dash?cid=wideworldsports""/><meta property=""og:type"" content=""business.business""/><link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/v/bs4/dt-1.10.18/r-2.2.2/datatables.min.css""/>

  <script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.10.18/r-2.2.2/datatables.min.js""></script>
      <title>Welcome to WideWorld Sports Center WideWorld Sports Center - Schedules, standings, team payment and more!</title>
  
  <script type=""text/javascript"">
    $j = jQuery.noConflict();
  </script>

  <script type=""text/javascript"">
    $j(function() {
      init_mysam();
    });
  </script>

      <!-- Google Analytics -->
    <script type=""text/javascript"">
      (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
          (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
        m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
      })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

      ga('create', 'UA-651856-6', 'auto');

            ga('set', 'dimension1', 'wideworldsports' );
      
      ga('send', 'pageview');


      
    </script>
    <!-- End Google Analytics -->
    <script defer src=""https://pro.fontawesome.com/releases/v5.0.13/js/all.js"" integrity=""sha384-d84LGg2pm9KhR4mCAs3N29GQ4OYNy+K+FBHX8WhimHpPm86c839++MDABegrZ3gn"" crossorigin=""anonymous""></script>
</head>
<body>


<div id=""fb-root""></div>
<script type=""text/javascript"">
  window.fbAsyncInit = function() {
    FB.init({
      appId: '328419437305840',
      version: 'v3.1',
      cookie: true,
      xfbml: true
    });

    $j(window).trigger('fbInitComplete');
  };

  (function(d, s, id){
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) {return;}
    js = d.createElement(s); js.id = id;
    // Note we were previously using //connect.facebook.net/en_US/sdk/debug.js on non-production, but facebook seems to have broken it
    js.src = 'https://connect.facebook.net/en_US/sdk.js';
    fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));
</script>
<div id=""baseWindow"">
  <!-- Adding a container div so that we can easily hide all nav items with javascript -->
<div id=""navbar-container"">
  <!-- Static navbar -->
  <nav class=""navbar navbar-expand-md navbar-light fixed-top noprint"" role=""navigation"">
    <div class=""container"">

      <div class=""navbar-header d-block d-md-flex col-12 col-md-3 p-0"">
        <button type=""button"" class=""navbar-toggler float-right"" data-toggle=""collapse"" data-target="".navbar-collapse"">
          <i class=""fas fa-bars fa-2x""></i>
        </button>

        <a class=""navbar-brand"" href=""index.php"" >
        <span class=""d-inline d-sm-none float-left"">
          <i class=""fas fa-home fa-lg""></i>
        </span>
        <span class=""d-none d-sm-inline truncate-text company-title float-left"" >
          WideWorld Sports Center        </span>
        </a>
      </div>

      <div class=""navbar-collapse collapse"">
        <ul class=""nav navbar-nav ml-auto align-items-left align-items-md-center"">
        
                      <li class=""nav-item "">
              <a class=""nav-link "" href=""index.php?Action=ProgramFinder/index&company=wideworldsports"">
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-clipboard-check fa-lg""></i>
                </span>
                <span class=""menu-text"">Registration</span>
              </a>
            </li>
                          <li class=""nav-item "">
                <a class=""nav-link "" href=""index.php?Action=Reservation/index&company=wideworldsports"">
                  <span class=""menu-icon d-inline-block d-md-none"">
                    <i class=""fas fa-flag fa-lg""></i>
                  </span>
                  <span class=""menu-text "" >Reservation</span>
                </a>
              </li>
                        <li class=""nav-item "">
              <a class=""nav-link "" href=""index.php?Action=Schedule/location&company=wideworldsports"">
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""far fa-calendar-alt fa-lg""></i>
                </span>
                <span class=""menu-text"">Schedule</span>
              </a>
            </li>
            <li class=""nav-item"" >
              <a class=""nav-link"" href=""https://www.wideworld-sports.com"" target=""_blank"">
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-external-link fa-lg""></i>
                </span>
                <span class=""menu-text"">Website</span>
              </a>
            </li>
            <li class=""nav-item "" >
              <a href=""?action=support"" class=""nav-link d-none d-md-block""  data-toggle=""tooltip"" title=""Help"" >
                <i class=""fas fa-question fa-lg""></i>
              </a>
              <a href=""?action=support"" class=""nav-link d-inline d-sm-none"" >
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-question fa-lg""></i>
                </span>
                <span class=""menu-text"">Help</span>
              </a>
            </li>
          

                      <li class=""nav-item "">
              <a href=""index.php?Action=Auth/login&company=wideworldsports"" class=""nav-link d-none d-md-block"" >
                <span style=""border: white 1px solid; padding: .8em; border-radius: .3em;"">
                  Log In
                </span>
              </a>
              <a href=""index.php?Action=Auth/login&company=wideworldsports"" class=""nav-link d-inline d-md-none"" >
                <span class=""menu-icon d-inline-block d-md-none"">
                  <i class=""fas fa-user-circle fa-lg""></i>
                </span>
                <span class=""menu-text "" >Log In</span>
              </a>
            </li>

          
        </ul>
      </div><!--/.navbar-collapse -->
    </div>
  </nav>

  <div style=""height: 75px;"" class=""noprint"">
    <!-- spacer so if top menu is shown it doesn't overlap with content below -->
  </div>
</div><!-- /#navbar-container -->


<script type=""text/javascript"">
  (function ($j) {
    $j.fn.nameBadge = function (options) {
      var settings = $j.extend({
        border: {
          color: 'transparent',
          width: 0
        },
        text: '#3a3ec1',
        size: 40,
        margin: -7,
        middlename: true,
        uppercase: false
      }, options);
      return this.each(function () {
        var elementText = $j(this).text();
        var initialLetters = elementText.match(settings.middlename ? /\b(\w)/g : /^\w|\b\w(?=\S+$)/g);
        var initials = initialLetters.join('');
        $j(this).text(initials);
        $j(this).css({
          'color': settings.text,
          'background-color': 'white',
          'border': settings.border.width + 'px solid ' + settings.border.color,
          'display': 'inline-block',
          'font-family': 'Arial, \'Helvetica Neue\', Helvetica, sans-serif',
          'font-size': settings.size * 0.4,
          'border-radius': settings.size + 'px',
          'width': settings.size + 'px',
          'height': settings.size + 'px',
          'line-height': settings.size + 'px',
          'margin': settings.margin + 'px',
          'text-align': 'center',
          'text-transform' : settings.uppercase ? 'uppercase' : ''
        });
      });
    };
  }(jQuery));

</script>

<script type=""text/javascript"">
  (function ($j) {
    // must be included
    $j('.name').nameBadge();
  }(jQuery));

</script>


  <div id=""mainWindow"" class=""container"">
    
    
            
    

<h2>Team Subs</h2>
<br class=""clearfix"">


<ul class=""nav nav-pills"">
      <li class=""nav-item""><a class=""nav-link"" href=""#schedules"">Schedules</a></li>
        <li class=""nav-item""><a class=""nav-link"" href=""#standings"">Standings</a></li>
    <li class=""nav-item dropdown"">
    <a class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" href=""#"">
      Team <span class=""caret""></span>
    </a>
    <ul class=""dropdown-menu"">
                                    <li class=""dropdown-item""><a class=""active"" href=""index.php?Action=Auth/login&company=wideworldsports"">Login</a></li>
          </ul>
  </li>
  
</ul>
<br/>

<!-- Instructor Display -->

<h4>Description</h4>

Starting 08/29/2018 HS &amp; Adult Soccer Fall 1 2018<br/>
Soccer, Indoor, B - Intermediate, Males only  <br/>Ages Adult   (over 18 years old)
<br/> Games 8<br/>

  There are no games Labor Day Weekend, Aug 31 - Sept 3<br/>

  <h4 style=""float:left; margin-right:10px;"">Team Color</h4>
  <div style=""margin-top:5px;"">
    <form id=""p5bae306fe39ca0-20070801"" method=""POST""  role=""form"" action=""index.php?Action=TeamAction/save&company=wideworldsports""><input type=""hidden"" name=""_method"" id=""o5bae306fe3a21085286260""  value=""POST""/>    <div class=""form-group""><input type=""text"" name=""color"" id=""z5bae306fe3a61213545130""  disabled class=""form-control"" value=""#1637d9""/><script>jQuery('#z5bae306fe3a61213545130').spectrum({""preferredFormat"":""hex"",""allowEmpty"":true,""disabled"":true});</script><span class=""form-text invalid-feedback""></span></div>    </form>  </div>



  <a name=""schedules""></a>
  <h3>Schedule</h3>
        <ul class=""flex flex-row list-group clearfix flex-wrap"">
              <li  class=""col-md-6 list-group-item  "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                9/10 Mon                7:30pm              </h4>
              <b>WideWorld Sports Center</b><br>
              Big George's Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">8</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">4</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=233"">Motley Brew</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=835"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item  "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                9/17 Mon                8:30pm              </h4>
              <b>WideWorld Sports Center</b><br>
              Big George's Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">5</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">7</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=243"">Tower Inn</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=838"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item  "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                9/17 Mon                9:30pm              </h4>
              <b>WideWorld Sports Center</b><br>
              Big George's Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">5</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=159"">Gasping For Air</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">8</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=832"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item  "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                9/24 Mon                9:30pm              </h4>
              <b>WideWorld Sports Center</b><br>
              Big George's Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">1</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=233"">Motley Brew</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px"">2</td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=841"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item list-group-item-info "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                10/1 Mon                8:45pm              </h4>
              <b>WideWorld Sports Center</b><br>
              South Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=272"">Code Blue</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=845"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item list-group-item-info "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                10/8 Mon                7:30pm              </h4>
              <b>WideWorld Sports Center</b><br>
              Big George's Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=264"">Tigers U50 Aluminum</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=849"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item list-group-item-info "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                10/15 Mon                7:30pm              </h4>
              <b>WideWorld Sports Center</b><br>
              Big George's Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=243"">Tower Inn</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=853"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
              <li  class=""col-md-6 list-group-item list-group-item-info "">
          <div class=""row"">
            <div class=""col-5"">
              <h4 class=""list-group-item-heading"">
                10/22 Mon                8:45pm              </h4>
              <b>WideWorld Sports Center</b><br>
              South Field  <br>
              Game              01h 00m<br>

            </div>
            <div class=""col-7"">

            <p class=""list-group-item-text"">

                          <table>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">Subs</a></td>

                </tr>
                <tr>
                  <td class=""lead"" style=""min-width: 50px""></td>
                  <td><a href=""index.php?Action=team/index&company=wideworldsports&teamid=236"">Domino Men</a></td>
                </tr>
              </table>
            
              <div style=""margin-left: 50px"">
                <br>
                                  <a class=""btn btn-secondary btn-sm"" href=""index.php?Action=Stats/game&company=wideworldsports&eventID=856"">Stats</a>
                
                
                              </div>

          </p>

            </div>
          </div>
        </li>
            </ul>
        <a name=""standings""></a>
  <h3>League Standings</h3>
      <div class=""table-responsive"">
      <table class=""table table-striped"">
        <tr>
          <th colspan=""12"">League Standings: O30 Men Monday</th>
        </tr>
        <tr>
          <th>Team</th>
          <th class=""numeric"">W</th>
          <th class=""numeric"">T</th>
          <th class=""numeric"">L</th>

                      <th class=""numeric"">+Pts</th>
            <th class=""numeric"" style=""background-color: #99dd99"">Pts</th>
            <th class=""numeric"">GF</th>
            <th class=""numeric"">GA</th>
            <th class=""numeric"">GD</th>
          
          <th class=""numeric"">PCT</th>

          
          <th class=""numeric"">GP</th>
        </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=243"">
                  Tower Inn</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">20</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">8</td>
            
            <td class=""numeric"">1.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=178"">
                  Subs</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">1</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">9</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">6</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=272"">
                  Code Blue</a>
              </td>
            
            <td class=""numeric"">2</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">8</td>
              <td class=""numeric"">6</td>
            
            <td class=""numeric"">0.750</td>
                        <td class=""numeric"">4</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=236"">
                  Domino Men</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">5</td>
              <td class=""numeric"">7</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">3</td>
            
            <td class=""numeric"">0.667</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=159"">
                  Gasping For Air</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">16</td>
              <td class=""numeric"">-3</td>
            
            <td class=""numeric"">0.333</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=264"">
                  Tigers U50 Aluminum</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">4</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">-7</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">3</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=233"">
                  Motley Brew</a>
              </td>
            
            <td class=""numeric"">0</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">0</td>
              <td class=""numeric"">11</td>
              <td class=""numeric"">24</td>
              <td class=""numeric"">-13</td>
            
            <td class=""numeric"">0.000</td>
                        <td class=""numeric"">4</td>
          </tr>
              </table>
    </div>
    <div class='text-muted text-small'>Standings sorted by: Pts, GD, wins, GF (Your facility may not adhere to the standing rules above)</div>


<!-- Request Join Modal -->
<div id=""joinModal"" class=""modal fade"" role=""dialog"">
  <div class=""modal-dialog"">

    <!-- Modal content-->
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h4 class=""modal-title"">Request to join Subs</h4>
        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
      </div>
      <div class=""modal-body"">
        <p>
           is requesting to join a group. You will receive an email notification when
          a group manager accepts or rejects your request.
        </p>
        <button onclick=""requestJoin()"" class=""btn btn-primary text-center"">Request Membership</button>
      </div>
    </div>

  </div>
</div>

    </div>
  </div>
  <div id=""footerWindow"" class=""text-muted"">
    <div class=""container"">
      <a href=""http://www.dashplatform.com""><img src=""/dash/share/images/Dash-logo-v3-blue.svg"" width=""20"" alt=""Dash Logo"" style=""margin-right:5px;""/></a>
      <div class=""height-30"">
        &#169; 2018 Dash Platform
            </div>
          </div>
  </div>
<div id=""windowNotice"">
  <div class=""alert alert-info"" style=""margin-left: auto; margin-right: auto; width:60%""></div>
</div>

<script type=""text/javascript"">

  function processAjaxResponse(jqXHR, textStatus, errorThrown) {
    console.log(jqXHR);
    var options = {
      hideAfter: 5
    };
    jqXHR.formErrors.map(function(v,k) {
      dashMessage(v, 'error', options);
    });
    jqXHR.formSuccess.map(function(v,k) {
      dashMessage(v, 'success', options);
    });
  }

  function requestJoin() {
    $j.ajax({
      url: 'index.php?Action=Team/join.json&extension=json&company=wideworldsports',
      dataType: 'json',
      cache: false,
      async: true,
      type: 'POST',
      data: {
        customerID: 0,
        teamID: 178      }
    }).always(function(jqXHR, textStatus, errorThrown){
      processAjaxResponse(jqXHR, textStatus, errorThrown);
      $j('#joinModal').modal('hide');
    });
    return;
  }

  function leaveTeam(e) {
    e.preventDefault();
    if(confirm('Are you sure you want to leave?')) {
      $j.ajax({
        url: 'index.php?Action=Team/remove.json&extension=json&company=wideworldsports',
        dataType: 'json',
        cache: false,
        async: true,
        type: 'POST',
        data: {
          customerID: 0,
          teamID: 178        }
      }).done(function (data, textStatus, jqXHR) {
        if(data.formErrors.length) {
          data.formErrors.map(function(e,k){dashMessage(e,'error')});
        } else {
          dashMessage(""You have been successfully removed from the team. You will now be redirected."", 'success');
          setTimeout(function () {
            location.replace('index.php?Action=Team/index&teamid=178&leave=1&company=wideworldsports')
          }, 3000)
        }
      }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(jqXHR);
        if(jqXHR.responseJSON.error) {
          dashMessage(""An error occurred. "" + jqXHR.responseJSON.error.message + "" A system administrator has been notified"", 'error');
        } else {
          dashMessage(""An error occurred "" + errorThrown + "". A system administrator has been notified"", 'error');
        }
      }).always(function (jqXHR, textStatus, errorThrown) {
      });
    }
  }


</script><script type=""text/javascript"">window.NREUM||(NREUM={});NREUM.info={""beacon"":""bam.nr-data.net"",""licenseKey"":""fceb57b065"",""applicationID"":""57595163"",""transactionName"":""YQRTZEVRWRJRVEVcW1hOZEJeH0ISQhhdWldXDR5DX1FFBB9EWEEbTgVQQ18fRxRSW1hWG1IAQlgYWVkFVU8fRVxG"",""queueTime"":0,""applicationTime"":94,""atts"":""TUNQEg1LShw="",""errorBeacon"":""bam.nr-data.net"",""agent"":""""}</script></body>
</html>
";
        #endregion

        private const int delayMs = 5000;

		public async Task<List<NavigationOption>> GetSeasons()
        {
            await Task.Delay(delayMs);
            return ScheduleHtmlParser.GetSeasons(LeagueHtml).ToList();
		}

		public async Task<Dictionary<string, List<NavigationOption>>> GetLeagues(int divisionId)
		{
			await Task.Delay(delayMs);
            throw new NotImplementedException();
		}

		public async Task<List<Game>> GetTeamSchedule(int teamId)
		{
			await Task.Delay(delayMs);
			return ScheduleHtmlParser.GetTeamSchedule(teamId, TeamHtml).ToList();
		}
	}
}
