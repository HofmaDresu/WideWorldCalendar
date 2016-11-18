using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WideWorldCalendar.ScheduleFetcher
{
	public class MockScheduleFetcher : IScheduleFetcher
	{
		#region ScheduleScoresDisplayHtml
		private const string ScheduleScoresDisplayHtml = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN""
""http://www.w3.org/TR/html4/loose.dtd"">
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"">
<title>WideWorld Sports</title>
<style type=""text/css"">
<!--
body {
	background-color: #000000;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
a:link {
	color: #0000CC;
}
a:visited {
	color: #0000CC;
}
a:hover {
	color: #FF0000;
}
a:active {
	color: #0000CC;
}
.style47 {font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif; }
.style49 {
	color: #666;
	font-size: 15px;
	font-family: Arial, Helvetica, sans-serif;
	font-weight: bold;
}
.style128 {	color: #FFFFFF;
	font-weight: bold;
}
.style81 {
	font-size: 13px;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	color: #000000;
}
.MRLText {font-family: Geneva, Verdana, Arial;
	font-size: 11px;
	font-style: normal;
	font-weight: normal;
	font-variant: normal;
	color: #333333;
}
-->
</style>
</head>

<body>
<div align=""center""></div>
<div align=""center""><img src=""wideworldbanner.jpg"" width=""735"" height=""105""></div>
<div align=""center"">
  <table width=""735""  border=""0"" align=""center"" cellpadding=""11"" cellspacing=""0"" bgcolor=""#FFFFFF"">
    <tr>
      <td valign=""top""><p align=""center"" class=""style49"">WideWorld Sports Schedules,
          Scores &amp; Standings</p>
		
		
				
        <p align=""center"" class=""style81""><strong>Season: </strong>Summer Adult Indoor Soccer (2016)
        </p>
        <div align=""left"">
          <table width=""100%""  border=""0"" cellspacing=""0"" cellpadding=""2"">
            <tr valign=""top"">
              <td align=""left"" class=""style47"">

                  <table width=""190""  border=""1"" align=""center"" cellpadding=""3"" cellspacing=""0"">
                    <tr bgcolor=""#6D4383"" class=""style81"">
                      <td width=""50%"" bgcolor=""#333333""><span class=""style128"">Mens Schedules </span></td>
                    </tr>
<tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1377'>OPEN MEN Wed D3</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1380'>OPEN MEN Wed D4</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1378'>OPEN MEN Sun D3/D4</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1369'>O30 MEN Mon D2/D3</a></div></td></tr>
                  </table>

                <p><br>                
                  <br>
                </p>
                </td>
              <td align=""left"" class=""style47"">

                  <table width=""190""  border=""1"" align=""center"" cellpadding=""3"" cellspacing=""0"">
                    <tr bgcolor=""#6D4383"" class=""style81"">
                      <td width=""50%"" bgcolor=""#333333""><span class=""style128"">Womens Schedules </span></td>
                    </tr>

<tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1374'>O30 WN Tues Rec D1/D2</a></div></td></tr>
                  </table>

                <p><br>
                  <br>
              </p></td>
              <td align=""center"" class=""style47"">
                
              <table width=""190""  border=""1"" align=""center"" cellpadding=""3"" cellspacing=""0"">
                <tr bgcolor=""#6D4383"" class=""style81"">
                  <td width=""50%"" bgcolor=""#333333""><span class=""style128"">Coed Schedules </span></td>
                </tr>

<tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1372'>OPEN COED Tues D4 A/B</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1373'>OPEN COED Thurs D3/D4</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1370'>OPEN COED Fri D2/D3</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1371'>OPEN COED Sun D3/D4</a></div></td></tr>
              </table>

              
              </td>
            </tr>
          </table>

				
        <p align=""center"" class=""style81""><strong>Season: </strong>Fall 1 Adult Indoor Soccer (2016)
        </p>
        <div align=""left"">
          <table width=""100%""  border=""0"" cellspacing=""0"" cellpadding=""2"">
            <tr valign=""top"">
              <td align=""left"" class=""style47"">

                  <table width=""190""  border=""1"" align=""center"" cellpadding=""3"" cellspacing=""0"">
                    <tr bgcolor=""#6D4383"" class=""style81"">
                      <td width=""50%"" bgcolor=""#333333""><span class=""style128"">Mens Schedules </span></td>
                    </tr>
<tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1387'>OPEN MEN Wed D3</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1389'>OPEN MEN Wed D4</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1388'>OPEN MEN Sun D3/D4</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1381'>O30 MEN Mon D2/D3</a></div></td></tr>
                  </table>

                <p><br>                
                  <br>
                </p>
                </td>
              <td align=""left"" class=""style47"">

                  <table width=""190""  border=""1"" align=""center"" cellpadding=""3"" cellspacing=""0"">
                    <tr bgcolor=""#6D4383"" class=""style81"">
                      <td width=""50%"" bgcolor=""#333333""><span class=""style128"">Womens Schedules </span></td>
                    </tr>

<tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1386'>O30 WN Tues Rec D1/D2</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1394'>O30 WN Thurs Rec D1-D3</a></div></td></tr>
                  </table>

                <p><br>
                  <br>
              </p></td>
              <td align=""center"" class=""style47"">
                
              <table width=""190""  border=""1"" align=""center"" cellpadding=""3"" cellspacing=""0"">
                <tr bgcolor=""#6D4383"" class=""style81"">
                  <td width=""50%"" bgcolor=""#333333""><span class=""style128"">Coed Schedules </span></td>
                </tr>

<tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1384'>OPEN COED Tues D4 A</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1390'>OPEN COED Tues D4 B</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1385'>OPEN COED Thurs D3</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1391'>OPEN COED Thurs D4</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1382'>OPEN COED Fri D2/D3</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1383'>OPEN COED Sun D3</a></div></td></tr><tr valign='top' class='style129'><td><div align='left'><a href='DivisionReport.asp?ID=1392'>OPEN COED Sun D4</a></div></td></tr>
              </table>

              
              </td>
            </tr>
          </table>

          <p align=""center""><span class=""style81"">Need to Complete your Team
              Roster? Use the WWS e-Roster System today...<a href=""http://www.wideworld-sports.com/roster.html"">Click
        Here</a>. </span></p>
        </div>
<p align=""center"" class=""style81""><a href=""http://www.wideworld-sports.com/Indoor_Standings/Archived_Standings.htm"">Click Here for Archived Standings</a></p>
        <div align=""center"" class=""style81""><a href=""http://www.wideworld-sports.com"">Return
      to the WideWorld Sports Website</a>        </div>      </td>
    </tr>
  </table>
  <table width=""735"" align=""center"" cellpadding=""1"" bgcolor=""#cccccc"">
    <tr>
      <td width=""728""><div align=""center""><span class=""style47"">Copyright: WideWorld Sports Center. All Rights Reserved.</span></div></td>
    </tr>
  </table>
</div>
</body>
</html>
";
		#endregion
		#region DivisionReportHtml
		private const string DivisionReportHtml = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN""
""http://www.w3.org/TR/html4/loose.dtd"">
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"">
<title>WideWorld Sports</title>
<style type=""text/css"">
<!--
body {
	background-color: #000000;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
a:link {
	color: #0000CC;
}
a:visited {
	color: #0000CC;
}
a:hover {
	color: #FF0000;
}
a:active {
	color: #0000CC;
}
.style47 {font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif; }
.style49 {
	color: #333333;
	font-size: 15px;
	font-family: Arial, Helvetica, sans-serif;
	font-weight: bold;
}
.style81 {font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; }
.MRLText {font-family: Geneva, Verdana, Arial;
	font-size: 11px;
	font-style: normal;
	font-weight: normal;
	font-variant: normal;
	color: #333333;
}
.style127 {font-family: Verdana, Arial, Helvetica, sans-serif; font-weight: bold; font-size: 11px; color: #333333; }
.style130 {font-weight: normal; font-variant: normal; color: #333333; font-style: normal;}
.style131 {color: #FFFFFF; font-family: Verdana, Arial, Helvetica, sans-serif; }
.style138 {font-family: Verdana, Arial, Helvetica, sans-serif; font-weight: bold; font-size: 12px; color: #333333; }
.style135 {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; font-style: normal; font-weight: normal; font-variant: normal; color: #333333; }
.style136 {color: #FFFFFF; font-family: Verdana, Arial, Helvetica, sans-serif; font-weight: bold; }
.style4 {color: #000000;
	font-weight: bold;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 11px;
}
-->
</style>
</head>

<body>
<div align=""center""></div>
<div align=""center""><img src=""wideworldbanner.jpg"" width=""735"" height=""105""></div>
<div align=""center"">
  <table width=""735""  border=""0"" align=""center"" cellpadding=""11"" cellspacing=""0"" bgcolor=""#FFFFFF"">
    <tr>
      <td valign=""top""><p align=""center"" class=""style49"">WideWorld Sports Schedules, Scores &amp; Standings</p>
        <p align=""center"" class=""style81""><span class=""style4"">Division: OPEN COED Thurs D3</span><br>
            <span class=""style130""><a href=""PrintSchedule.asp?ID=1385""><br>
            Printable
            Version of Entire Schedule</a></span></p>
        <div align=""center"">
          <table width=""78%"" border=""1"" cellspacing=""0"" cellpadding=""3"">
            <tr>
              <td width=""21%"" class=""style127"">Latest News: </td>
              <td width=""79%"" class=""style135""><font color=""#FF0000""><strong></strong></font></td>
            </tr>
          </table>

        <p align=""center"" class=""style47""><span class=""style138"">Team Contacts: </span><br>Click on Team # to view this team's roster.<br>Click on Team Name to view printable version of this team's schedule.</p>
        <table width=""99%""  border=""1"" align=""center"" cellpadding=""2"" cellspacing=""0"">
          <tr valign=""top"" bgcolor=""#6E4484"" class=""MRLText"">
            <td width=""9%"" bgcolor=""#333333"" class=""style136"">Team # </td>
            <td width=""18%"" bgcolor=""#333333"" class=""style131""><div align=""left"" class=""style117""><strong>Team</strong></div></td>
            <td width=""15%"" bgcolor=""#333333"" class=""style136"">Team Manager</td>
            <td width=""32%"" bgcolor=""#333333"" class=""style136"">Team Contact Email</td>
            <td width=""14%"" bgcolor=""#333333"" class=""style117""><div align=""center"" class=""style140"">Team
            Phone </div></td>
            <td width=""12%"" bgcolor=""#333333"" class=""style142"">Jersey</td>
          </tr>
<tr valign='top' class='MRLText'><td><span class='style132'><a href='TeamRosterPDFSimple.asp?ID=5631' target='_blank'>C18C4</a></span></td><td align='left'><span class='style132'><a href='PrintTeamSchedule.asp?ID=5631'>The Producers</a></span></td><td align='left'><span class='style132'>Rachel Schilling</span></td><td><span class='style132'><a href='mailto:rachel@childrenscenterforgrowth.com'>rachel@childrenscenterforgrowth.com</a></span></td><td><div align='left' class='style132'>248-709-8496</div></td><td align='left'><span class='style132'>Brown</span></td></tr><tr valign='top' class='MRLText'><td><span class='style132'><a href='TeamRosterPDFSimple.asp?ID=5638' target='_blank'>C18C2</a></span></td><td align='left'><span class='style132'><a href='PrintTeamSchedule.asp?ID=5638'>Search and Rescue Records - Thursday</a></span></td><td align='left'><span class='style132'>Jonathon Woods</span></td><td><span class='style132'><a href='mailto:jonathonwoods@live.com'>jonathonwoods@live.com</a></span></td><td><div align='left' class='style132'>734-649-6308</div></td><td align='left'><span class='style132'>Green</span></td></tr><tr valign='top' class='MRLText'><td><span class='style132'><a href='TeamRosterPDFSimple.asp?ID=5660' target='_blank'>C18C5</a></span></td><td align='left'><span class='style132'><a href='PrintTeamSchedule.asp?ID=5660'>Barcenal CF</a></span></td><td align='left'><span class='style132'>Brian Tew</span></td><td><span class='style132'><a href='mailto:tewbri@gmail.com'>tewbri@gmail.com</a></span></td><td><div align='left' class='style132'>734-223-5695</div></td><td align='left'><span class='style132'>Red</span></td></tr><tr valign='top' class='MRLText'><td><span class='style132'><a href='TeamRosterPDFSimple.asp?ID=5661' target='_blank'>C18C6</a></span></td><td align='left'><span class='style132'><a href='PrintTeamSchedule.asp?ID=5661'>Thomson Reuters</a></span></td><td align='left'><span class='style132'>Chris Wilson</span></td><td><span class='style132'><a href='mailto:wilson.ct3@gmail.com'>wilson.ct3@gmail.com</a></span></td><td><div align='left' class='style132'>734-394-8284</div></td><td align='left'><span class='style132'>Black</span></td></tr><tr valign='top' class='MRLText'><td><span class='style132'><a href='TeamRosterPDFSimple.asp?ID=5690' target='_blank'>C18C3</a></span></td><td align='left'><span class='style132'><a href='PrintTeamSchedule.asp?ID=5690'>ETBTSST</a></span></td><td align='left'><span class='style132'>J. Steven Bullock</span></td><td><span class='style132'><a href='mailto:j.steven.bullock@gmail.com'>j.steven.bullock@gmail.com</a></span></td><td><div align='left' class='style132'>734-218-5228</div></td><td align='left'><span class='style132'>Red</span></td></tr><tr valign='top' class='MRLText'><td><span class='style132'><a href='TeamRosterPDFSimple.asp?ID=5721' target='_blank'>C18C1</a></span></td><td align='left'><span class='style132'><a href='PrintTeamSchedule.asp?ID=5721'>AAFC Thorny Devils</a></span></td><td align='left'><span class='style132'>Casey Bantle</span></td><td><span class='style132'><a href='mailto:aafc1997@gmail.com'>aafc1997@gmail.com</a></span></td><td><div align='left' class='style132'>734-645-5609</div></td><td align='left'><span class='style132'>Red or Black</span></td></tr>
        </table>        
          <p class=""style138"">Standings:</p>
          <table width=""80%""  border=""1"" align=""center"" cellpadding=""2"" cellspacing=""0"">
            <tr bgcolor=""#6D4383"" class=""MRLText"">
              <td width=""11%"" bgcolor=""#333333"" class=""style136"">Team # </td>
              <td width=""35%"" bgcolor=""#333333"" class=""style131""><div align=""left""><strong>Team</strong></div></td>
              <td width=""8%"" bgcolor=""#333333"" class=""style136"">Win</td>
              <td width=""8%"" bgcolor=""#333333"" class=""style136"">Loss</td>
              <td width=""7%"" bgcolor=""#333333"" class=""style136"">Tie</td>
              <td width=""11%"" bgcolor=""#333333"" class=""style136"">Points</td>
              <td width=""6%"" bgcolor=""#333333"" class=""style136"">GF</td>
              <td width=""6%"" bgcolor=""#333333"" class=""style136"">GA</td>
              <td width=""8%"" bgcolor=""#333333"" class=""style136"">GD</td>
            </tr>
<tr class='MRLText' bgcolor=#FFFFFF><td>C18C1</td><td align='left'>AAFC Thorny Devils</td><td>5</td><td>0</td><td>0</td><td>15</td><td>23</td><td>8</td><td>15</td></tr><tr class='MRLText' bgcolor=#CCCCCC><td>C18C4</td><td align='left'>The Producers</td><td>4</td><td>1</td><td>0</td><td>12</td><td>20</td><td>6</td><td>14</td></tr><tr class='MRLText' bgcolor=#FFFFFF><td>C18C2</td><td align='left'>Search and Rescue Records - Thursday</td><td>3</td><td>2</td><td>0</td><td>9</td><td>20</td><td>18</td><td>2</td></tr><tr class='MRLText' bgcolor=#CCCCCC><td>C18C5</td><td align='left'>Barcenal CF</td><td>2</td><td>3</td><td>0</td><td>6</td><td>17</td><td>17</td><td>0</td></tr><tr class='MRLText' bgcolor=#FFFFFF><td>C18C3</td><td align='left'>ETBTSST</td><td>1</td><td>4</td><td>0</td><td>3</td><td>13</td><td>24</td><td>-11</td></tr><tr class='MRLText' bgcolor=#CCCCCC><td>C18C6</td><td align='left'>Thomson Reuters</td><td>0</td><td>5</td><td>0</td><td>0</td><td>10</td><td>30</td><td>-20</td></tr>
          </table>
        </div>
        <p align=""center"" class=""style138"">Schedules/Scores:<br>
        <span class='MRLText'><font color=""Blue"">Blue </font></span><span style=""font-family: Geneva, Verdana, Arial; font-size: 11px""><font color=""Blue"">=</font></span><span class='MRLText'><font color=""Blue""> Game Has Been Modified</font><br>
          <font color=""Red"">Red </font></span><span style=""font-size: 11px; font-style: normal; font-weight: normal; font-variant: normal; font-family: Geneva, Verdana, Arial;""><font color=""Red"">=</font></span><span class='MRLText'><font color=""Red""> Game Has Been Canceled</font></span>
        </p>
        <table width=""99%""  border=""1"" align=""center"" cellpadding=""2"" cellspacing=""0"">
          <tr valign=""top"" bgcolor=""#6D4383"" class=""MRLText"">
            <td bgcolor=""#333333"" class=""style136"">Date</td>
            <td align=""center"" bgcolor=""#333333"" class=""style136"">Day</td>
            <td  bgcolor=""#333333"" class=""style136"">Time</td>
            <td bgcolor=""#333333"" class=""style136"">Field</td>
            <td align=""center"" bgcolor=""#333333"" class=""style136"">Home Team </td>
            <td  align=""center"" bgcolor=""#333333"" class=""style136"">Score</td>
            <td  align=""center"" bgcolor=""#333333"" class=""style136"">Visiting Team </td>
            <td  align=""center"" bgcolor=""#333333"" class=""style136"">Score</td>
            <td  align=""center"" bgcolor=""#333333"" class=""style136"">Forfeit</td>
          </tr>
<tr class='MRLText'><td align='left'><font color='Black'>9/1/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>2</td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>7</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Blue'>9/1/2016</font></td><td align='center'><font color='Blue'>Thurs&nbsp;</font></td><td align='left'><font color='Blue'>7:30 PM</font></td><td align='left'><font color='Blue'>Big Georges Field</font></td><td align='left'><font color='Blue'>Thomson Reuters</font></td><td align='center'>2</td><td align='left'><font color='Blue'>Barcenal CF</font></td><td align='center'>5</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Blue'>9/1/2016</font></td><td align='center'><font color='Blue'>Thurs&nbsp;</font></td><td align='left'><font color='Blue'>9:30 PM</font></td><td align='left'><font color='Blue'>Big Georges Field</font></td><td align='left'><font color='Blue'>The Producers</font></td><td align='center'>6</td><td align='left'><font color='Blue'>ETBTSST</font></td><td align='center'>1</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>9/8/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>5</td><td align='left'><font color='Black'>Barcenal CF</font></td><td align='center'>3</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>9/8/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>9:30 PM</font></td><td align='left'><font color='Black'>Big Georges Field</font></td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>4</td><td align='left'><font color='Black'>ETBTSST</font></td><td align='center'>1</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>9/8/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>10:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>Thomson Reuters</font></td><td align='center'>2</td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>7</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>9/15/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>ETBTSST</font></td><td align='center'>7</td><td align='left'><font color='Black'>Thomson Reuters</font></td><td align='center'>4</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>9/15/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>9:30 PM</font></td><td align='left'><font color='Black'>Big Georges Field</font></td><td align='left'><font color='Black'>Barcenal CF</font></td><td align='center'>3</td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>5</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>9/15/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>9:35 PM</font></td><td align='left'><font color='Black'>South Field</font></td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>2</td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>1</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>9/22/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>4</td><td align='left'><font color='Black'>Thomson Reuters</font></td><td align='center'>0</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Blue'>9/22/2016</font></td><td align='center'><font color='Blue'>Thurs&nbsp;</font></td><td align='left'><font color='Blue'>8:30 PM</font></td><td align='left'><font color='Blue'>Big Georges Field</font></td><td align='left'><font color='Blue'>Search and Rescue Records - Thursday</font></td><td align='center'>6</td><td align='left'><font color='Blue'>ETBTSST</font></td><td align='center'>2</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>9/22/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>10:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>Barcenal CF</font></td><td align='center'>2</td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>3</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>9/29/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>7</td><td align='left'><font color='Black'>Thomson Reuters</font></td><td align='center'>2</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>9/29/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>9:30 PM</font></td><td align='left'><font color='Black'>Big Georges Field</font></td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>0</td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>4</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>9/29/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>10:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>ETBTSST</font></td><td align='center'>2</td><td align='left'><font color='Black'>Barcenal CF</font></td><td align='center'>4</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>10/6/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>Barcenal CF</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Blue'>10/6/2016</font></td><td align='center'><font color='Blue'>Thurs&nbsp;</font></td><td align='left'><font color='Blue'>8:30 PM</font></td><td align='left'><font color='Blue'>Big Georges Field</font></td><td align='left'><font color='Blue'>Thomson Reuters</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Blue'>ETBTSST</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>10/6/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>10:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>10/13/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>Barcenal CF</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>10/13/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>9:30 PM</font></td><td align='left'><font color='Black'>Big Georges Field</font></td><td align='left'><font color='Black'>ETBTSST</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Black'>10/13/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>10:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>Thomson Reuters</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>10/20/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>7:00 PM</font></td><td align='left'><font color='Black'>Dominos.com Field</font></td><td align='left'><font color='Black'>ETBTSST</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>Search and Rescue Records - Thursday</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText'><td align='left'><font color='Blue'>10/20/2016</font></td><td align='center'><font color='Blue'>Thurs&nbsp;</font></td><td align='left'><font color='Blue'>8:30 PM</font></td><td align='left'><font color='Blue'>Big Georges Field</font></td><td align='left'><font color='Blue'>Barcenal CF</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Blue'>Thomson Reuters</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr><tr class='MRLText' BGCOLOR='#CCCCCC'><td align='left'><font color='Black'>10/20/2016</font></td><td align='center'><font color='Black'>Thurs&nbsp;</font></td><td align='left'><font color='Black'>9:30 PM</font></td><td align='left'><font color='Black'>Big Georges Field</font></td><td align='left'><font color='Black'>The Producers</font></td><td align='center'>&nbsp;</td><td align='left'><font color='Black'>AAFC Thorny Devils</font></td><td align='center'>&nbsp;</td><td align='center'>&nbsp;</td></tr>
        </table>
        <p class=""style81"">&nbsp;</p>        
        <div align=""center"" class=""style81""><a href=""http://www.wideworld-sports.com"">Return
            to the WideWorld Sports Center Website</a>        </div>
      </td>
    </tr>
  </table>
  <table width=""735"" align=""center"" cellpadding=""1"" bgcolor=""#CCCCCC"">
    <tr>
      <td width=""728""><div align=""center""><span class=""style47"">Copyright: WideWorld Sports Center. All Rights Reserved.</span></div></td>
    </tr>
  </table>
</div>
</body>
</html>
";
		#endregion
		#region PrintTeamScheduleHtml
		private const string PrintTeamScheduleHtml = @"
<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN""
""http://www.w3.org/TR/html4/loose.dtd"">
<html>
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"">
<title>WideWorld Sports</title>
<style type=""text/css"">
<!--
.MRLText {font-family: Geneva, Verdana, Arial;
	font-size: 11px;
	font-style: normal;
	font-weight: normal;
	font-variant: normal;
	color: #333333;
}
.style132 {color: #333333; font-family: Verdana, Arial, Helvetica, sans-serif; }
.style137 {font-family: Verdana, Arial, Helvetica, sans-serif}
.style1 {color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif; font-weight: bold; }
.style3 {font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; }
.style4 {color: #000000}
.style5 {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; }
.style6 {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 14px;
	font-weight: bold;
}
.style117 {color: #FFFFFF}
.style142 {color: #000000; font-weight: bold; }
.style7 {font-family: Geneva, Verdana, Arial; font-size: 11px; font-style: normal; font-weight: normal; font-variant: normal; color: #000000; }
.style8 {
	font-size: 12px;
	font-weight: bold;
}
.style9 {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-weight: bold;
}
.style103 {font-style: normal; font-weight: normal; font-variant: normal; color: #333333; font-size: 11px;}
.style81 {font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; }
.styleTeam {
	font-size: 16px;
	font-weight: bold;
}
-->
</style>
</head>

<body>
<table width=""680"" align=""center"" cellpadding=""2"" cellspacing=""0"">
  <tr>
    <td width=""20%""><p align=""center"" class=""style6""><img src=""WWsoccer.jpg"" width=""103"" height=""106""></p>
    </td>
    <td width=""60%""><p align=""center"" class=""style6"">WideWorld Sports Schedule</p>
      <p align=""center"" class=""style5""><strong>Season: </strong><span class=""style81"">Fall 1 Adult Indoor Soccer (2016)</span>
    | <strong>Division: </strong><span class=""style103"">OPEN COED Thurs D3</span><br>
    <span class=""styleTeam"">Schedule for Team: C18C4-The Producers</span></p></td>
    <td width=""20%""><img src=""WWquote.jpg"" width=""150"" height=""65""></td>
  </tr>
  <tr>
    <td colspan=""3""><div align=""center"">
      <p class=""style9"">Team Contacts</p>
      </div>
      <table width=""650""  border=""1"" align=""center"" cellpadding=""2"" cellspacing=""0"">
      <tr valign=""top"" bgcolor=""#FFFFFF"" class=""MRLText"">
        <td width=""5%"" class=""style1"">Team # </td>
        <td width=""20%"" class=""style131""><div align=""left"" class=""style4""><strong>Team</strong></div></td>
        <td width=""20%"" class=""style1"">Team Manager</td>
        <td width=""30%"" class=""style1"">Team Contact Email</td>
        <td width=""14%"" class=""style117""><div align=""center"" class=""style1"">Team
            Phone </div></td>
        <td width=""10%"" class=""style142"">Jersey</td>
      </tr>
<tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>C18C1</td><td align='left'><span class='style3'>AAFC Thorny Devils</span></td><td align='left'><span class='style3'>Casey Bantle</span></td><td align='left'><span class='style3'>aafc1997@gmail.com&nbsp;</span></td><td align='left'><span class='style3'>734-645-5609&nbsp;</span></td><td align='left'><span class='style3'>Red or Black</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>C18C2</td><td align='left'><span class='style3'>Search and Rescue Records - Thursday</span></td><td align='left'><span class='style3'>Jonathon Woods</span></td><td align='left'><span class='style3'>jonathonwoods@live.com&nbsp;</span></td><td align='left'><span class='style3'>734-649-6308&nbsp;</span></td><td align='left'><span class='style3'>Green</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>C18C3</td><td align='left'><span class='style3'>ETBTSST</span></td><td align='left'><span class='style3'>J. Steven Bullock</span></td><td align='left'><span class='style3'>j.steven.bullock@gmail.com&nbsp;</span></td><td align='left'><span class='style3'>734-218-5228&nbsp;</span></td><td align='left'><span class='style3'>Red</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>C18C4</td><td align='left'><span class='style3'>The Producers</span></td><td align='left'><span class='style3'>Rachel Schilling</span></td><td align='left'><span class='style3'>rachel@childrenscenterforgrowth.com&nbsp;</span></td><td align='left'><span class='style3'>248-709-8496&nbsp;</span></td><td align='left'><span class='style3'>Brown</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>C18C5</td><td align='left'><span class='style3'>Barcenal CF</span></td><td align='left'><span class='style3'>Brian Tew</span></td><td align='left'><span class='style3'>tewbri@gmail.com&nbsp;</span></td><td align='left'><span class='style3'>734-223-5695&nbsp;</span></td><td align='left'><span class='style3'>Red</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>C18C6</td><td align='left'><span class='style3'>Thomson Reuters</span></td><td align='left'><span class='style3'>Chris Wilson</span></td><td align='left'><span class='style3'>wilson.ct3@gmail.com&nbsp;</span></td><td align='left'><span class='style3'>734-394-8284&nbsp;</span></td><td align='left'><span class='style3'>Black</span></td></tr>
    </table></td>
  </tr>
  <tr>
    <td colspan=""3"">&nbsp;</td>
  </tr>
  <tr>
    <td colspan=""3""><p align=""center"" class=""style9"">Schedules/Scores</p>
      <table width=""650""  border=""1"" align=""center"" cellpadding=""2"" cellspacing=""0"" bgcolor=""#FFFFFF"">
        <tr valign=""top"" bgcolor=""#FFFFFF"" class=""MRLText"">
          <td width=""10%"" class=""style1"">Date</td>
          <td width=""5%"" class=""style1"">Day</td>
          <td width=""10%"" class=""style1"">Time</td>
          <td width=""25%"" class=""style1"">Field</td>
          <td width=""15%"" class=""style1"">Home Team </td>
          <td width=""10%"" class=""style1""><div align=""center"">Score</div></td>
          <td width=""15%"" class=""style1"">Visiting Team </td>
          <td width=""10%"" class=""style1""><div align=""center"">Score</div></td>
        </tr>
<tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>9/1/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>9:30 PM</span></td><td align='left'><span class='style3'>Big Georges Field</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>6</span></td><td align='left'><span class='style3'>C18C3</span></td><td align='center'><span class='style3'>1</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>9/8/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>7:00 PM</span></td><td align='left'><span class='style3'>Dominos.com Field</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>5</span></td><td align='left'><span class='style3'>C18C5</span></td><td align='center'><span class='style3'>3</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>9/15/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>9:35 PM</span></td><td align='left'><span class='style3'>South Field</span></td><td align='left'><span class='style3'>C18C1</span></td><td align='center'><span class='style3'>2</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>1</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>9/22/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>7:00 PM</span></td><td align='left'><span class='style3'>Dominos.com Field</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>4</span></td><td align='left'><span class='style3'>C18C6</span></td><td align='center'><span class='style3'>0</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>9/29/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>9:30 PM</span></td><td align='left'><span class='style3'>Big Georges Field</span></td><td align='left'><span class='style3'>C18C2</span></td><td align='center'><span class='style3'>0</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>4</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>10/6/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>7:00 PM</span></td><td align='left'><span class='style3'>Dominos.com Field</span></td><td align='left'><span class='style3'>C18C5</span></td><td align='center'><span class='style3'>&nbsp;</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>&nbsp;</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>10/13/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>10:00 PM</span></td><td align='left'><span class='style3'>Dominos.com Field</span></td><td align='left'><span class='style3'>C18C6</span></td><td align='center'><span class='style3'>&nbsp;</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>&nbsp;</span></td></tr><tr valign='top' bgcolor='#FFFFFF'  class='MRLText'><td align='left' class='style3'>10/20/2016</td><td align='center' class='style3'>Thurs&nbsp;</td><td align='left'><span class='style3'>9:30 PM</span></td><td align='left'><span class='style3'>Big Georges Field</span></td><td align='left'><span class='style3'>C18C4</span></td><td align='center'><span class='style3'>&nbsp;</span></td><td align='left'><span class='style3'>C18C1</span></td><td align='center'><span class='style3'>&nbsp;</span></td></tr>
      </table></td>
  </tr>
</table>
<p align=""center"" class=""style6""><br>
</p>
<p align=""center"" class=""style9"">&nbsp;</p>
</body>
</html>
";
		#endregion

		public async Task<string> GetSchedulesPage()
		{
			await Task.Delay(1000);

			return ScheduleScoresDisplayHtml;
		}

		public List<string> GetSeasons(string schedulePageHtml)
		{
			return ScheduleHtmlParser.GetSeasons(schedulePageHtml).ToList();
		}

		public List<string> GetScheduleGroupings(string schedulePageHtml, string season)
		{
			return ScheduleHtmlParser.GetScheduleGroupings(schedulePageHtml, season).ToList();
		}

		public List<NavigationOption> GetDivisions(string schedulePageHtml, string season, string schedule)
		{
			return ScheduleHtmlParser.GetDivisions(schedulePageHtml, season, schedule).ToList();
		}

		public async Task<List<NavigationOption>> GetTeams(int divisionId)
		{
			await Task.Delay(1000);
			return ScheduleHtmlParser.GetTeams(DivisionReportHtml).ToList();
		}

		public async Task<List<Game>> GetTeamSchedule(int teamId)
		{
			await Task.Delay(1000);
			return ScheduleHtmlParser.GetTeamSchedule(teamId, PrintTeamScheduleHtml).ToList();
		}
	}
}
