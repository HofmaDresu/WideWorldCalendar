using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WideWorldCalendar.ScheduleFetcher;

namespace WideWorldCalendar.Core.Test
{
    [TestClass]
    public class ScheduleHtmlParserTest
    {

        #region TeamHtml
        private const string TeamHtml = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
      
      
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0, maximum-scale=1"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" >

  <link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/apple-touch-icon.png"" rel=""apple-touch-icon"" size=""180x180"" type=""image/png""/><meta name=""apple-mobile-web-app-title"" content=""Dash Online""/><meta name=""apple-mobile-web-app-capable"" content=""yes""/><meta name=""apple-mobile-web-app-status-bar-style"" content=""black""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon-32x32.png"" rel=""icon"" size=""32x32"" type=""image/png""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon-16x16.png"" rel=""icon"" size=""16x16"" type=""image/png""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/manifest.json"" rel=""manifest""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/safari-pinned-tab.svg"" rel=""mask-icon"" color=""#2222b5""/><link href=""https://apps.dashplatform.com/dash/share/images/icons/dash/favicon.ico"" rel=""shortcut icon"" type=""image/x-icon""/><meta name=""msapplication-config"" content=""dash/browsercongif.xml""/><meta name=""theme-color"" content=""#ffffff""/><link href=""//fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,700.css?deployment=1571166088"" rel=""stylesheet"" type=""text/css""/>    <script defer src=""https://pro.fontawesome.com/releases/v5.0.13/js/all.js"" integrity=""sha384-d84LGg2pm9KhR4mCAs3N29GQ4OYNy+K+FBHX8WhimHpPm86c839++MDABegrZ3gn"" crossorigin=""anonymous""></script>
    <link href=""https://apps.dashplatform.com/dash/assets/dash/dist/css/online.min.css?deployment=1571166088"" rel=""stylesheet"" type=""text/css""/><script src=""https://apps.dashplatform.com/dash/assets/dash/dist/js/online.min.js?deployment=1571166088"" type=""text/javascript""></script><meta property=""og:title"" content=""WideWorld Sports Center""/><meta property=""og:description"" content=""Welcome to WideWorld Sports Center WideWorld Sports Center - Schedules, standings, team payment and more!""/><meta property=""og:image"" content=""https://cdn.pbrd.co/images/Hw7RdP9.jpg""/><meta property=""og:url"" content=""https://apps.dashplatform.com/dash?cid=wideworldsports""/><meta property=""og:type"" content=""business.business""/>  
  <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/v/bs4/dt-1.10.18/r-2.2.2/datatables.min.css""/>

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
  <nav class=""navbar navbar-expand-md navbar-light fixed-top noprint p-0"" role=""navigation"">
    <div class=""container"">
      <div class=""navbar-header d-block d-md-flex col-12 col-md-3 p-0"">
        <button type=""button"" class=""navbar-toggler  float-right"" data-toggle=""collapse"" data-target="".navbar-collapse"">
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

      <div class=""navbar-collapse collapse "">
        <ul class=""nav navbar-nav ml-auto align-items-left align-items-md-center "">
        
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
        text: 'var(--base-secondary)',
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

 Starting 08/28/2019 HS &amp; Adult Fall 1 2019<br/>
Soccer, Indoor, NA, Males only  <br/>Ages Adult   (over 18 years old)
<br/> Games 8<br/>

  Includes 8 Games. Team balances due IN FULL by the first scheduled game.<br/>

  <h4 style=""float:left; margin-right:10px;"">Team Color</h4>
  <div style=""margin-top:5px;"">
    <form id=""j5dacb6be478589-45588452"" method=""POST""  role=""form"" action=""index.php?Action=TeamAction/save&company=wideworldsports""><input type=""hidden"" name=""_method"" id=""l5dacb6be478b8935687049""  value=""POST""/>    <div class=""form-group""><input type=""text"" name=""color"" id=""w5dacb6be478fd408289123""  disabled class=""form-control"" value=""#f0f205""/><script>jQuery('#w5dacb6be478fd408289123').spectrum({""preferredFormat"":""hex"",""allowEmpty"":true,""showInput"":true,""disabled"":true});</script><span class=""form-text invalid-feedback""></span></div>    </form>  </div>



  <div class=""mb-3"">
      <a name=""schedules""></a>
      <h3>Schedule</h3>
    
<!-- Begin schedule output -->
<div class=""list-group flex-row flex-wrap"">

      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Sep 9th</div>
                  <div class=""mb-0 "">Mon 8:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7349"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #87f801;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1631"">Domino Men</a>                      </div>
                    <div>1</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #f0f205;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                  </div>
                  <div>6</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Sep 16th</div>
                  <div class=""mb-0 "">Mon 7:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7352"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #48b93a;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1604"">Gasping For Air</a>                      </div>
                    <div>0</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #f0f205;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                  </div>
                  <div>5</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Sep 23rd</div>
                  <div class=""mb-0 "">Mon 7:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7355"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #f0f205;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                      </div>
                    <div>3</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #1803f7;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1680"">Code Blue</a>                  </div>
                  <div>3</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Sep 30th</div>
                  <div class=""mb-0 "">Mon 8:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7357"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #f0f205;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                      </div>
                    <div>7</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #87f801;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1631"">Domino Men</a>                  </div>
                  <div>2</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Sep 30th</div>
                  <div class=""mb-0 "">Mon 9:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7356"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #f0f205;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                      </div>
                    <div>7</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #b5b0b0;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1648"">Tigers U50 Aluminum</a>                  </div>
                  <div>7</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Oct 7th</div>
                  <div class=""mb-0 "">Mon 7:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7361"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #49ff00;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1690"">WWSC Monday Men Green</a>                      </div>
                    <div>4</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #f0f205;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                  </div>
                  <div>5</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 inactive"">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Oct 14th</div>
                  <div class=""mb-0 "">Mon 8:45 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                                    <a href=""index.php?Action=Stats/game&company=wideworldsports&eventID=7368"" title=""Stats""><i class=""fa fa-chart-bar""></i></a>
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #f0f205;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                      </div>
                    <div>5</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #1803f7;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1680"">Code Blue</a>                  </div>
                  <div>1</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Revel &amp; Roll Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
      <div class=""list-group-item col-lg-6 col-12 "">

          <div class=""d-flex align-items-stretch"">
            <div class=""flex-shrink-0 border-right event__date d-flex flex-column justify-content-between"">
              <div>
                  <div class=""list-group-item-heading"">Oct 21st</div>
                  <div class=""mb-0 "">Mon 8:30 pm</div>
                  <div class=""mb-0 text-small"">1h</div>
              </div>
              <div class=""d-flex justify-content-between mr-4"">
                
                              </div>
            </div>
            <div class=""flex-grow-1 pl-2 event__details"">
                <h6 class=""mb-0 text-muted text-uppercase"">
                  Game                                  </h6>
                                <div class=""d-flex justify-content-between"">
                      <div class=""text-truncate mr-3"">
                        <i class=""fa fa-circle"" style=""color: #48b93a;""></i>
                        <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1604"">Gasping For Air</a>                      </div>
                    <div>-</div>
                  </div>
                
                                <div class=""d-flex justify-content-between"">
                  <div class=""text-truncate mr-2"">
                    <i class=""fa fa-home"" style=""color: #f0f205;""></i>
                    <a class=""font-weight-bold"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">Subs</a>                  </div>
                  <div>-</div>
                </div>
              
            <div>
                          </div>
            <div>
              <div class=""mb-0""><small>Daycroft School Field</small></div>
            </div>
          </div>
            <div>
                            </div>
          </div>
        </div>
  </div>

<script>
  jQuery('.dropdown').click(function () {
    // for some reason the schedule display dropdowns need this click handler to open on mobile. dont ask why, I don't know.
    // console.log('test');
  });
  jQuery(document).on('show.bs.dropdown', '.dropdown', function(e) {
    var dropdown = jQuery(e.target).find('.dropdown-menu');

    dropdown.appendTo('body');
    dropdown.css({width: 'unset'});

    jQuery(this).on('hidden.bs.dropdown', function () {
      dropdown.appendTo(e.target);
    });
  });
  jQuery(document).on('shown.bs.dropdown', '.dropdown', function(e) {
    var dropdown = jQuery(e.target).find('.dropdown-menu');
    var button = jQuery(e.target);
    var dropDownTop = button.offset().top + button.outerHeight();

    dropdown.css({transform: ""translate3d(""+button.offset().left+""px,""+dropDownTop+""px,0px)""});
  });

</script>  </div>
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
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1675"">
                  Subs</a>
              </td>
            
            <td class=""numeric"">5</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">0</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">17</td>
              <td class=""numeric"">38</td>
              <td class=""numeric"">18</td>
              <td class=""numeric"">20</td>
            
            <td class=""numeric"">0.857</td>
                        <td class=""numeric"">7</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1631"">
                  Domino Men</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">13</td>
              <td class=""numeric"">30</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">7</td>
            
            <td class=""numeric"">0.643</td>
                        <td class=""numeric"">7</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1690"">
                  WWSC Monday Men Green</a>
              </td>
            
            <td class=""numeric"">4</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">12</td>
              <td class=""numeric"">34</td>
              <td class=""numeric"">27</td>
              <td class=""numeric"">7</td>
            
            <td class=""numeric"">0.571</td>
                        <td class=""numeric"">7</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1680"">
                  Code Blue</a>
              </td>
            
            <td class=""numeric"">3</td>
            <td class=""numeric"">1</td>
            <td class=""numeric"">3</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">10</td>
              <td class=""numeric"">23</td>
              <td class=""numeric"">21</td>
              <td class=""numeric"">2</td>
            
            <td class=""numeric"">0.500</td>
                        <td class=""numeric"">7</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1648"">
                  Tigers U50 Aluminum</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">2</td>
            <td class=""numeric"">4</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">5</td>
              <td class=""numeric"">30</td>
              <td class=""numeric"">43</td>
              <td class=""numeric"">-13</td>
            
            <td class=""numeric"">0.286</td>
                        <td class=""numeric"">7</td>
          </tr>
                  
          <tr>
                          <td>
                <a  style=""color:blue"" href=""index.php?Action=team/index&company=wideworldsports&teamid=1604"">
                  Gasping For Air</a>
              </td>
            
            <td class=""numeric"">1</td>
            <td class=""numeric"">0</td>
            <td class=""numeric"">6</td>

                          <td class=""numeric"">0</td>
              <td class=""numeric"">3</td>
              <td class=""numeric"">14</td>
              <td class=""numeric"">37</td>
              <td class=""numeric"">-23</td>
            
            <td class=""numeric"">0.143</td>
                        <td class=""numeric"">7</td>
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
        &#169; 2019 Dash
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
        teamID: 1675      }
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
          teamID: 1675        }
      }).done(function (data, textStatus, jqXHR) {
        if(data.formErrors.length) {
          data.formErrors.map(function(e,k){dashMessage(e,'error')});
        } else {
          dashMessage(""You have been successfully removed from the team. You will now be redirected."", 'success');
          setTimeout(function () {
            location.replace('index.php?Action=Team/index&teamid=1675&leave=1&company=wideworldsports')
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


</script></body>
</html>
";
        #endregion
        private const int MatchingTeamId = 1675;

        [TestMethod]
        public void GetTeamSchedule_RunsWithoutError()
        {
            ScheduleHtmlParser.GetTeamSchedule(MatchingTeamId, TeamHtml).ToList();
        }
    }
}
